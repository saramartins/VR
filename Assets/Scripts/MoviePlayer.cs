using UnityEngine;
using System.Collections;

public class MoviePlayer : MonoBehaviour {
	
    public MovieTexture movTexture;
	public Texture blackScreen;
	private bool tvOn = false;

    void Start() {
		GetComponent<Renderer>().material.mainTexture = blackScreen;
		tvOn = false;
    }

	private void StartTV()
	{
		GetComponent<Renderer>().material.mainTexture = movTexture;
		movTexture.loop = true;
		movTexture.Play();
		tvOn = true;
		GetComponentInParent<AudioSource>().Play();
	}

	private void StopTV()
	{
		movTexture.Stop();
		GetComponent<Renderer>().material.mainTexture = blackScreen;
		tvOn = false;
		GetComponentInParent<AudioSource> ().Stop ();
	}

	public void toggleTV()
	{
		if (tvOn) {
			StopTV ();
			Debug.Log ("Stop TV. tvOn = " + tvOn);
		} else {
			StartTV ();
			Debug.Log ("Start TV. tvOn = " + tvOn);
		}
	}


}