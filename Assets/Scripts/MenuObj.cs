//========================================================================================
//
// Written by: Johan Gustafsson & Minh Le Tran
//
//
// Public functions:
//  executeMenuObj() 			
// 


using UnityEngine;
using System.Collections;


public class MenuObj : MonoBehaviour {


	public GameObject TV;		 		// target TV
	public GameObject slider;			// slider that handles light/color adjustments
	public Light light;					// target ligth object
//	private SceneChanger changeScene;

	void Start() {
//		changeScene = GetComponentInParent<SceneChanger> ();
//		Debug.Log ("SCENE CHANGER: " + changeScene);
	}


	public void executeMenuObj()
	{
		switch (this.name) 
		{
		case "MenuObj1":
			Debug.Log ("Toggle TV1 Button");
			TV.GetComponent<MoviePlayer> ().toggleTV ();
			break;
		case "MenuObj2":
			Debug.Log ("Toggle TV2 Button");
			TV.GetComponent<MoviePlayer> ().toggleTV ();
			break;
		case "MenuObj3":
			Debug.Log ("Light Adjustment Button");
			slider.GetComponent<LightColorController> ().toggleLightColorController ();
			slider.GetComponentInChildren<LightController> ().setLight (light);
			foreach (ColorController cc in slider.GetComponentsInChildren<ColorController>()) {
				cc.setLight (light);
			}
			break;
		case "MenuObj4":
			Debug.Log ("Sun Adjustment Button");
			slider.GetComponent<LightColorController> ().toggleLightColorController ();
			slider.GetComponentInChildren<LightController> ().setLight (light);
			foreach (ColorController cc in slider.GetComponentsInChildren<ColorController>()) {
				cc.setLight (light);
			}
			break;
		case "GoHome":
			Debug.Log ("Take Me Home!");
//			changeScene.ChangeScene ("MyScene");
			GetComponentInParent<Menu>().sceneChanger.ChangeScene("MyScene");
			break;
		default :
			Debug.Log ("FAIL!!!");
			break;
		}
	}
}
