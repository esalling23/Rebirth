using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GrassBehavior : MonoBehaviour, IPointerDownHandler, IResource {

	public static GrassBehavior access;

	public GameObject grassInfo;
	//public Renderer renderer;
	public Color color;
	public Color green;
	public Color highlight;
	//public float speed;

	private Color startcolor;

	// Use this for initialization
	void Start () {
		iTween.ColorTo (gameObject, iTween.Hash (
			"color", color
			));

	}


	
	public void Behavior () {
		Debug.Log ("Grass Growing!");
		iTween.ColorTo (gameObject, iTween.Hash (
			"color", green, 
			"time", 200f
			));
		iTween.MoveBy (gameObject, iTween.Hash (
			"y", .4,
			"time", 300f
			));
		grassInfo.SetActive (false);

	}
	
    public void OnMouseEnter()
	{
		Debug.Log ("Highlight Grass!");
		iTween.ColorTo (gameObject, iTween.Hash (
			"color", highlight, 
			"time", .1f

			));
	}

	public void OnMouseExit()
	{
		Debug.Log ("Unhighlight Grass!");
		iTween.ColorTo (gameObject, iTween.Hash (
			"color", color,
			"time", .1f
			));
	}

	public void OnPointerDown(PointerEventData e)
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 2f)) {
			Debug.DrawLine (ray.origin, hit.point);
			if (hit.collider) {
				Events.instance.Raise (new ClickResourceEvent (this));
				Debug.Log ("yes grass!");
			}
		}
	}
}
