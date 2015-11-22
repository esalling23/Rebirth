using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ResourceScreen : MonoBehaviour {

	public GameObject OilInfo;
	//public GameObject TrashInfo;
	public GameObject GrassInfo;
	//public GameObject FernInfo;
	//public GameObject PalmInfo;
	//public GameObject PineInfo;
	public GameObject MangroveInfo;


	// Use this for initialization
	void Awake () {
		Events.instance.AddListener<ClickResourceEvent>
			(OnClickResourceEvent);
	}

	void OnClickResourceEvent(ClickResourceEvent e) {
		if (e.resource is GrassBehavior) {
			GrassInfo.SetActive(true);
		}
		if (e.resource is OilBehavior) {
			OilInfo.SetActive(true);
		}
		if (e.resource is MangroveBehavior) {
			MangroveInfo.SetActive(true);
		}
	}
}
