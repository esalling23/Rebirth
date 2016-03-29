using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TileSelect : MonoBehaviour, IPointerDownHandler {

	//public GameObject cameraControl;

	public GameObject player;
	public Camera mapCamera;
	public Vector3 tilePosition;

	public Vector3 playerPosition;
	public Color tileHighlight;
	public Color tileColor;

	public CameraViewControl mode;


	// Use this for initialization
	void Start () {
		iTween.ColorTo(gameObject, iTween.Hash(
			"color", tileColor,
			"time", .1f

		));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Behavior () {
		tilePosition = this.transform.position;
		Debug.Log (tilePosition);

//		mode.ModeChange ();
//		Debug.Log (mode.povMode);

		playerPosition = new Vector3(tilePosition.x, 10, tilePosition.z);
		player.transform.position = playerPosition;
		Debug.Log (player.transform.position);
		Debug.Log ("placing player");



	} 

	public void OnMouseEnter () {
//		Ray ray = mapCamera.ScreenPointToRay(Input.mousePosition);
//		RaycastHit hit;
//		if (Physics.Raycast (ray, out hit, 4f)) {
//			Debug.DrawLine (ray.origin, hit.point);
//			if (hit.collider) {
				tilePosition = this.transform.position;
				Debug.Log (tilePosition);
				iTween.ColorTo(gameObject, iTween.Hash(
					"color", tileHighlight,
					"time", .01f

				));
				//this.transform.position.y += 10;

				//Events.instance.Raise (new HoverResourceEvent (this));
				//hoverRoots.SetActive (true);
//			}
//		}
	}

	public void OnMouseExit () {
//		this.transform.position.y += 10;
		iTween.ColorTo(gameObject, iTween.Hash(
			"color", tileColor,
			"time", .01f

		));
	}

	public void OnPointerDown(PointerEventData e)
	{
//		Ray ray = mapCamera.ScreenPointToRay(Input.mousePosition);
//		RaycastHit hit;
//		if (Physics.Raycast (ray, out hit, 4f)) {
//			Debug.DrawLine (ray.origin, hit.point);
//			if (hit.collider) {
				//Events.instance.Raise (new ClickLandEvent (this));
				Debug.Log ("clicked tile!");
				Behavior();
//			}
//		}
	}
}
