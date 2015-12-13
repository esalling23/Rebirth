using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ResourceStats: MonoBehaviour {

	public GameObject accessGameMaster;

	public GameObject hover;
	public Text resourceStat;
	public Text resourceName;
	public Text resourceType;



//	public GameObject OilInfo;
//	public GameObject TrashInfo;
//	public GameObject GrassInfo;
//	public GameObject FernInfo;
//	public GameObject PalmInfo;
//	public GameObject PineInfo;
//	public GameObject MangroveInfo;


	// Use this for initialization
	void Awake () {
		//hover.SetActive(false);
		Events.instance.AddListener<HoverResourceEvent>
			(OnHoverResourceEvent);
	}

	void OnHoverResourceEvent(HoverResourceEvent e) {
		if (e.hoverResource is GrassBehavior) {
			Debug.Log ("hovering");
			resourceName.text = "GRASS: ";
			resourceType.text = "PLANT SPECIES";
			resourceStat.text = "Rehab costs: - 1 FUEL";


		}
		if (e.hoverResource is OilBehavior) {
			Debug.Log ("hovering");
			resourceName.text = "OIL: ";
			resourceType.text = "POLLUTION";
			resourceStat.text = "CLEAN_UP_REWARDS: + 2 FUEL";

		}
		if (e.hoverResource is MangroveBehavior) {
			Debug.Log ("hovering");
			if (accessGameMaster.GetComponent<GameMaster>().mangroveRemaining == 0) {
				resourceName.text = "SHRIMP_HABITAT:";
				resourceType.text = "ANIMAL_SPECIES";
				resourceStat.text = "REHAB_COSTS = - 6 FUEL";
			} else {
				resourceName.text = "MANGROVE: ";
				resourceType.text = "PLANT SPECIES";
				resourceStat.text = "REHAB COSTS: - 4 FUEL";
			}
		}
        if (e.hoverResource is TrashBehavior)
        {
			Debug.Log ("hovering");
			resourceName.text = "TRASH: ";
			resourceType.text = "POLLUTION";
			resourceStat.text = "CLEAN UP REWARDS: + 4 FUEL";


		}
		if (e.hoverResource is BigTrashBehavior)
		{
			Debug.Log ("hovering");
			resourceName.text = "TRASH: ";
			resourceType.text = "POLLUTION";
			resourceStat.text = "CLEAN UP REWARDS: - 6 FUEL";
			
			
		}
        if (e.hoverResource is PalmBehavior)
        {
			Debug.Log ("hovering");
			resourceName.text = "PALM: ";
			resourceType.text = "PLANT SPECIES";
			resourceStat.text = "REHAB COSTS: + 4 FUEL";
		}
       
    }
}
