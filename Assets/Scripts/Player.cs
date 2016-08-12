using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Player : Character {

	public GameObject power;
	public int count = 0;
	private Text theText;
	public GameObject healthbar;
	public float currentwidth;
	private static Player instance;
	public static Player Instance
	{
		get
		{
			if(instance == null)
			{instance = GameObject.FindObjectOfType<Player>();}
			return instance;
		}
	}
	public int score = PlayerPrefs.GetInt("score");
	[SerializeField]
	private Transform[] groundPoints;
	[SerializeField]
	private float groundRadius;
	[SerializeField]
	private LayerMask whatIsGround;
	[SerializeField]
	private float jumpForce;
	[SerializeField]
	private bool airControl;
	public Rigidbody2D MyRigidbody{ get; set;}
	public bool Jump{ get; set;}
	public bool Slide{ get; set;}
	public bool OnGround{ get; set;}

	public override bool IsDead
	{
		get
		{
			return health <= 0;
		}
	}

	// Use this for initialization
	public override void Start () {
		base.Start ();
		MyRigidbody = GetComponent<Rigidbody2D> ();
		GameObject.Find ("powerpack").transform.localScale = new Vector3(0, 0, 0);
		//Debug.Log ("score is:"+ PlayerPrefs.GetInt("score"));
	}
	
	// Update is called once per frame
	void Update()
	{	
		currentwidth = healthbar.GetComponent<RectTransform> ().sizeDelta.x ;
		if (!TakingDamage && !IsDead) 
		{
			HandleInput ();
		}
	}
	void FixedUpdate () {
		if (!TakingDamage && !IsDead) 
		{
			float horizontal = Input.GetAxis ("Horizontal");
			OnGround = IsGrounded ();
			HandleMovement (horizontal);
			Flip (horizontal);
			HandleLayers ();
			PowerPacks();
		}
	}

	private void HandleMovement(float horizontal)
	{
		if (MyRigidbody.velocity.y < 0) {
			MyAnimator.SetBool("land",true);
		}
		if (!Attack && (OnGround || airControl) && !this.MyAnimator.GetBool("slide")) {
			MyRigidbody.velocity = new Vector2(horizontal * movementSpeed,MyRigidbody.velocity.y);
		}
		if (Jump && MyRigidbody.velocity.y == 0) {
			MyRigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
			//MyRigidbody.velocity = new Vector2(horizontal * 10,MyRigidbody.velocity.y);
		//	MyRigidbody.AddForce(new Vector2(0,jumpForce));
		//	MyRigidbody.velocity = new Vector2(5,MyRigidbody.velocity.y);
		}

		if (Slide && !this.MyAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Slide")) 
		{
			MyAnimator.SetBool("slide",true);
		}
		else if (!this.MyAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Slide")) 
		{
			MyAnimator.SetBool("slide",false);
		}
		MyAnimator.SetFloat ("speed",Mathf.Abs(horizontal));
	}

	private void HandleInput()
	{
		if (Input.GetKeyDown (KeyCode.Z) || Input.GetKeyDown (KeyCode.A)) 
		{
			MyAnimator.SetTrigger("attack");
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			MyAnimator.SetTrigger("jump");
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			MyAnimator.SetBool("slide",true);
		}
		if (Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown (KeyCode.B)) 
		{
			MyAnimator.SetTrigger("throw");
			ThrowKnife(0);
		}
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = count.ToString();
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			if(count == 9)
			{

				count = 0;
			}
			else
			{
				Debug.Log ("display");
				count = count + 1;
			}
			StartCoroutine(PowerLayers ());
		}
	}

	private void PowerPacks()
	{
		if (Input.GetKeyDown (KeyCode.Alpha0)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "0";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "1";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "2";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "3";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "4";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "5";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "6";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha7)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "7";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha8)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "8";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
		if (Input.GetKeyDown (KeyCode.Alpha9)) 
		{
			GameObject.Find("powerpack").GetComponent<Text>().text = "9";
			GameObject.Find ("powerpack").transform.localScale = new Vector3(1 ,1 ,1);
			StartCoroutine(PowerLayers ());
		}
	}
	IEnumerator PowerLayers()
	{
		yield return new WaitForSeconds(5);
		GameObject.Find ("powerpack").transform.localScale = new Vector3(0, 0, 0);
	}
	private void Flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) 
		{
			Changedirection();
		}
	}

	private bool IsGrounded()
	{
		if (MyRigidbody.velocity.y <= 0) 
		{
			foreach(Transform point in groundPoints)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position,groundRadius, whatIsGround);
				for(int i=0; i<colliders.Length;i++)
				{
					if(colliders[i].gameObject != gameObject)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private void HandleLayers()
	{
		if (!OnGround) {
			MyAnimator.SetLayerWeight (1, 1);
		} 
		else 
		{
			MyAnimator.SetLayerWeight (1, 0);
		}
	}

	public override void ThrowKnife(int value)
	{
		if (!OnGround && value == 1 || OnGround && value == 0) 
		{
			base.ThrowKnife(value);
		}
	}

	public override IEnumerator TakeDamage()
	{
		health -= 10;
		healthbar.GetComponent<RectTransform> ().sizeDelta = new Vector2(currentwidth - 30 , 100);

		score = PlayerPrefs.GetInt ("score");
		if(score == 0){}
		else { score = score - 10; }
		PlayerPrefs.SetInt("score", score);

		if (!IsDead) {
			MyAnimator.SetTrigger ("Damage");
			Destroy (GameObject.FindWithTag("EnemyKnife"));
		} 
		else 
		{
			MyAnimator.SetLayerWeight(1,0);
			MyAnimator.SetTrigger("die");

			yield return new WaitForSeconds (3);
			Application.LoadLevel(4);
			Destroy (GameObject.FindWithTag("EnemyKnife"));
		}
		yield return null;
	}
}
