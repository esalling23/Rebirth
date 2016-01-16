using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GrassAnimate : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IResource {

	//public static GrassBehavior access;

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
	
	// Update is called once per frame
	void Update () {
	
	}

	
	public void Behavior () {
//		Debug.Log ("Grass Growing!");
//		iTween.ColorTo (gameObject, iTween.Hash (
//			"color", green, 
//			"time", 200f
//			));
//		iTween.MoveBy (gameObject, iTween.Hash (
//			"y", .4,
//			"time", 300f
//			));
//		grassInfo.SetActive (false);

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
		Debug.Log ("Unhighlight Grass!");
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
				Debug.Log ("Grass Growing!");
				iTween.ColorTo (gameObject, iTween.Hash (
					"color", green, 
					"time", 200f
					));
				iTween.MoveBy (gameObject, iTween.Hash (
					"y", .4,
					"time", 300f
					));
				//grassInfo.SetActive (false);
//				Events.instance.Raise (new ClickResourceEvent (this));
//				Debug.Log ("yes grass!");
			}
		}
	}
}
