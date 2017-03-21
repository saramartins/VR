using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class SceneChanger : MonoBehaviour {

	public SceneChanger() {
		
	}

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeScene(string Scene){
		//		Debug.Log (SceneManager.GetSceneByName (Scene).IsValid());
		//		if (SceneManager.GetSceneByName (Scene).IsValid()) {
		//			StartCoroutine (waitAndChangeScen(1,Scene));
		if (Scene != "MyScene") {
			DontDestroyOnLoad (GameObject.Find ("[CameraRig]"));
			DontDestroyOnLoad (FindObjectOfType<SteamVR_Render> ());
			DontDestroyOnLoad (GameObject.Find("Sun"));
		} else {
			Destroy (GameObject.Find ("[CameraRig]"));
		}
		SceneManager.LoadScene (Scene);
		//		} else {
		//			Debug.LogError ("Scene does not exist! ");
		//		}
	}

	IEnumerator wait(float waitTime){
		print("Time1:" + Time.time);
		yield return new WaitForSeconds(waitTime);
		print("Time2:" + Time.time);
	}

	IEnumerator waitAndChangeScen(float waitTime, string Scene){
		print ("Take me to: " + Scene);
		yield return new WaitForSeconds(waitTime);
		SceneManager.LoadScene (Scene);
	}
}
