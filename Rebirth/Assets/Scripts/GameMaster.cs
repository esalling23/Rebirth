using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ResourceScreen : MonoBehaviour {

	public Text playerStats;
	public GameObject Player;

	public int health = 20;
	public int currenthealth;
	public int currentfuel;
	public int minfuel = 0;
	public int trashRemaining;
	public int oilRemaining;

	private bool inWater = false;
	private bool dead = false;
	
	// Use this for initialization
	void Awake () {
		currenthealth = health;
		currentfuel = minfuel;

		if (inWater = true) {
			Health (1);
		}

		Events.instance.AddListener<ClickResourceEvent>
			(OnClickResourceEvent);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Ocean") {
			inWater = true;
			Health (1);
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.tag == "Ocean") {
			inWater = false;
		}
	}

	void Health(int loss) {
		currenthealth -= loss;

		if (currenthealth == 0) {
			Debug.Log("dead");
			dead = true;
		}
	}


	void OnClickResourceEvent(ClickResourceEvent e) {
		if (e.resource is GrassBehavior) {
			if (currentfuel > 0) {
				grassAccess.Behavior();
				currentfuel -= 1;
			} else {
				//play reject sound
				//reject message
			}
		}
		if (e.resource is OilBehavior) {
			if (currentfuel < 10) {
				OilBehavior.Behavior();
				currentfuel += 2;
			} else {
				//play reject sound
				//reject message
			}
		}
		if (e.resource is MangroveBehavior) {

		}
		if (e.resource is TrashBehavior)
		{
			if (currentfuel < 10) {
				TrashBehavior.Behavior();
				currentfuel += 2;
			} else {
				//play reject sound
				//reject message
			}
		}
		if (e.resource is PalmBehavior)
		{

		}
		
	}     

}
