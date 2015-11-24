using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TrashBehavior : MonoBehaviour, IResource, IPointerDownHandler {

    public GameObject trashInfo;
    public Color color;
    public Color highlight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Behavior()
    {
        gameObject.SetActive(false);

    }

    public void OnMouseEnter()
    {
        Debug.Log("Highlight Trash!");
        iTween.ColorTo(gameObject, iTween.Hash(
            "color", highlight,
            "time", .1f

            ));
    }

    public void OnMouseExit()
    {
        Debug.Log("Unhighlight Trash!");
        iTween.ColorTo(gameObject, iTween.Hash(
            "color", color,
            "time", .1f
            ));
    }

    public void OnPointerDown(PointerEventData e)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5f))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (hit.collider)
            {
                Events.instance.Raise(new ClickResourceEvent(this));
                Debug.Log("yes trash!");
            }
        }
    }
}
