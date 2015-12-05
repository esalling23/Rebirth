using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class OilBehavior : MonoBehaviour, IResource, IPointerDownHandler {

	public Color color;
	public Color clean;
	public Color highlight;
	public GameObject oilInfo;

	void Start () {
		
	}

	public void Behavior () {
		Debug.Log ("Oil Cleaned Up!");
		//play animation
		iTween.ColorTo(gameObject,iTween.Hash(
			"color", clean, 
			"time", 200f
			));
		oilInfo.SetActive (false);
	}

    public void OnMouseEnter()
    {
        Debug.Log("Highlight Oil!");
		Events.instance.Raise (new HoverResourceEvent (this));
        iTween.ColorTo(gameObject, iTween.Hash(
            "color", highlight,
            "time", .1f

            ));
    }

    public void OnMouseExit()
    {
        Debug.Log("Unhighlight Oil!");
        iTween.ColorTo(gameObject, iTween.Hash(
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
				Debug.Log ("yes oil!");
			}
		}


	}
}
