using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	int currentHealth;
	public int health = 1;
	public float ySpeed = 7.5f;
	SpriteRenderer sprite;
	BoxCollider2D boxCollider;
	Rigidbody2D body;
	public int points = 1;
	public float xAmplitude;
	
	// Use this for initialization
	void Start () 
	{
		sprite = GetComponent<SpriteRenderer>();
		body = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
		body.velocity = new Vector2(0,-ySpeed);
		currentHealth = health;
	}


	protected virtual void attack()
	{

	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.gameObject.tag == "Bullet")
		{
			Destroy(other.gameObject);
			currentHealth--;
			if(currentHealth<=0)die();
			else 
			{
				float colorDamageRatio = (float)currentHealth/(float)health-0.2f;
				print(colorDamageRatio);
				sprite.color = new Color(1,colorDamageRatio,colorDamageRatio);
				StartCoroutine(flash());
			}
		}
		if(other.gameObject.tag == "Player")
		{
			Player player =  other.GetComponent<Player>();
			if(!player.isInvencible)
			{
				player.die();
				die(); //Crashed against the player, this would kill it :(
			}
			
		}

	}

	void die()
	{
		GameMaster.scoreUp(this.points);
		//Play SFX
		SoundMaster.playSFX(SoundMaster.database.minionDeath);
		//Spawn Visual Effect
		GameObject effectPrefab = Resources.Load<GameObject>("Effects/DestroyEffect");
		Instantiate(effectPrefab,this.transform.position,Quaternion.identity);
		GameMaster.difficultyPoints++;
		Destroy(this.gameObject);
	}

	// Update is called once per frame
	void Update () 
	{
		checkEnemyDestruction();
		move();
		attack();
	}

	void move()
	{
		
		float x = Mathf.Cos(this.transform.position.y);
		
		body.velocity = new Vector2(x*xAmplitude,body.velocity.y);
	}

	IEnumerator flash()
	{
		for(float times = 0; times<2; times++)
		{
			// print(times);
			sprite.enabled=false;
			// yield return new WaitForEndOfFrame();
			yield return new WaitForSeconds(0.05f);
			sprite.enabled=true;
			yield return new WaitForSeconds(0.05f);
			// yield return new WaitForEndOfFrame();
		}
	}

	void checkEnemyDestruction()
	{
		if(this.transform.position.y < -8)Destroy(this.gameObject);
	}
}
