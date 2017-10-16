using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraConfig : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        var vuforia = VuforiaARController.Instance;
		vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
		vuforia.RegisterOnPauseCallback(OnPaused);
    }

	private void OnVuforiaStarted()
	{
   		if(CameraDevice.Instance.SetFocusMode(
        CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO)){
			print("OK");
		}else{
			print("Error");
		}
	}
	
	private void OnPaused(bool paused)
	{
		if (!paused) // resumed
		{
			// Set again autofocus mode when app is resumed
			CameraDevice.Instance.SetFocusMode(
				CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		}
	}
}
