using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetColorFromSliders : MonoBehaviour {
	public Slider red, green, blue, size;
	Image image;

	Color color;

	public DrawingObject canvas;
	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		color = new Color(red.value, green.value, blue.value);
		image.color = color;
	}

	public void getValues(){
		size.value = canvas.size;
		red.value = canvas.penColor.r;
		green.value = canvas.penColor.g;
		blue.value = canvas.penColor.b;
		if(image == null)
			image = GetComponent<Image>();
		image.color = canvas.penColor;
	}

	public void SetNewColor(){
		canvas.penColor = color;
		canvas.size = (int)size.value;
	}
}
