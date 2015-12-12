using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ResourceStats: MonoBehaviour {

	public GameObject hover;
	public Text resourceStat;
	public Text resourceName;



//	public GameObject OilInfo;
//	public GameObject TrashInfo;
//	public GameObject GrassInfo;
//	public GameObject FernInfo;
//	public GameObject PalmInfo;
//	public GameObject PineInfo;
//	public GameObject MangroveInfo;


	// Use this for initialization
	void Awake () {
		hover.SetActive(false);
		Events.instance.AddListener<HoverResourceEvent>
			(OnHoverResourceEvent);
	}

	void OnHoverResourceEvent(HoverResourceEvent e) {
		if (e.hoverResource is GrassBehavior) {
			Debug.Log ("hovering");
			resourceName.text = "Grass: ";
			resourceStat.text = "Plant Species\nRehab costs: 1 FUEL";


		}
		if (e.hoverResource is OilBehavior) {
			Debug.Log ("hovering");
			resourceName.text = "Oil: ";
			resourceStat.text = "Pollution\nClean up rewards: 2 FUEL";

		}
		if (e.hoverResource is MangroveBehavior) {
			Debug.Log ("hovering");
			resourceName.text = "Mangrove: ";
			resourceStat.text = "Plant Species\nRehab costs: 3 FUEL";


		}
        if (e.hoverResource is TrashBehavior)
        {
			Debug.Log ("hovering");
			resourceName.text = "Trash: ";
			resourceStat.text = "Pollution\nClean up rewards: 2 FUEL";


		}
		if (e.hoverResource is BigTrashBehavior)
		{
			Debug.Log ("hovering");
			resourceName.text = "Trash: ";
			resourceStat.text = "Pollution\nClean up rewards: 4 FUEL";
			
			
		}
        if (e.hoverResource is PalmBehavior)
        {
			Debug.Log ("hovering");
			resourceName.text = "Palm: ";
			resourceStat.text = "Plant Species\nRehab costs: 4 FUEL";
		}
       
    }
}
