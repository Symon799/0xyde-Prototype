using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision c)
	{
		rigidbody.isKinematic = true;
		renderer.enabled = false;


		if (c.collider.gameObject.CompareTag("Zombie"))
		{
			GameObject go = GameObject.Find ("Zombie");
			mAI other = (mAI)go.GetComponent (typeof(mAI));
			other.hurt();
		}
		Destroy (gameObject, 0.3f);
	}
}
