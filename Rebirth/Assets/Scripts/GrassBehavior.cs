using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class GrassBehavior : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IResource {

	public static GrassBehavior access;

	public GameObject ClickOptions;
	public GameObject IrrigateButton;
	public GameObject CleanButton;


	public Renderer renderer;
	public Color color;
	public float speed;

	public bool rightClicked = false;
	public bool leftClicked = false;
	
	private Color startcolor;

	// Use this for initialization
	void Start () {

		//Info.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	public void Behavior () {

	}

	public void Irrigate() {

		iTween.ColorTo (gameObject, iTween.Hash (
			"color", color, 
			"time", 200f
		));
		iTween.MoveBy (gameObject, iTween.Hash (
			"y", .4,
			"time", 300f
		));
	}

    public void OnPointerEnter(PointerEventData e)
	{
		startcolor = GetComponent<Renderer>().material.color;
		GetComponent<Renderer>().material.color = Color.yellow;
	}
	public void OnPointerExit(PointerEventData e)
	{
		GetComponent<Renderer>().material.color = startcolor;
	}
	// This function is triggered when the mouse cursor is over the GameObject on which this script runs
	public void OnPointerDown(PointerEventData e)
	{
		Events.instance.Raise (new ClickResourceEvent (this));
		Debug.Log ("yes grass!");
//		// If the left mouse button is pressed
//		if (Input.GetMouseButtonDown(0))
//		{ 
//			// Display a message in the Console tab
//			Debug.Log("Left click!");
//			leftClicked = true;
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//			RaycastHit hit;
//			if (Physics.Raycast (ray, out hit, 2f)) {
//				Debug.DrawLine (ray.origin, hit.point);
//				if (hit.collider.tag == "Grass") {
//					if (ClickOptions.activeInHierarchy == false) {
//						ClickOptions.SetActive(true);
//						IrrigateButton.SetActive(true);
//						CleanButton.SetActive(false);
//					} else 
//						ClickOptions.SetActive(false);
//						IrrigateButton.SetActive(false);
//						CleanButton.SetActive(true);
//				}
//			} else {
//				ClickOptions.SetActive(false);
//			}
//
//			//UITools.SetActive(true);
//
//
//
//		}
//		
//		// If the right mouse button is pressed
//		if (Input.GetMouseButtonDown(1))
//		{
//			// Display a message in the Console tab
//			Debug.Log("Right click!");
//			rightClicked = true;
//
//
//
//
//
//
//
//		}
	}

}
