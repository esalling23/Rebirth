using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TrashBehavior : MonoBehaviour, IResource, IPointerDownHandler {

    public GameObject trashInfo;
    public Color color;
    public Color highlight;

	float originalY;
	
	public float floatStrength = .1f; // You can change this in the Unity Editor to 
	// change the range of y positions that are possible.
	
	void Start()
	{
		this.originalY = this.transform.position.y;
	}
	
	void Update()
	{
		transform.position = new Vector3(transform.position.x, originalY + ((float)Mathf.Sin(Time.time) * floatStrength),transform.position.z);
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
				gameObject.SetActive(false);
            }
        }
    }
}
