using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelSetUp : MonoBehaviour {

	public GameObject invasiveReedSpecies;
	public GameObject trash;

	private GameObject reedSpot;
	private GameObject trashSpot;

	public List<GameObject> marshList = new List<GameObject>();
	public List<GameObject> reedSpotList = new List<GameObject> ();
	public List<GameObject> trashSpotList = new List<GameObject> ();


	public int marshListLength;

	// Use this for initialization
	void Start () {
		marshList.AddRange(GameObject.FindGameObjectsWithTag ("marsh"));
		marshListLength = marshList.Count;
		Debug.Log (marshListLength.ToString () + "marsh cubes");
		for (int i = 0; i < 5; i++) {
			ReedPlacement ();
			Debug.Log ("placing reed");
		}
		marshList.Clear ();
		marshList.AddRange(GameObject.FindGameObjectsWithTag ("marsh"));

		for (int i = 0; i < 10; i++) {
			TrashPlacement ();
			Debug.Log ("placing trash");
		}
	}
	
	// Update is called once per frame
	void Update () {
		marshListLength = marshList.Count;

		if (Input.GetKeyDown (KeyCode.Q)) {
			Debug.Log (marshListLength.ToString () + "marsh cubes");
		}
	}

	void ReedPlacement () {
		marshListLength = marshList.Count;
		int marshIndex = Mathf.FloorToInt (Random.value * (float)marshListLength);
		Debug.Log (marshIndex.ToString () + " is the marsh index");
		reedSpot = marshList [marshIndex];
		marshList.RemoveAt (marshIndex);
		reedSpotList.Add (reedSpot);
		marshListLength = marshList.Count;

		Vector3 position = new Vector3(reedSpot.transform.position.x, 0, reedSpot.transform.position.z);
		Instantiate (invasiveReedSpecies, position, Quaternion.identity);
	
	}
	void TrashPlacement () {
		marshListLength = marshList.Count;

		int marshIndex = Mathf.FloorToInt (Random.value * (float)marshListLength);
		Debug.Log (marshIndex.ToString () + " is the marsh index");
		trashSpot = marshList [marshIndex];
		marshList.RemoveAt (marshIndex);
		trashSpotList.Add (trashSpot);
		marshListLength = marshList.Count;

		Vector3 position = new Vector3(trashSpot.transform.position.x, 0, trashSpot.transform.position.z);
		Instantiate (trash, position, Quaternion.identity);

	}
}
