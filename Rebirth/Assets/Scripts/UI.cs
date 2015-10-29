using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	public GameObject UIinfo;
	public GameObject MenuButton;
	public GameObject UIjournal;
	public GameObject ClickOptions;
	public GameObject CleanButton;
	public GameObject IrrigateButton;
	//public GameObject Grass;
	public Color color;


	// Use this for initialization
	void Start () {
		if (UIinfo.activeInHierarchy || UIjournal.activeInHierarchy || ClickOptions.activeInHierarchy) {
			MenuButton.SetActive(false);
		}


	}

	public void Back () {
		ClickOptions.SetActive (false);
	}

	public void IrrigateClick () {
		GrassGrow.access.Irrigate ();
	}

//	public void Irrigate() {
//		
//		iTween.ColorTo (Grass, iTween.Hash (
//			"color", color, 
//			"time", 200f
//			));
//		iTween.MoveBy (Grass, iTween.Hash (
//			"y", .4,
//			"time", 300f
//			));
//	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
