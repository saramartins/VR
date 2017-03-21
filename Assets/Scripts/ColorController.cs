using UnityEngine;
using System.Collections;

public class ColorController : MonoBehaviour {

	public Light light;
	public GameObject controllerRight;
	public bool pickedUp;

	private float sliderMax = 1.6f;
	private float sliderMin = 1.4f;

	// Use this for initialization
	void Start () {
		this.transform.localPosition = new Vector3 (0f,0f,0f);
		pickedUp = false;
	}

	// Update is called once per frame
	void Update () {

		if (light.enabled) 
		{

			if (pickedUp) 
			{

				Vector3 tempPos = controllerRight.GetComponent<ControllerAbstractionLayer> ().getPosition ();
				Vector3 tempVel = controllerRight.GetComponent<ControllerAbstractionLayer> ().getVelocity ();
				//				Debug.Log (tempVel);
				Debug.Log (this.transform.position);

//				tempPos


				if (((this.transform.position.y > sliderMin) && (this.transform.position.y < sliderMax)) 	||
					((this.transform.position.y <= sliderMin) && (tempVel.y > 0 )) 							||
					((this.transform.position.y >= sliderMax) && (tempVel.y < 0 ))) {

					if(tempPos.y < sliderMax && tempPos.y > sliderMin) //<< UGLY AS HELL, but works!
						this.transform.position = new Vector3 (this.transform.position.x, tempPos.y, this.transform.position.z);

					Debug.Log ("1");
				}

				switch (this.name) {

				case "SliderR":
					Debug.Log ("Red");
					light.color =  new Color(((this.transform.position.y - sliderMin) * 1/(sliderMax-sliderMin)), light.color.g, light.color.b, light.color.a);
					break;
				case "SliderG":
					Debug.Log ("Green");
					light.color =  new Color(light.color.r, ((this.transform.position.y - sliderMin) * 1/(sliderMax-sliderMin)), light.color.b, light.color.a);
					break;
				case "SliderB":
					Debug.Log ("Blue");
					light.color =  new Color(light.color.r, light.color.g, ((this.transform.position.y - sliderMin) * 1/(sliderMax-sliderMin)), light.color.a);
					break;
				default:
					break;
				}
			}
		}
		else 
		{


		}
	}

	public void setLight (Light _light) {
		light = _light;
	}
}

