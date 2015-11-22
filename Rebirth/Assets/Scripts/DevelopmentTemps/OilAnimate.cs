using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class OilAnimate : MonoBehaviour, IResource, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {

	public Color color;
	public Color clean;
	public Color highlight;
	public GameObject oilInfo;

	void Start () {
		iTween.ColorTo (gameObject, iTween.Hash (
			"color", color
			
			));	
	}

	public void Behavior () {
//		Debug.Log ("Oil Cleaned Up!");
//		//play animation
//		iTween.ColorTo(gameObject,iTween.Hash(
//			"color", clean, 
//			"time", 200f
//			));
//		oilInfo.SetActive (false);
	}


	public void OnPointerEnter(PointerEventData e)
	{
		Debug.Log ("Highlight Grass!");
		iTween.ColorTo (gameObject, iTween.Hash (
			"color", highlight,
			"time", 1f
		));	
	}

	public void OnPointerExit(PointerEventData e)
	{
		Debug.Log ("Highlight Grass!");
		iTween.ColorTo (gameObject, iTween.Hash (
			"color", color,
			"time", 1f
		));	
	}

	public void OnPointerDown(PointerEventData e)
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 2f)) {
			Debug.DrawLine (ray.origin, hit.point);
			if (hit.collider) {
				Debug.Log ("Oil Cleaned Up!");
				//play animation
				iTween.ColorTo(gameObject,iTween.Hash(
					"color", clean, 
					"time", 200f
					));
//				Events.instance.Raise (new ClickResourceEvent (this));
//				Debug.Log ("yes oil!");
			}
		}


	}
}
