//===== 
//
// This script is a component of game object Controller (right) 
//


using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PickupParent : MonoBehaviour {

	public Transform sphere;

	private int counter = 0;

	ControllerAbstractionLayer controller;

	// Use this for initialization
	void Start () {		
		controller = GetComponent<ControllerAbstractionLayer>();
	}

	void FixedUpdate () {
		
		if (controller.isPressUp()) {
			sphere.transform.position = new Vector3 (-5, 1, -7);
			sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
			sphere.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}

	}

	void OnTriggerStay (Collider col)
	{
		//Change controller color!!
		if (col.tag != "Untagged") {
			controller.setColorNew ();
		}

		if (controller.isTriggerButtonDown () && counter>10) {
			counter = 0;

			switch (col.tag) {
				case "Grabbable":
					col.attachedRigidbody.isKinematic = true;
					col.gameObject.transform.SetParent (this.gameObject.transform);
					break;

				case "LightSwitch":
					foreach (Light l in col.GetComponentsInChildren<Light>()) {
						l.enabled = !(l.enabled);
					}
					controller.triggerHapticPulse (3999);
					break;

				case "TV":
					col.GetComponent<MoviePlayer> ().toggleTV ();
					break;

				case "Surprise":
					col.GetComponent<BallHaven> ().initBallHaven ();
					break;

				case "Menu":
					col.GetComponent<MenuObj> ().executeMenuObj ();
					break;

				case "Slider":
					if (col.GetComponent<LightController> ())
						col.GetComponent<LightController> ().pickedUp = true;
					else if (col.GetComponent<ColorController> ())
						col.GetComponent<ColorController> ().pickedUp = true;
					break;

				case "SceneChanger":
					GetComponentInParent<SceneChanger> ().ChangeScene ("Nowhere");
					break;
				
				default:
					//No specified funtionallity for other objects 
					break;
			}
		} 
		else if (controller.isTriggerButtonReleased ())
		{
			if (col.tag == "Grabbable") {
				col.gameObject.transform.SetParent (null);
				col.attachedRigidbody.isKinematic = false;
				tossObject (col.attachedRigidbody);
			} else if (col.tag == "Slider") {
				if (col.GetComponent<LightController> ()) {
					col.GetComponent<LightController> ().pickedUp = false;
				} else if (col.GetComponent<ColorController> ()) {
					col.GetComponent<ColorController> ().pickedUp = false;
				}
			}
		}
		counter++;
	}

	void OnTriggerExit(Collider col)
	{
		Debug.Log ("On Trigger Exit! " + col.name);
		controller.setColorDefault ();

		if (col.GetComponent<LightController> ()) {
			col.GetComponent<LightController> ().pickedUp = false;
		} else if (col.GetComponent<ColorController> ()) {
			col.GetComponent<ColorController> ().pickedUp = false;
		}
	}

	void tossObject(Rigidbody rigidBody)
	{
		
		Transform origin = controller.getTrackedObj().origin ? controller.getTrackedObj().origin : controller.getTrackedObj().transform.parent;
		if (origin != null) 
		{
			rigidBody.velocity = origin.TransformVector(controller.getVelocity());
			rigidBody.angularVelocity = origin.TransformVector(controller.getAngularVelocity());
		} 
		else 
		{
			rigidBody.velocity = controller.getVelocity();
			rigidBody.angularVelocity = controller.getAngularVelocity();	
		}
	}

	private void ChangeScene(string Scene){
//		Debug.Log (SceneManager.GetSceneByName (Scene).IsValid());
//		if (SceneManager.GetSceneByName (Scene).IsValid()) {
//			StartCoroutine (waitAndChangeScen(1,Scene));
			DontDestroyOnLoad (FindObjectOfType<SteamVR_Render>());
			SceneManager.LoadScene (Scene);
//		} else {
//			Debug.LogError ("Scene does not exist! ");
//		}
	}
}
