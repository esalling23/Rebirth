using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ResourceScreen : MonoBehaviour {

	public Text playerStats;

	private int health;
	private int fuel;
	private int trashRemaining;
	private int oilRemaining;

	
	// Use this for initialization
	void Awake () {
		Events.instance.AddListener<ClickResourceEvent>
			(OnClickResourceEvent);
	}
	
	void OnClickResourceEvent(ClickResourceEvent e) {
		if (e.resource is GrassBehavior) {
			
		}
		if (e.resource is OilBehavior) {

		}
		if (e.resource is MangroveBehavior) {

		}
		if (e.resource is TrashBehavior)
		{

		}
		if (e.resource is PalmBehavior)
		{

		}
		
	}
}
