using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CameraViewControl : MonoBehaviour {

	private GameObject player;
	private GameObject playerIndicator;
	public GameObject mapCamera;
	public GameObject povCamera;
	public GameObject land;

	public GameObject povUI;
	public GameObject mapUI;

	public GameObject[] tiles;

	public List<GameObject> trashList = new List<GameObject>();
	public List<GameObject> reedList = new List<GameObject>();

	public BoxCollider[] reedCollider;
	public BoxCollider trashCollider;

	public bool povMode = false;

	//public GameObject[] tileSelects;
	// Use this for initialization
	void Start () {
		tiles = GameObject.FindGameObjectsWithTag ("Tile");
		playerIndicator = GameObject.Find ("PlayerIndicator");
		player = GameObject.Find ("First Person Controller");
		//tileSelects = GameObject.FindGameObjectsWithTag("Tile");
//		playerIndicator.SetActive (true);
//		povUI.SetActive (false);
//		mapUI.SetActive (true);
//		povCamera.SetActive (false);
//		mapCamera.SetActive (true);
//
//		player.GetComponent<MouseLook> ().enabled = false;
//		player.GetComponent<CharacterMotorC> ().enabled = false;
//		player.GetComponent<FPSInputControllerC> ().enabled = false;
//
//		Cursor.lockState = CursorLockMode.None;
		povMode = false;
		ModeSetup ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.M)) {
			ModeChange ();
			ModeSetup ();
			Debug.Log ("Mode Changed");
		}


	}

	public void ModeChange () {
		povMode = !povMode;
		foreach (GameObject tile in tiles) {
			tile.GetComponent<TileSelect> ().TileReference ();
//			Debug.Log ("checking tiles");
		}
	}

	public void ModeSetup () {
		if (povMode == true) {
			trashList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Trash"));
			//Debug.Log (trashList.Count + " " + levelSetup.GetComponent<LevelSetUp> ().trashSpotList.Count);
			reedList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Invasive"));
			//Debug.Log (reedList.Count + " " + levelSetup.GetComponent<LevelSetUp> ().reedSpotList.Count);
			foreach (GameObject reed in reedList) {
				reedCollider = reed.GetComponentsInChildren<BoxCollider> ();
				foreach (BoxCollider collider in reedCollider) {
					
					collider.enabled = true;
//					Debug.Log ("reed collider enabled");
				}
//				reed.GetComponent<BoxCollider>().enabled = true;
			}
			foreach (GameObject trash in trashList) {
				trash.GetComponent<BoxCollider>().enabled = true;
			}
			playerIndicator.GetComponent<Renderer> ().enabled = false;
			povUI.SetActive (true);
			mapUI.SetActive (false);
			povCamera.SetActive (true);
			mapCamera.SetActive (false);

			player.GetComponent<MouseLook> ().enabled = true;
			player.GetComponent<CharacterMotorC> ().enabled = true;
			player.GetComponent<FPSInputControllerC> ().enabled = true;

			Debug.Log ("POV Mode Enabled");

		} else {
			trashList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Trash"));
			//Debug.Log (trashList.Count + " " + levelSetup.GetComponent<LevelSetUp> ().trashSpotList.Count);
			reedList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Invasive"));
			//Debug.Log (reedList.Count + " " + levelSetup.GetComponent<LevelSetUp> ().reedSpotList.Count);
			foreach (GameObject reed in reedList) {
				reedCollider = reed.GetComponentsInChildren<BoxCollider> ();
				foreach (BoxCollider collider in reedCollider) {

					collider.enabled = false;
//					Debug.Log ("reed collider disabled");
				}
			}
			foreach (GameObject trash in trashList) {
				trash.GetComponent<BoxCollider>().enabled = false;
			}
			playerIndicator.GetComponent<Renderer> ().enabled = true;
			povUI.SetActive (false);
			mapUI.SetActive (true);
			povCamera.SetActive (false);
			mapCamera.SetActive (true);

			player.GetComponent<MouseLook> ().enabled = false;
			player.GetComponent<CharacterMotorC> ().enabled = false;
			player.GetComponent<FPSInputControllerC> ().enabled = false;

			Cursor.lockState = CursorLockMode.None;

			Debug.Log ("MAP Mode Enabled");
		}
	}
}
