using UnityEngine;
using System.Collections;

public class DNASpotPlacement : MonoBehaviour {

	private GameObject explorableOcean;
	public GameObject oceanDNAPrefab;
	public float exploreWidth;
	public float exploreLength;

	public int loopRandom;
	public int loopMin;
	public int loopMax;

	// Use this for initialization
	void Start () {
		explorableOcean = GameObject.FindGameObjectWithTag ("ExploreOcean");
		exploreWidth = Mathf.Round(Random.Range (8F, 12F));
		exploreLength = Mathf.Round(Random.Range (8F, 14F));
		explorableOcean.transform.localScale += new Vector3 (exploreWidth, 1F, exploreLength);
		Debug.Log (explorableOcean.transform.localScale.x.ToString ()); 
		Debug.Log (explorableOcean.transform.localScale.z.ToString ()); 


		loopMin = Random.Range (3, 12);
		loopMax = Random.Range (24, 32);
		loopRandom = Random.Range (loopMin, loopMax);
		Debug.Log (loopMin.ToString ());
		Debug.Log (loopMax.ToString ());
		Debug.Log (loopRandom.ToString ());
		for (int i = 0; i < loopRandom; i++) {
			SpawnDNASpot ();

		}

	}

	void SpawnDNASpot(){
		Vector3 position = new Vector3(Random.Range(-exploreWidth, exploreWidth), 1, Random.Range(-exploreLength, exploreLength));
		Instantiate (oceanDNAPrefab, position, Quaternion.identity);
	}


	// Update is called once per frame
	void Update () {
		
	}
}
