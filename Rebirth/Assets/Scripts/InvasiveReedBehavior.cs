using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InvasiveReedBehavior : MonoBehaviour, IPointerDownHandler, IResource {

//	public GameObject roots;
//	public GameObject hoverRoots;
	public GameObject reed;
	private bool reedFound = false;
	private Vector3 reedPosition;
	private Vector3 reedUp;
	private Vector3 reedDown;
	private Vector3 reedRight;
	private Vector3 reedLeft;
	private List<Vector3> destroySpots = new List<Vector3>();
	private List<GameObject> marshSpots = new List<GameObject> ();
	private Vector3 marshPosition = new Vector3();
	private Vector3 otherReed = new Vector3();
	private Vector3 mangrovePosition = new Vector3();
	public List<GameObject> reedList = new List<GameObject>();
	public List<GameObject> mangroveList = new List<GameObject>();

	private GameObject control;
	private int lastDayNum;
	private int dayNum;



//	DayNightCycle controller;
	// Use this for initialization
	void Start () {
		control = GameObject.Find ("GameMaster");
		dayNum = control.GetComponent<DayNightCycle> ().dayCount;
		lastDayNum = control.GetComponent<DayNightCycle> ().dayCount;
//		reedPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.P)) {
			control.GetComponent<TimeControl> ().TimeChange(.3f);

		}
		dayNum = control.GetComponent<DayNightCycle> ().dayCount;

		if (lastDayNum != dayNum)
		{
			Debug.Log ("day " + lastDayNum + " changed to day " + dayNum);
			OnDayChange();
			lastDayNum = dayNum;
		}
	}

	public void OnDayChange () {

		reedPosition = new Vector3 (Mathf.Round (this.transform.position.x), 0, Mathf.Round (this.transform.position.z));
		reedRight = reedPosition + new Vector3 (10, 0, 0);
		//		Debug.Log (personRight + " person, " + playerPosition + " player");
		reedLeft = reedPosition + new Vector3 (-10, 0, 0);
		//		Debug.Log (personLeft + " person, " + playerPosition + " player");
		reedUp = reedPosition + new Vector3 (0, 0, 10);
		//		Debug.Log (personUp + " person, " + playerPosition + " player");
		reedDown = reedPosition + new Vector3 (0, 0, -10);
		//		Debug.Log (personDown + " person, " + playerPosition + " player");

		//		Debug.Log ("the day changed.");
		//		Debug.Log ("trash at position " + trash.transform.position.x + "x, " + trash.transform.position.z + "y");
		destroySpots.Clear();
		destroySpots.Add (reedPosition);
		destroySpots.Add (reedUp);
		destroySpots.Add (reedDown);
		destroySpots.Add (reedRight);
		destroySpots.Add (reedLeft);

		mangroveList.AddRange (GameObject.FindGameObjectsWithTag ("Mangrove"));
		reedList.AddRange(GameObject.FindGameObjectsWithTag ("Invasive"));
		marshSpots.AddRange(GameObject.FindGameObjectsWithTag ("marsh"));

		foreach (Vector3 position in destroySpots) {
			foreach (GameObject marsh in marshSpots) {
				Debug.Log (position + " destroy spot position; " + marsh.transform.position + " marsh spot position");
				marshPosition = marsh.transform.position;
				if (position == marshPosition) {
					foreach (GameObject reed in reedList) {
						otherReed = reed.transform.position;
						if (!(position == otherReed)) {
							foreach (GameObject mangrove in mangroveList) {
								mangrovePosition = mangrove.transform.position;
								if (!(position == mangrovePosition)) {
									Debug.Log ("reed growth");
									Instantiate (reed, position, Quaternion.identity);
								} 
//								if (position == mangrovePosition) {
//									mangrove.GetComponent<MangroveBehavior> ().reedAttack++;
//								}
							}
						}
					}
				} 
			}
		}
	}

	public void Behavior () {
		Debug.Log (control.GetComponent<DayNightCycle> ().currentTimeOfDay);


		control.GetComponent<TimeControl> ().TimeChange(0.3f);
		Debug.Log (control.GetComponent<DayNightCycle> ().currentTimeOfDay);
//		controller.currentTimeOfDay += .1f;
//		Debug.Log (control.GetComponent<DayNightCycle> ().currentTimeOfDay);
		Destroy (reed);
		Debug.Log ("destroyed reed");


	} 


	public void OnMouseEnter () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 4f)) {
			Debug.DrawLine (ray.origin, hit.point);
			if (hit.collider) {
				Events.instance.Raise (new HoverResourceEvent (this));
				//hoverRoots.SetActive (true);
			}
		}
	}

//	public void OnMouseExit () {
//		hoverRoots.SetActive (false);
//	}

	public void OnPointerDown(PointerEventData e)
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 4f)) {
			Debug.DrawLine (ray.origin, hit.point);
			if (hit.collider) {
				//Events.instance.Raise (new ClickResourceEvent (this));
				Debug.Log ("clicked roots of reed!");
				Behavior();
			}
		}
	}
}
