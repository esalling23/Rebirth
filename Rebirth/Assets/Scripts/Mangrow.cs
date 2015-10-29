using UnityEngine;
using System.Collections;

public class Mangrow : MonoBehaviour {

	public GameObject Info;
	public Color color;
	public float speed;
	public GameObject Roots;
	public GameObject Top;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseOver()
	{
		// If the left mouse button is pressed
		if (Input.GetMouseButtonDown(0))
		{
			// Display a message in the Console tab
			Debug.Log("Left click!");
			
			//			Info.SetActive(true);
			
			
		}
		
		// If the right mouse button is pressed
		if (Input.GetMouseButtonDown(1))
		{
			// Display a message in the Console tab
			Debug.Log("Right click!");
			iTween.MoveBy(Top,iTween.Hash(
				"y"   , 2.2,
				"time", 200f
				));
			iTween.MoveBy(Roots,iTween.Hash(
				"y"   , .8,
				"time", 100f
				));
			
		}
	}
}
