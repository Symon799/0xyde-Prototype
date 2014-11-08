using UnityEngine;
using System.Collections;

public class mAI : MonoBehaviour {

	public Transform leader;
	public float maxDistance = 7;
	public float minDistance = 2;
	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Freeze Y axis
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

		AI ();
	}

	void AI () 
	{
		if (Vector3.Distance (transform.position, leader.position) >= minDistance) 
		{
			GetComponent<NavMeshAgent> ().destination = leader.position;
			anim.Play ("walk03");
		}
		else
		{
			GetComponent<NavMeshAgent> ().ResetPath();
			attack();
		}
	}

	void attack()
	{
		anim.Play ("atack01");
	}
}
