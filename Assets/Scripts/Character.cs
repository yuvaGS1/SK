using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class Character : MonoBehaviour {

	public Animator MyAnimator{ get; private set;}
	[SerializeField]
	protected GameObject knifePrefab;
	[SerializeField]
	private Transform knifePos;
	[SerializeField]
	protected float movementSpeed;
	protected bool facingRight;
	[SerializeField]
	protected int health;
	[SerializeField]
	private EdgeCollider2D swordCollider;
	[SerializeField]
	private List<string> damageSources;
	public abstract bool IsDead{ get; }
	public bool Attack{ get; set;}
	public bool TakingDamage{ get; set;}
	public int score;
	public EdgeCollider2D SwordCollider
	{
		get
		{
			return swordCollider;
		}
	}
	// Use this for initialization
	public virtual void Start () {
		facingRight = true;
		MyAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public abstract IEnumerator TakeDamage();

	public void Changedirection()
	{
		facingRight = !facingRight;
		transform.localScale = new Vector3 (transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
	}

	public virtual void ThrowKnife(int value)
	{
		if (facingRight) {
			GameObject tmp = (GameObject)Instantiate(knifePrefab,knifePos.position,Quaternion.Euler(new Vector3(0,0,-90)));
			tmp.GetComponent<Knife>().Initialize(Vector2.right);
		} 
		else 
		{
			GameObject tmp = (GameObject)Instantiate(knifePrefab,knifePos.position,Quaternion.Euler(new Vector3(0,0,90)));
			tmp.GetComponent<Knife>().Initialize(Vector2.left);
		}
	}

	public void MeleeAttack()
	{
		SwordCollider.enabled = true;
	}

	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (damageSources.Contains(other.tag)) 
		{
			StartCoroutine(TakeDamage());
		}
	}
	public virtual void ThrowBullet(int value)
	{
		if (facingRight) {
			GameObject tmp = (GameObject)Instantiate(knifePrefab,knifePos.position,Quaternion.Euler(new Vector3(0,0,0)));
			tmp.GetComponent<Knife>().Initialize(Vector2.right);
		} 
		else 
		{
			GameObject tmp = (GameObject)Instantiate(knifePrefab,knifePos.position,Quaternion.Euler(new Vector3(0,0,180)));
			tmp.GetComponent<Knife>().Initialize(Vector2.left);
		}
	}
}
