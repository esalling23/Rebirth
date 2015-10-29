using UnityEngine;
using System.Collections;


public class GrassGrow : MonoBehaviour {

	public static GrassGrow access;

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

	void OnMouseEnter()
	{
		startcolor = GetComponent<Renderer>().material.color;
		GetComponent<Renderer>().material.color = Color.yellow;
	}
	void OnMouseExit()
	{
		GetComponent<Renderer>().material.color = startcolor;
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

	// This function is triggered when the mouse cursor is over the GameObject on which this script runs
	void OnMouseOver()
	{

		// If the left mouse button is pressed
		if (Input.GetMouseButtonDown(0))
		{
			// Display a message in the Console tab
			Debug.Log("Left click!");
			leftClicked = true;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 2f)) {
				Debug.DrawLine (ray.origin, hit.point);
				if (hit.collider.tag == "Grass") {
					if (ClickOptions.activeInHierarchy == false) {
						ClickOptions.SetActive(true);
						IrrigateButton.SetActive(true);
						CleanButton.SetActive(false);
					} else 
						ClickOptions.SetActive(false);
						IrrigateButton.SetActive(false);
						CleanButton.SetActive(true);
				}
			} else {
				ClickOptions.SetActive(false);
			}

			//UITools.SetActive(true);



		}
		
		// If the right mouse button is pressed
		if (Input.GetMouseButtonDown(1))
		{
			// Display a message in the Console tab
			Debug.Log("Right click!");
			rightClicked = true;







		}
	}

}
