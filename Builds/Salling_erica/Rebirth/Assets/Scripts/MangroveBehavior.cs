using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MangroveBehavior : MonoBehaviour, IResource, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
	
	public Color color;
	public float speed;
	public GameObject Roots;
	public GameObject Top;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
	
	public void Behavior ()
	{
		Debug.Log("Mangrove Growing!");
		iTween.MoveBy(Top,iTween.Hash(
			"y"   , 2.2,
			"time", 200f
			));
		iTween.MoveBy(Roots,iTween.Hash(
			"y"   , .8,
			"time", 100f
			));
	}
}
