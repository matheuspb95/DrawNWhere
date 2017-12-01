using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class OnCollisionDraw : MonoBehaviour, ITrackableEventHandler {
	Vector2 LastPos;
	public DrawingObject drawTarget;
	public Transform pen;
	private TrackableBehaviour mTrackableBehaviour;
    void ITrackableEventHandler.OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
    }

	void OnTrackingFound(){
		enabled = true;
	}

	void OnTrackingLost(){
		LastPos = Vector2.zero;
		enabled = false;
	}
	// Use this for initialization
    void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
        	mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
	}	
	
	// Update is called once per frame
	void Update () {		
		float y = pen.localScale.y;
		Ray ray = new Ray(pen.position + pen.up *  (y / 2), -pen.up * y);
		Debug.DrawRay(pen.position + pen.up * (y / 2), -pen.up * y);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, y)){
			print(hit.collider.gameObject);
			Vector2 actPos = hit.textureCoord;
			if(drawTarget == null)
				drawTarget = hit.collider.GetComponent<DrawingObject>();
			if(drawTarget == null){
				print("No drawable");
				return;
			}
			if(LastPos == Vector2.zero)
				drawTarget.DrawPixel(actPos.x, actPos.y);
			else
				drawTarget.DrawLine(LastPos, actPos);
			LastPos = actPos;
		} else {			
			LastPos = Vector2.zero;
		}
	}
}
