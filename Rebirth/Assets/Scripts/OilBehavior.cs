using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class OilBehavior : MonoBehaviour, IResource, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {

	public Color color;


	public void Behavior () {
		//play animation
		iTween.ColorTo(gameObject,iTween.Hash(
			"color", color, 
			"time", 200f
			));
	}


	public void OnPointerEnter(PointerEventData e)
	{
		//Events.instance.Raise (new ClickResourceEvent (this));
	}
	public void OnPointerExit(PointerEventData e)
	{
		//Events.instance.Raise (new ClickResourceEvent (this));
	}

	public void OnPointerDown(PointerEventData e)
	{
		Events.instance.Raise (new ClickResourceEvent (this));
		Debug.Log ("yes oil!");

	}
}
