using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PalmAnimate : MonoBehaviour, IResource, IPointerDownHandler
{

    public GameObject palmInfo;
    public Color highlight;
    public Color color;

    public Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Behavior()
    {
        Debug.Log("Palm Growing!");
        //play animation
        anim.Play("PalmGrow");
        palmInfo.SetActive(false);
    }


    public void OnMouseEnter()
    {
        Debug.Log("Highlight Palm!");
        iTween.ColorTo(gameObject, iTween.Hash(
            "color", highlight,
            "time", .1f

            ));
    }

    public void OnMouseExit()
    {
        Debug.Log("Unhighlight Palm!");
        iTween.ColorTo(gameObject, iTween.Hash(
            "color", color,
            "time", .1f
            ));
    }

    public void OnPointerDown(PointerEventData e)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (hit.collider)
            {
                Events.instance.Raise(new ClickResourceEvent(this));
                anim.Play("PalmGrow");
            }
        }


    }

}
