using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class RaycastDraw : MonoBehaviour, ITrackableEventHandler {
	Vector2 LastPos;
	DrawingObject drawTarget;
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
		RaycastHit hit;
		//Vector3 direction = cam.transform.position - transform.position;
		float y = transform.localScale.y;
		Ray ray = new Ray(transform.position + transform.up *  (y / 2), -transform.up * y);
		Debug.DrawRay(transform.position + transform.up * (y / 2), -transform.up * y);
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
