using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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

//	public GameObject soil;
//	public GameObject sand;
//	public GameObject rock;
	//public GameObject oil;

	public List<GameObject> sandCubes = new List<GameObject>();
	public List<GameObject> soilCubes = new List<GameObject>();
	public List<GameObject> oilCubes = new List<GameObject>();
	public Color color;
	public Color soilColor;
	public Color rockColor;
	public Color sandColor;



	public int loopRandom;
	public int loopMin;
	public int loopMax;

	//public int oilIndex;
	public int soilIndex;
	public int sandCubesTotal;

	private GameObject oilCube;
	private GameObject soilCube;
	private GameObject sandCube;


	// Use this for initialization
	void Start () {
		sandCubes.AddRange(GameObject.FindGameObjectsWithTag ("Sand"));
		sandCubesTotal = sandCubes.Count;
		loopMax = 27;
		loopMin = 10;
		loopRandom = Random.Range (loopMin, loopMax);

		//for (int i = 0; i < loopRandom; i++) {
			OilSpillPlacement ();
			//SoilPlacement ();
		//}
		soilCubes.AddRange(GameObject.FindGameObjectsWithTag ("Soil"));
		//oilCubes.AddRange(GameObject.FindGameObjectsWithTag ("Oil"));

		Debug.Log (oilCubes.Count.ToString () + "oil cubes");
		Debug.Log (sandCubesTotal.ToString () + "sand cubes");

		ColorCubes ();

	}

	
	// Update is called once per frame
	void Update () {
		PrintDirection ();
		PrintTime ();
		CompassRotate ();


		//playerDirection = player.transform.localEulerAngles;
		direction = Mathf.Round(player.transform.localEulerAngles.y);
		playerPosition = player.transform.position;
		compassDirection = Mathf.Round(compassNeedle.transform.localEulerAngles.z);


		if (Input.GetKeyDown (KeyCode.R)) {
			Debug.Log (playerDirection.ToString ());
			Debug.Log (direction.ToString ());
			Debug.Log (playerPosition.ToString ());
			Debug.Log (compassDirection.ToString ());
			Debug.Log (sandCubes.Count.ToString ());
			Debug.Log (oilCubes.Count.ToString () + "oil cubes");
			Debug.Log (soilCubes.Count.ToString ());
			Debug.Log (loopRandom.ToString ());
			Debug.Log (sandCubesTotal.ToString () + "sand cubes");
			Debug.Log (oilCube.transform.position.ToString ());
			Debug.Log (soilIndex.ToString ());

		}
	}

	public void OilSpillPlacement () {
		//Random random = new Random ();
		int oilIndex = Mathf.FloorToInt(Random.value*(float)sandCubesTotal);
		Debug.Log (oilIndex.ToString () + " is the oil index");
		oilCube = sandCubes [oilIndex];
		sandCubes.RemoveAt (oilIndex);
		oilCube.tag = "Oil";
		oilCubes.Add (oilCube);



	}

	public void ColorCubes() {
		foreach (GameObject oilCube in oilCubes) {
			iTween.ColorTo (oilCube, iTween.Hash (
				"color", color
			));
			oilCube.GetComponent<TextureCreator>().frequency = 15;
			//Debug.Log ("oil colored");
		}
		foreach (GameObject soilCube in soilCubes) {
			iTween.ColorTo (soilCube, iTween.Hash (
				"color", soilColor
			));

			soilCube.GetComponent<TextureCreator>().frequency = 5;
		}
		foreach (GameObject sandCube in sandCubes) {
			iTween.ColorTo (sandCube, iTween.Hash (
				"color", sandColor
			));

			sandCube.GetComponent<TextureCreator>().frequency = 100;
		}
	}




	public void SoilPlacement () {
		soilIndex = Random.Range (0, sandCubesTotal);
		soilCube = sandCubes [soilIndex];
		soilCube.tag = "Soil";
		sandCubes.RemoveAt (soilIndex);
		soilCubes.Add (soilCube);
			
	}
	void CompassRotate() {
		compassDirection = direction;
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
		if (direction >= 45 && direction <= 134) {
			compass.text = "E";
			if (Input.GetKeyDown (KeyCode.D)) {
				Debug.Log ("east");
			}
		} 
		if (direction >= 135 && direction <= 224) {
			compass.text = "S";
			if (Input.GetKeyDown (KeyCode.D)) {
				Debug.Log ("south");
			}
		} 
		if (direction >= 225 && direction <= 314) {
			compass.text = "W";
			if (Input.GetKeyDown (KeyCode.D)) {
				Debug.Log ("west");
			}
		}
	}
}
