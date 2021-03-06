﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Knife : MonoBehaviour {

	[SerializeField]
	private float speed;
	private Rigidbody2D myRigidbody;
	private Vector2 direction;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		myRigidbody.velocity = direction * speed;
	}

	void OnBecomeInvisible()
	{
		Destroy (gameObject);
	}

	public void Initialize(Vector2 direction)
	{
		this.direction = direction;
	}
	// Update is called once per frame

}
