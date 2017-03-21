using UnityEngine;
using System.Collections;

public class LightColorController : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);

	}
		
	public void toggleLightColorController(){
		if (gameObject.activeSelf)
			gameObject.SetActive (false);
		else {
			gameObject.SetActive (true);
			this.transform.position = new Vector3(player.transform.position.x + 0.4f * player.transform.forward.x,1.5f,player.transform.position.z + 0.4f * player.transform.forward.z);
			this.transform.rotation = Quaternion.Euler (this.transform.rotation.eulerAngles.x,player.transform.rotation.eulerAngles.y,this.transform.rotation.eulerAngles.z);
		}
	}
}
