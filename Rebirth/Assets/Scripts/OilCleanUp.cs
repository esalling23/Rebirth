using UnityEngine;
using System.Collections;

public class OilCleanUp : MonoBehaviour {

	public Renderer renderer;
	public Material [] materials;
	public GameObject spot;
	public GameObject UIHover;
	public Color color;
//	public Color color2;
//	public Color color3;

//	oilCleanUp[0] = OilReduce1;
//	oilCleanUp[1] = OilReduce2;
//	oilCleanUp[2] = Sand;
//	renderer.materials = OilCleanUp;


	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		renderer.enabled = true;
		//spot = GetComponent<Tag> ();
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
			UIHover.SetActive(true);
			
			//Destroy the parent of the face we clicked
			//Destroy(this.transform.parent.gameObject);
		}
		
		// If the right mouse button is pressed
		if (Input.GetMouseButtonDown(1))
		{
			// Display a message in the Console tab
			Debug.Log("Right click!");
			iTween.ColorTo(gameObject,iTween.Hash(
				"color", color, 
				"time", 200f
				));
//			if (renderer.material.GetColor("_Color", color))
//			{
//				return; 
//				Debug.Log("Oil");
//				renderer.material.SetColor ("_Color", color2);
//				gameObject.tag = "OilCleanup1";
//				
//			}
//			else 
//				if (Renderer.material.GetColor("_Color", color2))
//			{
//				return; 
//				Debug.Log("Oil1");
//				renderer.material.SetColor ("_Color", color3);
//				gameObject.tag = "OilCleanup2";
//				
//			}
//			else 
//				//		 (OilSpillChange2.activeInHierarchy == true)
//			{
//				return; 
//				renderer.sharedMaterial = materials [3];
//				
//			}

			
			
			
		}
	}

}
