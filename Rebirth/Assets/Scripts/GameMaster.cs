using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	public static GameMaster accessGameMaster; 

	public Slider healthslider;
	public Slider fuelslider;
	
	public Text fuelcount;
	public Text healthcount;
	//public Text playerStats;
	public GameObject Player;
	public GameObject deadScreen;
	
	private int maxhealth = 25;
	private int currenthealth;

	private int currentfuel;
	private int maxfuel = 10;

	public GameObject grass;
	public GameObject palms;

	public int trashRemaining = 12;
	public int bigTrashRemaining = 9;
	public int oilRemaining = 35;
	public int grassRemaining = 16;
	public int mangroveRemaining = 8;
	public int palmRemaining = 4;

	private int shrimpRemaining = 8;
	
	private bool inWater = false;
	private bool inDeepWater = false;
	private bool heal = false;
	private bool dead = false;

	private IEnumerator healthLoss;	
	private IEnumerator healthGain;

	//public float timeBetweenHealthUpdate = 10f;
	//float Timer;

	void Update () {
		if (currenthealth < 0) {
			currenthealth = 0;
		}
		if (inWater == true && inDeepWater == true) {
			StartCoroutine (healthLoss);
			//Health (-1);
		} else {
			StopCoroutine (healthLoss);
		}
		if (inDeepWater == true && inWater == false) {
			StartCoroutine(healthLoss);

		} else {
			StopCoroutine (healthLoss);

		}
		if (heal == true) {
			StartCoroutine (healthGain);
			//Health 
		}  else {
			StopCoroutine (healthGain);
		}

		//Timer += Time.deltaTime;
	}

	// Use this for initialization
	void Awake () {
		currenthealth = maxhealth;
		healthslider.value = currenthealth;
		healthcount.text = currenthealth.ToString();

		currentfuel = 0;
		fuelslider.value = currentfuel;
		fuelcount.text = currentfuel.ToString();

		healthLoss = HealthLoss(400 * Time.deltaTime);
		healthGain = HealthGain (200 * Time.deltaTime);

		Events.instance.AddListener<ClickResourceEvent>
			(OnClickResourceEvent);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "ShallowOcean") {
			Debug.Log ("in ocean");
			inWater = true;
			//Health (-1);
		}
		if (other.tag == "DeepOcean") {
			Debug.Log ("in deep ocean");
			inDeepWater = true;
			//Health (-2);
		}
		if (other.tag == "ground" && currenthealth < maxhealth) {
			Debug.Log ("healing");
			heal = true;
			//Health (1);
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.tag == "ShallowOcean") {
			inDeepWater = false;
		}
		if (other.tag == "DeepOcean") {
			inWater = false;
		}
	}

	IEnumerator HealthLoss (float waitTime) {
		if (currenthealth == 0 && dead == false) {
			Debug.Log ("gonna die");
			Dead ();
		} else {
			for (currenthealth = maxhealth; currenthealth >= 0; currenthealth--) {
				healthslider.value = currenthealth;
				healthcount.text = currenthealth.ToString();
				Debug.Log (currenthealth);
				//yield return null;
				yield return new WaitForSeconds(waitTime);
			}
		}
	}

	IEnumerator HealthGain (float waitTime) {
		for (currenthealth = maxhealth; currenthealth >= 0; currenthealth++) {
			healthslider.value = currenthealth;
			healthcount.text = currenthealth.ToString();
			Debug.Log (currenthealth);
			//yield return null;
			yield return new WaitForSeconds(waitTime);
		}
	}


	public void Dead() {
		Debug.Log ("dead");
		dead = true;
		deadScreen.SetActive (true);
		Player.GetComponent<CharacterMotorC> ().enabled = false;
	}

	public void Fuel(int num) {
		currentfuel += num;
		fuelslider.value = currentfuel;
		fuelcount.text = currentfuel.ToString();
	}


	
	void OnClickResourceEvent(ClickResourceEvent e) {
		if (e.resource is GrassBehavior) {
			if (currentfuel > 0) {
				grassRemaining -= 1;
				Fuel (-1);
				Debug.Log (currentfuel + " fuel and " + grassRemaining + " grass remaining");
				if (grassRemaining == 0) {
					palms.transform.Translate(Vector3.up * Time.deltaTime); 
				}
			} else {
				Debug.Log ("NO!");
				//play reject sound
				//reject message
			}
		}
		if (e.resource is OilBehavior) {
			if (currentfuel < maxfuel) {
				oilRemaining -= 1;
				Fuel (2);
				Debug.Log (currentfuel + " fuel and " + oilRemaining + " oil remaining");
				if (oilRemaining == 0 && trashRemaining == 0) {
					grass.transform.Translate(Vector3.up * Time.deltaTime); 
				}
			} else {
				Debug.Log ("NO!");

				//play reject sound
				//reject message
			}
		}
		if (e.resource is MangroveBehavior) {
			if (currentfuel > 0) {
				if (mangroveRemaining == 0) {
					shrimpRemaining -= 1;
					Fuel (-6);
					Debug.Log (currentfuel + " fuel and " + shrimpRemaining + " shrimp remaining");
				} else {
					mangroveRemaining -= 1;
					Fuel (-4);
					Debug.Log (currentfuel + " fuel and " + mangroveRemaining + " mangrove remaining");
				}
			} else {
				Debug.Log ("NO!");

				//play reject sound
				//reject message
			}

		}
		if (e.resource is TrashBehavior)
		{
			if (currentfuel < maxfuel) {
				trashRemaining -= 1;
				Fuel (4);
				Debug.Log (currentfuel + " fuel and " + trashRemaining + " trash remaining");
				if (oilRemaining == 0 && trashRemaining == 0) {
					grass.transform.Translate(Vector3.up * Time.deltaTime); 
				}
			} else {
				Debug.Log ("NO!");

				//play reject sound
				//reject message
			}
		}
		if (e.resource is BigTrashBehavior)
		{
			if (currentfuel < 10) {
				bigTrashRemaining -= 1;
				Fuel (6);
				Debug.Log (currentfuel + " fuel and " + bigTrashRemaining + " bigTrash remaining");
			} else {
				Debug.Log ("NO!");

				//play reject sound
				//reject message
			}
		}
		if (e.resource is PalmBehavior)
		{
			if (currentfuel > 0) {
				palmRemaining -= 1;
				Fuel (-4);
				Debug.Log (currentfuel + " fuel and " + palmRemaining + " palms remaining");
			} else {
				Debug.Log ("NO!");

				//play reject sound
				//reject message
			}
		}

	}     

}
