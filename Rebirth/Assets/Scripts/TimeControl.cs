using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeControl : MonoBehaviour {

	// A time we use to make sure our input is framerate independent.
	float timer;
	float speedTime;
	private Coroutine timeChange;

	// A reference to the DayNightController script.
	DayNightCycle controller;

	void Awake() {
		// Find the DayNightController game object by its name and get the DayNightController script on it.
		controller = GameObject.Find("GameMaster").GetComponent<DayNightCycle>();
	}

	void Update() {

		if (Input.GetKeyDown (KeyCode.Delete)) {
			controller.timeMultiplier = 0f;
		}
		// Get the raw vertical axis input (W, S, Arrow key up and down by default).
		float input = Input.GetAxisRaw("Vertical");

		// Increase our timer.
		timer += Time.deltaTime;

		// If we pressed the W or Up-arrow key and our timer is higher than our
		// treshold increase the speed of our day night cycle.
//		if (input > 0 && timer > 0.01f) {
//			controller.timeMultiplier += 0.1f;
//			// Cap it to a sane value.
//			if (controller.timeMultiplier >= 50) {
//				controller.timeMultiplier = 50;
//			}
//			timer = 0;
//		}
//
//		// If we pressed the S or Down-arrow key and our timer is higher than our
//		// treshold decrease the speed of our day night cycle.
//		if (input < 0 && timer > 0.01f) {
//			controller.timeMultiplier -= 1f;
//			// Cap it to a sane value. I think the code handles negative values
//			// as well allowing you to rewind the day night cycle, but then it 
//			// would be harder to pause the day night cycle at will.
//			if (controller.timeMultiplier <= 0) {
//				controller.timeMultiplier = 0;
//			}
//			timer = 0;
//		}
	}

//	public void TimeChange(float wait) {
//		speedTime = controller.currentTimeOfDay + wait;
//		Debug.Log (speedTime);
//
//// If we pressed the W or Up-arrow key and our timer is higher than our
//// treshold increase the speed of our day night cycle.
//		for (int i = 0; i <= wait; i++) {
//			if (timer > 0.01f) {
//				controller.timeMultiplier += 1f;
//				// Cap it to a sane value.
//				if (controller.timeMultiplier >= 5) {
//					controller.timeMultiplier = 5;
//				}
//				timer = 0;
//			}
//		}
////
//// If we pressed the S or Down-arrow key and our timer is higher than our
//// treshold decrease the speed of our day night cycle.
////		if (timer > 0.01f) {
////			controller.timeMultiplier -= 1f;
////			// Cap it to a sane value. I think the code handles negative values
////			// as well allowing you to rewind the day night cycle, but then it 
////			// would be harder to pause the day night cycle at will.
////			if (controller.timeMultiplier <= 0) {
////				controller.timeMultiplier = 0;
////			}
////			timer = 0;
//	}

	public void TimeChange (float time) {

		if (timeChange == null) {
			timeChange = StartCoroutine (Speed (time));


		} 
	}

	public IEnumerator Speed(float wait)
	{
		speedTime = controller.currentTimeOfDay + wait;
		if (speedTime > 1) {
			speedTime = speedTime - 1.0f;
		}

		Debug.Log (controller.currentTimeOfDay + " starting, " + speedTime + " ending");

		controller.timeMultiplier = 0f;
//		float pace = Time.deltaTime / 0.5f;
//		float t = 0.0f;
//		for (t; t = wait; t + pace) {
		while (controller.currentTimeOfDay < speedTime) {
			Debug.Log (controller.currentTimeOfDay + " now, ending at" + speedTime);

//			Debug.Log (controller.currentTimeOfDay + ");
			if (timer > 0.01f) {
				// Cap it to a sane value.
				Debug.Log ("increasing speed to " + controller.timeMultiplier);
				if (controller.timeMultiplier < 5f) {
					controller.timeMultiplier += 1f;
				} else {
					controller.timeMultiplier = 5f;
					Debug.Log ("speed capped");
//					if (controller.timeMultiplier == 5f && t >= (wait - 0.5f) ) {
//						controller.timeMultiplier -= .1f;
//
//					}
				}

//				t += pace;
				yield return new WaitForEndOfFrame ();
			}

			yield return new WaitForEndOfFrame ();

//			if (controller.currentTimeOfDay == speedTime) {
//				Debug.Log ("speed up finished");
//				speedTime = 0;
//				timer = 0;
//				controller.timeMultiplier = 1f;
//				yield return new WaitForEndOfFrame ();
//			}
		}
		timer = 0;
		controller.timeMultiplier = 1f;

		controller.GetComponent<CameraViewControl>().ModeChange();
		Debug.Log ("change mode");
		Debug.Log (controller.GetComponent<CameraViewControl>().povMode);
		controller.GetComponent<CameraViewControl>().ModeSetup();
		Debug.Log ("setup mode");
		yield return new WaitForEndOfFrame ();

		timeChange = null;
	}
}
