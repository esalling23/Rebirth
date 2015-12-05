using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ResourceStats: MonoBehaviour {

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
		Events.instance.AddListener<HoverResourceEvent>
			(OnHoverResourceEvent);
	}

	void OnHoverResourceEvent(HoverResourceEvent e) {
		if (e.hoverResource is GrassBehavior) {
			resourceName.text = "Grass";
			resourceStat.text = "-2";

		}
		if (e.hoverResource is OilBehavior) {
			resourceName.text = "Oil";
			resourceStat.text = "+1";

		}
		if (e.hoverResource is MangroveBehavior) {
			resourceName.text = "Mangrove";
			resourceStat.text = "-2";

		}
        if (e.hoverResource is TrashBehavior)
        {
			resourceName.text = "Trash";
			resourceStat.text = "+2";

		}
        if (e.hoverResource is PalmBehavior)
        {
			resourceName.text = "Palm";
			resourceStat.text = "-4";

		}
       
    }
}
