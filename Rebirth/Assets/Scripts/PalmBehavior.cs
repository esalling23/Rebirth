using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PalmBehavior : MonoBehaviour, IResource, IPointerDownHandler{

    public GameObject palmInfo;
    public Color highlight;
    public Color color;
	private bool palming;

	private Animator anim;

	// Use this for initialization
	void Start () {
		palming = false;
		anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		// Cache the attention attracting input.
		//bool OnClick = Input.GetButtonDown("Grow");
		
		// Set the animator shouting parameter.
		//anim.SetBool(hash.shoutingBool, shout);
	}

    public void Behavior()
    {
        Debug.Log("Palm Growing!");
        //play animation
       //this.GetComponent<Animator>().Play("PalmGrow");
		anim.SetTrigger ("Palming");
        palmInfo.SetActive(false);
    }


    public void OnMouseEnter()
    {
        //Debug.Log("Highlight Palm!");
		Events.instance.Raise (new HoverResourceEvent (this));
		iTween.ColorTo(gameObject, iTween.Hash(
            "color", highlight,
            "time", .1f

            ));
    }

    public void OnMouseExit()
    {
       // Debug.Log("Unhighlight Palm!");
        iTween.ColorTo(gameObject, iTween.Hash(
            "color", color,
            "time", .1f
            ));
    }

    public void OnPointerDown(PointerEventData e)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3f))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (hit.collider)
            {
                //Events.instance.Raise(new ClickResourceEvent(this));
                Debug.Log("yes palm!");
				palming = true;
				anim.SetTrigger ("Palming");
            }
        }


    }

}
