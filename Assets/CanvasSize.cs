using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSize : MonoBehaviour {
	public Vector2 size;
	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(size.x * 0.01f, 1, size.y * 0.01f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
