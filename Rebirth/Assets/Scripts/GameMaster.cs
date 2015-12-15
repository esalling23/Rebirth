using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	public static GameMaster accessGM; 

	public Slider healthslider;
	public Slider fuelslider;
	
	public Text fuelcount;
	public Text healthcount;
	//public Text playerStats;
	public GameObject Player;
	public GameObject deadScreen;
	
	private int maxhealth = 25;
	public int currenthealth;

	public int currentfuel;
	private int maxfuel = 10;

	public GameObject grass;
	private bool grassAppear = false;
	public GameObject grassTwo;
	private bool grassTwoAppear = false;
	public GameObject grassThree;
	private bool grassThreeAppear = false;
	public GameObject palms;
	private bool palmsAppear = false;
	public GameObject palmsTwo;
	private bool palmsTwoAppear = false;
	public GameObject palmsThree;
	private bool palmsThreeAppear = false;

	public int trashStart = 12;
	public int trashRemaining;
	public int bigTrashStart = 9;
	public int bigTrashRemaining;
	public int oilStart = 35;
	public int oilRemaining;
	public int grassRemaining;
	public int grassStart = 16;
	public int mangroveStart = 8;
	public int mangroveRemaining;
	public int palmStart = 4;
	public int palmRemaining;
	
	private int rate = 10;

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
		if (currenthealth <= 0) {
			currenthealth = 0;
		}
		if (inWater == true) {
			if (currenthealth == 0 && dead == false) {
				Debug.Log ("gonna die");
				Dead ();
			} else {
				Debug.Log("starting");
				StartCoroutine (healthLoss);
			}
		} else {
			StopCoroutine (healthLoss);
		}
		if (inDeepWater == true) {
			if (currenthealth == 0 && dead == false) {
				Debug.Log ("gonna die");
				//dead = true;
				Dead ();
			} else {
				Debug.Log("starting again");
				StartCoroutine(healthLoss);
			}

		} else {
			StopCoroutine (healthLoss);

		}
		if (heal == true) {
			Debug.Log("starting heal");

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

		healthLoss = HealthLoss(1);
		healthGain = HealthGain (1);

		Events.instance.AddListener<ClickResourceEvent>
			(OnClickResourceEvent);

		//grassanim = grass.GetComponent<Animator>();
		//palmsanim = palms.GetComponent<Animator>();

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
			for (currenthealth = maxhealth; currenthealth >= 0; currenthealth -= 2 / rate) {
				yield return new WaitForSeconds(waitTime);
				healthslider.value = currenthealth;
				healthcount.text = currenthealth.ToString();
				Debug.Log (currenthealth);
				//yield return null;

		}
	}

	IEnumerator HealthGain (float waitTime) {
		for (currenthealth = maxhealth; currenthealth >= 0; currenthealth += 1 / rate) {
			yield return new WaitForSeconds(waitTime);
			healthslider.value = currenthealth;
			healthcount.text = currenthealth.ToString();
			Debug.Log (currenthealth);
			//yield return null;
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
				Fuel (-2);
				Debug.Log (currentfuel + " fuel and " + grassRemaining + " grass remaining");
				if (grassRemaining == grassStart/4 && palmsAppear == false) {
					Debug.Log ("palms appearing");
					iTween.MoveBy(palms,iTween.Hash(
						"y"   , .2,
						"time", 2f
						));
					palmsAppear = true;
					Debug.Log (palmsAppear);
				}
				if (grassRemaining == grassStart/2 && grassTwoAppear == false) {
					Debug.Log ("grass2 appearing");
					iTween.MoveBy(grassTwo,iTween.Hash(
						"y"   , .1,
						"time", 2f
						));
					grassRemaining = grassRemaining + grassStart;
					grassTwoAppear = true;
					Debug.Log (grassTwoAppear);
				}
				if (grassRemaining == 0 && grassThreeAppear == false) {
					Debug.Log ("grass3 appearing");
					iTween.MoveBy(grassThree,iTween.Hash(
						"y"   , .1,
						"time", 2f
						));
					grassRemaining = grassRemaining + grassStart;
					grassThreeAppear = true;
					Debug.Log (grassThreeAppear);
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
				if (currentfuel == 8 && grassAppear == false) {
					Debug.Log ("grass appearing");
					iTween.MoveBy(grass,iTween.Hash(
						"y"   , .1,
						"time", 1f
						));
					grassAppear = true;
					Debug.Log (grassAppear);

				}
			} else {
				Debug.Log ("NO!");

				//play reject sound
				//reject message
			}
		}
		if (e.resource is MangroveBehavior) {
			if (currentfuel > 0) {
				if (mangroveRemaining == 9) {
					shrimpRemaining -= 1;
					Fuel (-10);
					Debug.Log (currentfuel + " fuel and " + shrimpRemaining + " shrimp remaining");
				} else {
					mangroveRemaining -= 1;
					Fuel (-8);
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
				if (currentfuel == 9 && grassAppear == false) {
					Debug.Log ("grass appearing");
					iTween.MoveBy(grass,iTween.Hash(
						"y"   , .1,
						"time", 1f
						));
					grassAppear = true;
					Debug.Log (grassAppear);
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
