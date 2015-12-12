using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GrassBehavior : MonoBehaviour, IPointerDownHandler, IResource {

	public static GrassBehavior grassAccess;

	public GameObject hover;
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
	}
	
    public void OnMouseEnter()
	{
		hover.SetActive (true);
		//Debug.Log ("Highlight Grass!");
		Events.instance.Raise (new HoverResourceEvent (this));
		iTween.ColorTo (gameObject, iTween.Hash (
			"color", highlight, 
			"time", .1f

			));
	}

	public void OnMouseExit()
	{
		hover.SetActive (false);
		//Debug.Log ("Unhighlight Grass!");
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
