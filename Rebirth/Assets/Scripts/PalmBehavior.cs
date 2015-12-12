using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PalmBehavior : MonoBehaviour, IResource, IPointerDownHandler{

    public GameObject hover;
    public Color highlight;
    public Color color;

	// private Animator anim;

	// Use this for initialization
	void Start () {
<<<<<<< 9d5786b42efb0ce03266ad10240f38a4b8965978
		palming = false;
<<<<<<< Updated upstream
=======
>>>>>>> 3e59c2638d0ffcbd20c0d1fbf6274a8e815eae87
		anim = GetComponent<Animator>();
=======
		// anim = GetComponent<Animator>();
        //GetComponent<Animation>().Play("Idle");
>>>>>>> Stashed changes
    }
	
	// Update is called once per frame
	void Update () {
		// Cache the attention attracting input.
<<<<<<< Updated upstream
		//bool OnClick = Input.GetButtonDown("Grow");
		
		// Set the animator shouting parameter.
		//anim.SetBool(hash.shoutingBool, shout);
=======
		// bool OnClick = Input.GetButtonDown("Grow");
		
		// Set the animator shouting parameter.
		// anim.SetBool(hash.shoutingBool, shout);
>>>>>>> Stashed changes
	}

    public void Behavior()
    {
        Debug.Log("Palm Growing!");
        //play animation
<<<<<<< Updated upstream
       //this.GetComponent<Animator>().Play("PalmGrow");
		anim.SetTrigger ("Palming");
<<<<<<< 9d5786b42efb0ce03266ad10240f38a4b8965978
        palmInfo.SetActive(false);
=======
        //this.GetComponent<Animator>().Play("PalmGrow");
       palmInfo.SetActive(false);
>>>>>>> Stashed changes
=======
>>>>>>> 3e59c2638d0ffcbd20c0d1fbf6274a8e815eae87
    }


    public void OnMouseEnter()
    {
        //Debug.Log("Highlight Palm!");
		hover.SetActive (true);
		Events.instance.Raise (new HoverResourceEvent (this));
		iTween.ColorTo(gameObject, iTween.Hash(
            "color", highlight,
            "time", .1f

            ));
    }

    public void OnMouseExit()
    {
		hover.SetActive (false);
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
                Events.instance.Raise(new ClickResourceEvent(this));
                Debug.Log("yes palm!");
<<<<<<< 9d5786b42efb0ce03266ad10240f38a4b8965978
				palming = true;
<<<<<<< Updated upstream
=======
>>>>>>> 3e59c2638d0ffcbd20c0d1fbf6274a8e815eae87
				anim.SetTrigger ("Palming");
=======
				

>>>>>>> Stashed changes
            }
        }


    }

}
