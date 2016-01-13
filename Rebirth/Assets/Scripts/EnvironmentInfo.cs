using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnvironmentInfo: MonoBehaviour {

	public GameObject DayNight;
	private Vector3 playerDirection;
	private float direction;
	private float compassDirection;

	public Vector3 playerPosition;

	public GameObject player;
	public GameObject compassNeedle;
	public Text compass;
	public Text theTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PrintDirection ();
		PrintTime ();
		compassDirection = compassNeedle.transform.eulerAngles.y;
		playerDirection = player.transform.localEulerAngles;
		direction = Mathf.Round(player.transform.localEulerAngles.y);
		playerPosition = player.transform.position;
		if (Input.GetKeyDown (KeyCode.D)) {
			Debug.Log (playerDirection.ToString ());
			Debug.Log (direction.ToString ());
			Debug.Log (playerPosition.ToString ());

		}


	}

	void CompassRotate() {
		compassDirection == direction;
	}

	void PrintTime () {

		if (DayNight.GetComponent<DayNightCycle>().currentTimeOfDay <= 0.23f || DayNight.GetComponent<DayNightCycle>().currentTimeOfDay >= 0.75f) {
			theTime.text = "night";

		} 
		else if (DayNight.GetComponent<DayNightCycle>().currentTimeOfDay <= 0.25f) {
			theTime.text = "sunrise";

		} 
		else if (DayNight.GetComponent<DayNightCycle>().currentTimeOfDay >= 0.73f) {
			theTime.text = "sunset";
		} 
		else if (DayNight.GetComponent<DayNightCycle>().currentTimeOfDay <= 0.73f || DayNight.GetComponent<DayNightCycle>().currentTimeOfDay >= 0.25f) {
			theTime.text = "day";

		} 
	}

	void PrintDirection () {
		if (direction >= 315 || direction <= 44) {
			compass.text = "N";
			if (Input.GetKeyDown (KeyCode.D)) {
				Debug.Log ("north");
			}
		} 
		else if (direction >= 45 || direction <= 134) {
			compass.text = "E";
			if (Input.GetKeyDown (KeyCode.D)) {
				Debug.Log ("east");
			}
		} 
		else if (direction >= 135 || direction <= 224) {
			compass.text = "S";
			if (Input.GetKeyDown (KeyCode.D)) {
				Debug.Log ("south");
			}
		} 
		else if (direction >= 225 || direction <= 314) {
			compass.text = "W";
			if (Input.GetKeyDown (KeyCode.D)) {
				Debug.Log ("west");
			}
		}
	}
}
