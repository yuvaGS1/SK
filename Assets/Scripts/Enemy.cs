using UnityEngine;
using System.Collections;
using System;

public class Enemy : Character
{
	private IEnemyState currentState;

	public GameObject Target { get; set; }

	public int score = PlayerPrefs.GetInt("score");
	
	[SerializeField]
	private float meleeRange;
	
	[SerializeField]
	private float throwRange;
	
	public bool InMeleeRange
	{
		get
		{
			if(Target != null)
			{
				return Vector2.Distance(transform.position, Target.transform.position) <= meleeRange ;
			}
			return false;
		}
	}
	
	public bool InThrowRange
	{
		get
		{
			if(Target != null)
			{
				return Vector2.Distance(transform.position, Target.transform.position) <= throwRange ;
			}
			return false;
		}
	}

	public override bool IsDead
	{
		get
		{
			return health <= 0;
		}
	}
	
	// Use this for initialization
	public override void Start()
	{
		base.Start ();
		ChangeState (new IdleState ());
	}
	
	
	// Update is called once per frame
	void Update () {
		if (!IsDead) 
		{
			if(!TakingDamage)
			{
				currentState.Execute ();
			}
			LookAtTarget ();
		}
	}
	
	private void LookAtTarget()
	{
		if (Target != null) 
		{
			float xDir = Target.transform.position.x - transform.position.x;
			if(xDir < 0 && facingRight || xDir > 0 && !facingRight)
			{
				Changedirection();
			}
		}
	}
	
	public void ChangeState(IEnemyState newState)
	{
		if (currentState != null) 
		{
			currentState.Exit();
		}
		currentState = newState;
		currentState.Enter (this);
	}
	
	public void Move()
	{
		if (!Attack) 
		{
			MyAnimator.SetFloat ("speed",1);
			transform.Translate (GetDirection() * (movementSpeed * Time.deltaTime));
		}

	}
	
	public Vector2 GetDirection()
	{
		return facingRight ? Vector2.right : Vector2.left;
	}
	
	public override void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D (other);
		currentState.OnTriggerEnter (other);
	}
	
	
	public override IEnumerator TakeDamage()
	{
		health -= 10;
		if (!IsDead) {
			score = PlayerPrefs.GetInt ("score");
			score = score + 10;
			PlayerPrefs.SetInt("score", score);
			MyAnimator.SetTrigger ("Damage");
			Destroy (GameObject.FindWithTag("Knife"));
		} 
		else 
		{
			MyAnimator.SetTrigger("die");
			yield return new WaitForSeconds (3);
			Application.LoadLevel(4);
			Destroy (GameObject.FindWithTag("Knife"));
		}
	}
}
