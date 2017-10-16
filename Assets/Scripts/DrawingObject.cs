using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawingObject : MonoBehaviour {
	public int ResolutionQuality;
	private int width, height;
	public int size;
	private Texture2D texture;
	Camera main;
	Vector2 LastPosMouse;
	// Use this for initialization
	void Start () {
		width = (int)(transform.localScale.x * ResolutionQuality);

		height = (int)(transform.localScale.y * ResolutionQuality);
		texture = new Texture2D(width, height);		
		GetComponent<Renderer>().sharedMaterial.mainTexture = texture;

		main = Camera.main;

		//DrawLine(Vector2.zero, Vector2.one);
	}
	
	// Update is called once per frame
	void Update () {
		/* 
		if(Input.GetMouseButtonUp(0)){
			LastPosMouse = Vector2.zero;
		}
		*/
		if(Input.GetMouseButton(0)){
			/* 
			RaycastHit hit;
			if(Physics.Raycast(main.ScreenPointToRay(Input.mousePosition), out hit, 10000)){
				//print("hey");
				Vector2 pixelUV = hit.textureCoord;
				if(LastPosMouse == Vector2.zero)
					DrawPixel(pixelUV.x, pixelUV.y);
				else	
					DrawLine(LastPosMouse, pixelUV);
				LastPosMouse = pixelUV;	
			}
			*/
			ClearCanvas();
		}
	}

	public void ClearCanvas(){
		for(int i = 0; i < width; i++){
			for(int j = 0; j < height; j++){
				texture.SetPixel(i, j, Color.white);
			}
		}
		texture.Apply();
	}

	public void DrawPixel(float x, float y){
		x *= texture.width;
		y *= texture.height;

		int offset = size / 2;
		for(int i = 0; i < size; i++){
			for(int j = 0; j < size; j++){
				texture.SetPixel((int)x - offset + i, (int)y - offset + j, Color.black);
			}
		}
	}

	public void DrawLine(Vector2 init, Vector2 end){
		int divs = (int)(Vector2.Distance(init, end) * width);
		float diffX = end.x - init.x;
		float diffY = end.y - init.y;
		float propx = diffX / divs;
		float propy = diffY / divs;

		for(int i = 0; i < divs; i++){
			DrawPixel(init.x + propx * i, init.y + propy * i);
		}
		texture.Apply();
	}
}
