using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CameraViewControl : MonoBehaviour {

	public GameObject player;
	public GameObject playerIndicator;
	public GameObject mapCamera;
	public GameObject povCamera;
	public GameObject land;

	public GameObject povUI;
	public GameObject mapUI;

	public bool povMode = false;

	//public GameObject[] tileSelects;
	// Use this for initialization
	void Start () {
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
	}

	public void ModeSetup () {
		if (povMode == true) {
			//land.layer = 0;

			playerIndicator.SetActive (false);
			povUI.SetActive (true);
			mapUI.SetActive (false);
			povCamera.SetActive (true);
			mapCamera.SetActive (false);

			player.GetComponent<MouseLook> ().enabled = true;
			player.GetComponent<CharacterMotorC> ().enabled = true;
			player.GetComponent<FPSInputControllerC> ().enabled = true;

			Debug.Log ("POV Mode Enabled");

		} else {
			//land.layer = 2;

			playerIndicator.SetActive (true);
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
