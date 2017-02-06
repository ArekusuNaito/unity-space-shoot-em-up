using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	SpriteRenderer sprite;
	Rigidbody2D body;
	Animator animator;
	public float xSpeed = 1.0f; //You move this units in one second
	public float ySpeed = 1.0f; //You move this units in one second
	Vector3 startPosition;
	bool isDead =false;
	public bool isInvencible = false;
	public float invencibilityTime = 1.5f;
	float invencibilityTimer;
	
	
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		sprite = GetComponent<SpriteRenderer>();
		body = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		startPosition = this.transform.position;
	}
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		move();
		checkShoot();
	}

	void checkShoot()
	{
		if(!isDead && Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bullet = Resources.Load<GameObject>("Bullets/Bullet1");
			Instantiate(bullet,this.transform.position,Quaternion.identity);
			SoundMaster.playSFX(SoundMaster.database.shootBullet1);
		}
	}
	void move()
	{
		resetVelocity();
		if(!isDead)
		{
			
			if(Input.GetKey(KeyCode.UpArrow))
			{
				body.velocity = new Vector2(body.velocity.x,ySpeed);
				// body.MovePosition(body.position + new Vector2(0,ySpeed) * Time.deltaTime);
			}
			if(Input.GetKey(KeyCode.DownArrow))
			{
				body.velocity = new Vector2(body.velocity.x,-ySpeed);
			}
			if(Input.GetKey(KeyCode.LeftArrow))
			{
				body.velocity = new Vector2(-xSpeed,body.velocity.y);
			}
			if(Input.GetKey(KeyCode.RightArrow))
			{
				body.velocity = new Vector2(xSpeed,body.velocity.y);
			}
		}
		
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.tag == "EnemyBullet")
		{
			Destroy(other.gameObject);
			die();
		}
	}
	

	public void die()
	{
		if(!isInvencible)
		{
			SoundMaster.playSFX(SoundMaster.database.playerDeath);
			animator.Play("PlayerDestroy");
			isInvencible=true;
			sprite.color = new Color(255,175,0);
			isDead=true;
			GameMaster.updateLives();
		}
		
	}


	IEnumerator flash()
	{
		for(float times = 0; times<16; times++)
		{
			// print(times);
			sprite.enabled=false;
			// yield return new WaitForEndOfFrame();
			yield return new WaitForSeconds(0.05f);
			sprite.enabled=true;
			yield return new WaitForSeconds(0.05f);
			// yield return new WaitForEndOfFrame();
		}
		isInvencible=false;
	}

	public void respawn()
	{
		if(GameMaster.playerLives>0)
		{
			sprite.enabled=true;
			sprite.color = new Color(255,255,255);
			this.transform.position = startPosition;
			isDead=false;
			StartCoroutine(flash());
		}
		else
		{
			GameMaster.gameOver();
			
			// Destroy(this.gameObject);
		}
	}

	void resetVelocity()
	{
		body.velocity = new Vector2(0,0);
	}
}
