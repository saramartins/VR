using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	public Light light;
	public GameObject controllerRight;
	public bool pickedUp;

	private float sliderMax = 1.6f;
	private float sliderMin = 1.4f;

	// Use this for initialization
	void Start () {
		this.transform.localPosition = new Vector3 (0f,0f,0f);
		light.intensity = 1;
		pickedUp = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (light.enabled) {

			if (pickedUp) {
			
				Vector3 tempPos = controllerRight.GetComponent<ControllerAbstractionLayer> ().getPosition ();
				Vector3 tempVel = controllerRight.GetComponent<ControllerAbstractionLayer> ().getVelocity ();

				if (((this.transform.position.y > sliderMin) && (this.transform.position.y < sliderMax)) 	||
					((this.transform.position.y <= sliderMin) && (tempVel.y > 0 )) 							||
					((this.transform.position.y >= sliderMax) && (tempVel.y < 0 ))) {

					if(tempPos.y < sliderMax && tempPos.y > sliderMin) //<< UGLY AS HELL, but works!
						this.transform.position = new Vector3 (this.transform.position.x, tempPos.y, this.transform.position.z);

				}
				light.intensity = (this.transform.position.y - sliderMin) * 4/(sliderMax-sliderMin);
			}
		} else {
		}
	}
		
	public void setLight (Light _light) {
		light = _light;
	}
}
