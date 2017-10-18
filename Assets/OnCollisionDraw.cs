using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDraw : MonoBehaviour {
	Vector2 LastPos;
	DrawingObject drawTarget;
	// Use this for initialization
	void Start () {
		
	}	
	
	// Update is called once per frame
	void Update () {		
		float y = transform.localScale.y;
		Ray ray = new Ray(transform.position + transform.up *  (y / 2), -transform.up * y);
		Debug.DrawRay(transform.position + transform.up * (y / 2), -transform.up * y);
	}
}
