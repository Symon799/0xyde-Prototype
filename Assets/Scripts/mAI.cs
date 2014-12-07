using UnityEngine;
using System.Collections;

public class mAI : MonoBehaviour {

	public Transform leader;
	public float maxDistance = 8;
	public float minDistance = 2;
	private Animator anim;

	private int life = 1;

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

	private void AI () 
	{
		if (life > 0) 
		{
			if (Vector3.Distance (transform.position, leader.position) >= minDistance) 
			{
				walk();
			}
			else
			{
				attack();
			}
		}
	}

	/// <summary>
	/// Walk behaviour function
	/// </summary>
	private void walk()
	{
		// Initiate NavMesh agent
		GetComponent<NavMeshAgent> ().destination = leader.position;

		// Start walk motion
		anim.SetBool ("attack", false);
		anim.SetBool ("walk", true);

		Debug.Log("Walk");
	}

	/// <summary>
	/// Attack behaviour function
	/// </summary>
	private void attack()
	{
		// Stop NavMesh agent
		GetComponent<NavMeshAgent> ().ResetPath();

		// Start attack motion
		anim.SetBool ("attack", true);

		Debug.Log("Attack");
	}

	/// <summary>
	/// Remove 1 point of life to the zombie
	/// </summary>
	public void hurt()
	{
		life--;

		if (life <= 0) 
		{
			die ();
		}
		else
		{
			Debug.Log("Hurt");
		}
	}

	/// <summary>
	/// Remove the given point of live in parameter
	/// </summary>
	/// <param name="hurtPoint">Hurt point.</param>
	public void hurt(int hurtPoint)
	{
		life -= hurtPoint;

		if (life <= 0) 
		{
			die ();
		}
		else
		{
			Debug.Log("Hurt");
		}
	}

	/// <summary>
	/// Kill the zombie
	/// </summary>
	private void die()
	{
		// Stop NavMesh agent (unless you want self-moving bodies..)
		GetComponent<NavMeshAgent> ().ResetPath();

		// Start dead motion
		anim.SetBool ("alive", false);
		(gameObject.GetComponent(typeof(CapsuleCollider)) as CapsuleCollider).isTrigger = true;

		Debug.Log("You've been targeted for termination");
	}
}
