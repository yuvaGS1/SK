using UnityEngine;
using System.Collections;

public class CollisionTrigger : MonoBehaviour {
	private BoxCollider2D playerCollider;
	[SerializeField]
	private BoxCollider2D platformCollider;
	[SerializeField]
	private BoxCollider2D platformTrigger;
	// Use this for initialization
	void Start () {
		playerCollider = GameObject.Find ("Player").GetComponent<BoxCollider2D> ();
		Physics2D.IgnoreCollision (platformCollider,GetComponent<BoxCollider2D>(),true);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		Physics2D.IgnoreCollision (platformCollider,playerCollider,true);
	}
	void OnTriggerExit2D(Collider2D other)
	{
		Physics2D.IgnoreCollision (platformCollider,playerCollider,false);
	}
}
