using UnityEngine;
using System.Collections;

public class Bounds : MonoBehaviour {


	public GameObject player;
	
	void Start()
	{
//		player = GameObject.Find ("Player");
//		
//		if(player.GetComponent<CharacterMotorC>().enabled == true)
//		{
//			player.GetComponent<CharacterMotorC>().enabled = false;
//			Debug.Log ("Motor Disabled Successfully!");
//		}
//		
//		else
//			print ("No Motor Enabled!");

		//Cursor.lockState = true;
	}


	                                                  //Ray hit variable named "hit"
	
	// Update is called once per frame
	void Update () {

//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		RaycastHit hit;
//		if (Physics.Raycast(ray, out hit, 100)) {
//			Debug.DrawLine(ray.origin, hit.point);
//
//			if (hit.collider.gameObject.tag == "Boundary")                    //If that something is the target
//			if (hit.distance <= 2.0) {                            //If that target is within 2m
//				if (Input.anyKey) {                    //And if the mouse is down
//					//Cursor.lockState = false;                    //Unlock the cursor
//					//audio.clip = sound1;                        //Play the audio
//					//audio.Play ();
//					GameObject.Find ("Player").GetComponent<MouseLook> ().enabled = false; //Freeze the Camera motion
//					GameObject.Find ("Player").GetComponent<CharacterMotorC> ().enabled = false;//Freeze the player motion
//				} else {                                            //Else if the button is not pressed
//					//Screen.lockCursor = true;                            //Mouse locked
//					if (!GameObject.Find ("Player").GetComponent<MouseLook> ().enabled) {        //If Camera is still frozen
//						GameObject.Find ("Player").GetComponent<MouseLook> ().enabled = true;        //Unfreeze it
//					}
//				}
//			}
//		}

//		if (Physics.Raycast (ray, out hit) == true) {                    //If the ray is hitting something
//
//		}
	}
}
