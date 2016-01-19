﻿using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class SandBehavior : MonoBehaviour, IPointerDownHandler, IResource {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}



	public void Behavior () {
		if (gameObject.tag == "Sand") {
			Debug.Log ("sand detected. analyzing...");
		}
		if (gameObject.tag == "Oil") {
			Debug.Log ("oil detected. analyzing...");
		}
		if (gameObject.tag == "Soil") {
			Debug.Log ("soil detected. analyzing...");
		}
	} 

	public void OnMouseEnter () {
		Events.instance.Raise (new HoverResourceEvent (this));

	}

	public void OnPointerDown(PointerEventData e)
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 2f)) {
			Debug.DrawLine (ray.origin, hit.point);
			if (hit.collider) {
				Events.instance.Raise (new ClickLandEvent (this));
				Debug.Log ("clicked land");
				Behavior();
			}
		}
	}
}
