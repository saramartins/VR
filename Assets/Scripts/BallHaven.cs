//// ===========================
// 
// 
// Written by: Cornelis Christensson & Johan Gustafsson
// 
// public functions:
// 	initBallHaven()
//

using UnityEngine;
using System.Collections;

public class BallHaven : MonoBehaviour {

	public PhysicMaterial bounce;


	public void initBallHaven()
	// creates and spawns 100 balls on random locations
	{
//		for (int i = 0; i < 100; i++)
//		{
//			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//			sphere.AddComponent<Rigidbody>();
//			sphere.GetComponent<Rigidbody> ().mass = 100F;
//			//sphere.GetComponent<Rigidbody> ().drag = 10;
//			sphere.AddComponent<SphereCollider>();										// in order to make it grabbable
//			sphere.GetComponent<SphereCollider>().material = bounce;					// make it bounce
//
//			Material color4 = new Material(Shader.Find("Standard"));
//			color4.color = new Color(Random.Range(0,1F),Random.Range(0,1F),Random.Range(0,1F),1F);
//			sphere.GetComponent<MeshRenderer> ().material = color4;
//
//			sphere.tag = "Grabbable";
//			sphere.transform.localScale = new Vector3 (0.4F, 0.4F, 0.4F);
//
//			sphere.transform.position = new Vector3(Random.Range(-8F, -2F), Random.Range(0.3F,1), Random.Range(-6F, -2F));
//		}
		for (int i = 0; i < 100; i++)
		{
			GameObject cap = GameObject.CreatePrimitive(PrimitiveType.Capsule);
			cap.AddComponent<Rigidbody>();
			cap.GetComponent<Rigidbody> ().mass = 100F;
			cap.AddComponent<CapsuleCollider>();										// in order to make it grabbable
			cap.GetComponent<CapsuleCollider>().material = bounce;					// make it bounce

			Material color4 = new Material(Shader.Find("Standard"));
			color4.color = new Color(Random.Range(0,1F),Random.Range(0,1F),Random.Range(0,1F),1F);
			cap.GetComponent<MeshRenderer> ().material = color4;

			cap.tag = "Grabbable";
			cap.transform.localScale = new Vector3 (0.4F, 0.4F, 0.4F);

			cap.transform.position = new Vector3(Random.Range(-8F, -2F), Random.Range(0.3F,1), Random.Range(-6F, -2F));
//			cap.transform.position = new Vector3(-4, 20, -3);

			StartCoroutine (wait ());

		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (10);
	}
}
