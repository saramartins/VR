using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GameObject menuObject;
	ControllerAbstractionLayer leftController;
	public SceneChanger sceneChanger;

//	public GameObject rController;
//	ControllerAbstractionLayer rightController;


	// Use this for initialization
	void Start () {
		leftController = this.GetComponent<ControllerAbstractionLayer>();
//		rightController = rController.GetComponent<ControllerAbstractionLayer> ();
		sceneChanger = GetComponentInParent<SceneChanger> ();
		Debug.Log ("SCENE CHANGER: " + sceneChanger);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (leftController.isTriggerButtonDown ())
			menuObject.SetActive (true);
		else if (leftController.isTriggerButtonReleased ()) {
			menuObject.SetActive (false);
//			rightController.setColorDefault ();
		}
			
	}
}
