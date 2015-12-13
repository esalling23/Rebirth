using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MangroveBehavior : MonoBehaviour, IResource, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {

	private GameMaster accessGameMaster;

	public Color color;
	public Color highlight;
	public float speed;

	public GameObject hover;

	public GameObject Roots;
	public GameObject Top;
	public GameObject Shrimp;

	// Use this for initialization
	void Start () {
		iTween.ColorTo (gameObject, iTween.Hash (
			"color", color
			));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnPointerEnter(PointerEventData e)
	{
		iTween.ColorTo (gameObject, iTween.Hash (
			"color", highlight, 
			"time", .1f
			
			));
		hover.SetActive (true);
		Events.instance.Raise (new HoverResourceEvent (this));
	}

	public void OnPointerExit(PointerEventData e)
	{
		iTween.ColorTo (gameObject, iTween.Hash (
			"color", color, 
			"time", .1f
			
			));
		hover.SetActive (false);
		//Events.instance.Raise (new HoverResourceEvent (this));
	}

	public void OnPointerDown(PointerEventData e)
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 2f)) {
			Debug.DrawLine (ray.origin, hit.point);
			if (hit.collider) {
				Events.instance.Raise (new ClickResourceEvent (this));
				Debug.Log ("yes mangrow!");
				if (accessGameMaster.mangroveRemaining == 0) {
					Shrimp.SetActive(true);
				} else {
					Behavior();
				}
			}
		}
		
		
	}
	
	public void Behavior ()
	{
		Debug.Log("Mangrove Growing!");
		iTween.MoveBy(Top,iTween.Hash(
			"y"   , 2.0,
			"time", 200f
			));
		iTween.MoveBy(Roots,iTween.Hash(
			"y"   , .8,
			"time", 100f
			));
	}
}
