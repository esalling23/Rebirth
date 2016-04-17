using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class MangroveBehavior : MonoBehaviour, IPointerDownHandler, IResource {

//	public GameObject roots;
//	public GameObject hoverRoots;
	public GameObject mangrove;

	private GameObject control;

	private int lastDayNum;
	private int dayNum;
	private int reedAttack = 0;

	private Vector3 mangrovePosition;
	private Vector3 mangroveRight;
	private Vector3 mangroveLeft;
	private Vector3 mangroveUp;
	private Vector3 mangroveDown;	
	private List<Vector3> destroySpots = new List<Vector3>();
	private List<GameObject> reedList = new List<Vector3>();



	void Start () {
		control = GameObject.Find("GameMaster");
		dayNum = control.GetComponent<DayNightCycle> ().dayCount;
		lastDayNum = control.GetComponent<DayNightCycle> ().dayCount;
	}
	
	// Update is called once per frame
	void Update () {
		dayNum = control.GetComponent<DayNightCycle> ().dayCount;

			if (lastDayNum != dayNum)
			{
			Debug.Log ("day " + lastDayNum + " changed to day " + dayNum);
				OnDayChange();
				lastDayNum = dayNum;
			}
	}

	public void OnDayChange () {
		
		mangrovePosition = new Vector3 (Mathf.Round (this.transform.position.x), 0, Mathf.Round (this.transform.position.z));
		mangroveRight = mangrovePosition + new Vector3 (10, 0, 0);
		//		Debug.Log (personRight + " person, " + playerPosition + " player");
		mangroveLeft = mangrovePosition + new Vector3 (-10, 0, 0);
		//		Debug.Log (personLeft + " person, " + playerPosition + " player");
		mangroveUp = mangrovePosition + new Vector3 (0, 0, 10);
		//		Debug.Log (personUp + " person, " + playerPosition + " player");
		mangroveDown = mangrovePosition + new Vector3 (0, 0, -10);
		//		Debug.Log (personDown + " person, " + playerPosition + " player");

//		Debug.Log ("the day changed.");
//		Debug.Log ("trash at position " + trash.transform.position.x + "x, " + trash.transform.position.z + "y");
		destroySpots.Clear();
		destroySpots.Add (mangrovePosition);
		destroySpots.Add (mangroveUp);
		destroySpots.Add (mangroveDown);
		destroySpots.Add (mangroveRight);
		destroySpots.Add (mangroveLeft);


		foreach (Vector3 position in destroySpots) {
			Debug.Log (position);
			foreach (GameObject reed in reedList) {
				if (position == reed.transform.position) {
					reedAttack++;
				}
			}
		}
	}

	public void Behavior () {
//		Debug.Log (control.GetComponent<DayNightCycle> ().currentTimeOfDay);
//		control.GetComponent<DayNightCycle> ().currentTimeOfDay += .2f;
//		Debug.Log (control.GetComponent<DayNightCycle> ().currentTimeOfDay);
////		controller.currentTimeOfDay += .1f;
////		Debug.Log (control.GetComponent<DayNightCycle> ().currentTimeOfDay);
//		Destroy (trash);
		Debug.Log ("destroyed trash");
//		control.GetComponent<CameraViewControl>().ModeChange();
//		Debug.Log ("change mode");
//		Debug.Log (control.GetComponent<CameraViewControl>().povMode);
//		control.GetComponent<CameraViewControl>().ModeSetup();
//		Debug.Log ("setup mode");

	} 

	public void OnMouseEnter () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 4f)) {
			Debug.DrawLine (ray.origin, hit.point);
			if (hit.collider) {
				//Events.instance.Raise (new HoverResourceEvent (this));
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
				Debug.Log ("clicked trash!");
				//Behavior();
			}
		}
	}
}
