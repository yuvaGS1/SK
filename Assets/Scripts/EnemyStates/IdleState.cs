﻿using UnityEngine;
using System.Collections;

public class IdleState : IEnemyState 
{
	private Enemy enemy;
	private float idleTimer;
	private float idleDuration=5;

	public void Enter(Enemy enemy)
	{
		this.enemy = enemy;
	}
	
	public void Execute()
	{
		Debug.Log ("I'm Idling");
		Idle ();

		if (enemy.Target != null) {
			enemy.ChangeState(new PatrolState());
		} 
	}
	
	public void Exit()
	{
	}
	
	public void OnTriggerEnter(Collider2D other)
	{
	}

	private void Idle()
	{
		enemy.MyAnimator.SetFloat ("speed",0);
		idleTimer += Time.deltaTime;
		if (idleTimer >= idleDuration) 
		{
			enemy.ChangeState(new PatrolState());
		}
	}
}
