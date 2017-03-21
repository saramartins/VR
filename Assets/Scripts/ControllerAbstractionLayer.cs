using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]

public class ControllerAbstractionLayer : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	private SteamVR_Controller.Device device;

	public Material tex1; 
	public Material tex2; 

	private Material defaultMaterial;

	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		device = SteamVR_Controller.Input ((int)trackedObj.index);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public bool isTriggerButtonDown()
	{
		//return device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger);
		return device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger);
	}

	public bool isTriggerButtonReleased()
	{
		return device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger);
	}

	public bool isTouch()
	{
		return device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad);
	}

	public bool isTouchDown()
	{
		return device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad);
	}

	public bool isPressUp()
	{
		return device.GetPressUp (SteamVR_Controller.ButtonMask.Grip);
	}

	public void triggerHapticPulse(ushort time)
	{
		device.TriggerHapticPulse(time,Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);	
	}

	public void setColorNew()
	{
		trackedObj.GetComponentInChildren<MeshRenderer> ().material = tex1;
	}

	public void setColorDefault()
	{
		trackedObj.GetComponentInChildren<MeshRenderer> ().material = tex2;
	}

	public Vector3 getPosition (){

		return trackedObj.transform.position;
	}

	public Vector3 getVelocity (){
		return device.velocity;
	}

	public Vector3 getAngularVelocity (){
		return device.angularVelocity;
	}

	public SteamVR_TrackedObject getTrackedObj() {
		return trackedObj;
	}
}

