using UnityEngine;
using System.Collections;

public class PopUpMenu : MonoBehaviour {

	public bool hit = false;
	public GameObject UIHover;
	private Color startcolor;
	// Use this for initialization
	void Start () {
	
	}
	void Back () {


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
	// Update is called once per frame
	void Update () {

	}


}
