using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class TileSelect : MonoBehaviour, IPointerDownHandler, IResource {

	//public GameObject cameraControl;

	public GameObject player;
	public Camera mapCamera;
	public Vector3 tilePosition;
	public Vector3 playerPosition;
	public Color tileHighlight;
	public Color tileColor;

	public IResource resource;

	//public CameraViewControl mode;
	//public GameObject levelSetup;
//	private GameObject trashBehavior;
//	private GameObject invasiveBehavior;

	public List<GameObject> trashList = new List<GameObject>();
	public List<GameObject> reedList = new List<GameObject>();
	private bool reedPresent = false;
	private bool trashPresent = false;

	// Use this for initialization
	void Start () {
		
		iTween.ColorTo(gameObject, iTween.Hash(
			"color", tileColor,
			"time", .1f

		));
		tilePosition = this.transform.position;
		TileReference ();

	}
	
	// Update is called once per frame
	void Update () {
		//TileReference ();
	}

	public void TileReference () {
		reedPresent = false;
		trashPresent = false;
		trashList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Trash"));
		reedList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Invasive"));

		if (reedPresent == false) {
			foreach (GameObject reed in reedList) {
				if ((Mathf.Round (tilePosition.x)) == reed.transform.position.x && (Mathf.Round (tilePosition.z)) == reed.transform.position.z) {
//					Debug.Log ("THERE IS A REED ON ME");
					reedPresent = true;
				} else {
					reedPresent = false;
				}
				//reedFound = true;

			}
		}
		if (trashPresent == false) {
			foreach (GameObject trash in trashList) {
				if ((Mathf.Round (tilePosition.x)) == trash.transform.position.x && (Mathf.Round (tilePosition.z)) == trash.transform.position.z) {
//					Debug.Log ("THERE IS A TRASH ON ME");
					trashPresent = true;
				} else {
					trashPresent = false;
				}
				//trashFound = true;
			}
		}

	}

	public void Behavior () {
		TileReference ();
		if (trashPresent == true) {
			Debug.Log ("Trash Present");
		}
		if (reedPresent == true) {
			Debug.Log ("Reed Present");
		}
//		trashFound = false;
//		reedFound = false;
//		trashList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Trash"));
//		//Debug.Log (trashList.Count + " " + levelSetup.GetComponent<LevelSetUp> ().trashSpotList.Count);
//		reedList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Invasive"));
//		//Debug.Log (reedList.Count + " " + levelSetup.GetComponent<LevelSetUp> ().reedSpotList.Count);
//		tilePosition = this.transform.position;
//		Debug.Log (tilePosition);
//
////		mode.ModeChange ();
////		Debug.Log (mode.povMode);
//
		playerPosition = new Vector3(tilePosition.x, 10, tilePosition.z);
		player.transform.position = playerPosition;
		Debug.Log (player.transform.position);
		Debug.Log ("placing player");
//
//		foreach (GameObject reed in reedList) {
//			if (reedFound == false) {
////				Debug.Log ("checking for reeds...");
////				Debug.Log (reed.transform.position.x + " " + playerPosition.x);
////				Debug.Log (reed.transform.position.z + " " + playerPosition.z);
//				if ((Mathf.Round (playerPosition.x)) == reed.transform.position.x && (Mathf.Round (playerPosition.z)) == reed.transform.position.z) {
//					InvasiveReedBehavior invasiveBehavior = reed.GetComponent<InvasiveReedBehavior> ();
//					//invasiveBehavior.Behavior ();
//					Debug.Log ("WE FOUND A REED !!!");
//					reedFound = true;
//					Events.instance.Raise (new HoverResourceEvent (invasiveBehavior));
//
//				}
//				//reedFound = true;
//
//			}
//		}
//		foreach (GameObject trash in trashList) {
//			if (trashFound == false) {
//				
////				Debug.Log ("checking for trash...");
////				Debug.Log (trash.transform.position.x + " " + playerPosition.x);
////				Debug.Log (trash.transform.position.z + " " + playerPosition.z);
//				if ((Mathf.Round (playerPosition.x)) == trash.transform.position.x && (Mathf.Round (playerPosition.z)) == trash.transform.position.z) {
//					TrashBehavior trashBehavior = trash.GetComponent<TrashBehavior> ();
////					trashBehavior.Behavior ();
//					Debug.Log ("WE FOUND A TRASH !!!");
//					trashFound = true;
//					Events.instance.Raise (new HoverResourceEvent (trashBehavior));
////					Debug.Log ("event sent");
//
//				}
//				//trashFound = true;
//			}
//		}
	} 



	public void OnMouseEnter () {
//		Ray ray = mapCamera.ScreenPointToRay(Input.mousePosition);
//		RaycastHit hit;
//		if (Physics.Raycast (ray, out hit, 4f)) {
//			Debug.DrawLine (ray.origin, hit.point);
//			if (hit.collider) {
				tilePosition = this.transform.position;
				//Debug.Log (tilePosition);
				iTween.ColorTo(gameObject, iTween.Hash(
					"color", tileHighlight,
					"time", .01f

				));
				//this.transform.position.y += 10;

				//Events.instance.Raise (new HoverResourceEvent (this));
				//hoverRoots.SetActive (true);
//			}
//		}
	}

	public void OnMouseExit () {
//		this.transform.position.y += 10;
		iTween.ColorTo(gameObject, iTween.Hash(
			"color", tileColor,
			"time", .01f

		));
	}

	public void OnPointerDown(PointerEventData e)
	{
//		Ray ray = mapCamera.ScreenPointToRay(Input.mousePosition);
//		RaycastHit hit;
//		if (Physics.Raycast (ray, out hit, 4f)) {
//			Debug.DrawLine (ray.origin, hit.point);
//			if (hit.collider) {
				//tilePosition = this.transform.position;

				//Events.instance.Raise (new ClickLandEvent (this));
				Debug.Log ("clicked tile!");
				Behavior();
//			}
//		}
	}
}
