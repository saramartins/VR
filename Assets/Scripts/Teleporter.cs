using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	public Transform marker;
	public Transform player;
	public float laserRange = 20f;
	private int lengthOfLineRenderer = 300;

	bool yZeroNotFound = true;

	LineRenderer lineRenderer;
	LineRenderer menuLineRenderer;

	public Material lime;
	public Material red;

	ControllerAbstractionLayer controller;

	private GameObject hitPoint;

	private void enablePointer(bool enable)
	{
		lineRenderer.enabled = enable;
		marker.GetComponent<MeshRenderer> ().enabled = enable;
	}

	// Parabolic motion equation, y = p0 + v0*t + 1/2at^2
	private static float ParabolicCurve(float p0, float v0, float a, float t)
	{
		return p0 + v0 * t + 0.5f * a * t * t;
	}

	// Parabolic motion equation applied to 3 dimensions
	private static Vector3 ParabolicCurve(Vector3 p0, Vector3 v0, Vector3 a, float t)
	{
		Vector3 ret = new Vector3();

		for (int x = 0; x < 3; x++)
			ret[x] = ParabolicCurve(p0[x], v0[x], a[x], t);
		return ret;
	}

	// Use this for initialization
	void Start () {		
		controller = this.GetComponent<ControllerAbstractionLayer>();

		// Initialize teleport pointer line
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.01F, 0.01F);
		lineRenderer.SetVertexCount(lengthOfLineRenderer);

		hitPoint = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		hitPoint.transform.SetParent (transform,false);
		hitPoint.transform.localScale = new Vector3 (0.02f, 0.02f, 0.02f);
		hitPoint.transform.localPosition = new Vector3 (0.0f, 0.0f, 100f);
		hitPoint.SetActive (false);
		hitPoint.GetComponent<SphereCollider> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		lineRenderer = GetComponent<LineRenderer>();

		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(c1, c2);
		lineRenderer.SetWidth(0.01F, 0.01F);
		lineRenderer.SetVertexCount(lengthOfLineRenderer);

		int i = 0;		
		if (controller.isTouch()) 
		{
			enablePointer (true);
			while (i < lengthOfLineRenderer) {
				Vector3 pos = ParabolicCurve (transform.position, transform.forward, Vector3.down * 0.5F, 0.02F * i);
				lineRenderer.SetPosition (i, pos);

				if ((pos.y < 0) && yZeroNotFound) 
				{
					marker.position = new Vector3 (pos.x, 0.01F, pos.z);
					yZeroNotFound = false;

					if ((-0.9 > pos.z) && (pos.z > -9.5) && (-0.6 > pos.x) && (pos.x > -7.9)) 
					{
						if (controller.isTouchDown()) 
						{
							SteamVR_Render.Top().origin.position = (SteamVR_Render.Top().origin.position - player.position) + new Vector3 (pos.x, player.position.y, pos.z);
						}
						marker.GetComponent<MeshRenderer> ().material = lime;
					} 
					else 
					{
						marker.GetComponent<MeshRenderer> ().material = red;
					}
				}	
				i++;
			}
			yZeroNotFound = true;
		} 
		else 
		{
			enablePointer (false);
		}
	}
}
