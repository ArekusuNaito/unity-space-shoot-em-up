using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour {

	public float scrollSpeed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Translate(new Vector2(0,-scrollSpeed) * Time.deltaTime);
		if(this.transform.position.y<-15)this.transform.position = new Vector2(0,0);
	}
}
