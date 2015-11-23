using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class LoadGame : MonoBehaviour, IPointerDownHandler {
	
	public GameObject loadingScreen;

	public void OnPointerDown (PointerEventData e) {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 2f)) {
			Debug.DrawLine (ray.origin, hit.point);
			if (hit.collider) {
				Debug.Log ("Loading level");
				LoadLevel (2);
			}
		}

		          
	}


	public void LoadLevel (int level) {
		loadingScreen.SetActive (true);
		Application.LoadLevel (level);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
