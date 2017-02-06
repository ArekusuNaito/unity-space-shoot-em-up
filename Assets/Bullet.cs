using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float ySpeed = 10f;
	BoxCollider2D boxCollider;
	Rigidbody2D body;
	// Use this for initialization
	void Start () 
	{
		body = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
		body.velocity = new Vector2(0,ySpeed);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.y>7.5)Destroy(this.gameObject);
	}
}
