using UnityEngine;
using System.Collections;

public class ClickOnFaceScript : MonoBehaviour {

	// Public fields are visible and their values can be changed dirrectly in the editor
		// represents the position displacement needed to compute the position of the new instance
		public Vector3 delta;
	public Animator anim;
	public GameObject Info;

	public Renderer renderer;
	public Color color;
	public float speed;
	public int xPos;
	public int zPos;
	
	
	// Use this for initialization
	void Start () {

		//Info.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	// This function is triggered when the mouse cursor is over the GameObject on which this script runs
	void OnMouseOver()
	{
		// If the left mouse button is pressed
		if (Input.GetMouseButtonDown(0))
		{
			// Display a message in the Console tab
			Debug.Log("Left click!");

//			Info.SetActive(true);

			//Destroy the parent of the face we clicked
			//Destroy(this.transform.parent.gameObject);
		}
		
		// If the right mouse button is pressed
		if (Input.GetMouseButtonDown(1))
		{
			// Display a message in the Console tab
			Debug.Log("Right click!");
			renderer.material.SetColor ("_Color", color);
			//iTween.MoveTo(gameObject,Vector3(xPos,2,zPos),2);
			//grassGrow.position = new Vector3(transform.position.x, 2f, transform.position.z);
			//transform.position = Vector3.MoveTowards(transform.position, grassGrow.position, step);

			//			IslandCreator.CloneAndPlace(this.transform.parent.transform.position + delta, // N = C + delta
//			                             this.transform.parent.gameObject); // The parent GameObject 



		}
	}

}
