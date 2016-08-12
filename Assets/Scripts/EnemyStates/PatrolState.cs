using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState 
{
	private Enemy enemy;
	private float patrolTimer;
	private float patrolDuration=5;

	public void Enter(Enemy enemy)
	{
		this.enemy = enemy;
	}
	
	public void Execute()
	{
		Debug.Log ("Patroling");
		Patrol ();
		enemy.Move ();

		if (enemy.Target != null) 
		{
			enemy.ChangeState(new RangedState());
		} 
	}
	
	public void Exit()
	{
	}
	
	public void OnTriggerEnter(Collider2D other)
	{
		if (other.tag == "Edge") 
		{
			enemy.Changedirection();
		}
	}

	private void Patrol()
	{
		enemy.MyAnimator.SetFloat ("speed",0);
		patrolTimer += Time.deltaTime;
		if (patrolTimer >= patrolDuration) 
		{
			enemy.ChangeState(new IdleState());
		}
	}
}
