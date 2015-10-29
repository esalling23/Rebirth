using UnityEngine;
using System.Collections;

public delegate float islandCreator ();

public class IslandCreator : MonoBehaviour {

//	public bool collided = false;
//	private bool enumRunning;


//	public GameObject newGrassCube;
//	public GameObject grassCube;
//	public GameObject sandCube;
//	public GameObject oilSpillCube;
//	public GameObject oceanCube;

//	public GameObject platform;

//	public float islandHeight;
//	public float islandWidth;
//	public float islandLength;

	public float spawnSpeed = 0;
	
	// Public fields are visible and their values can be changed dirrectly in the editor
		
	// Drag and drop here the Voxel from the Scene
	// Used to create new instances
	public GameObject Voxel;
//	public GameObject SandVoxel;
//	public GameObject OilSpillVoxel;
//	public GameObject OceanVoxel;

	//public GameObject NewGrassVoxel;

	// put the first material here.

//	bool Original = true;
//	bool Change1 = false;
//	bool Change2 = false;
//	bool Final = false;

	//public Renderer renderer;

	//Specify the dimensions of the world
//	public float GrassSizeX;
//	public float GrassSizeZ;
//	public float GrassSizeY;
//
//	public float SandSizeX;
//	public float SandSizeZ;
//	public float SandSizeY;
//
//	public float OilSpillSizeX;
//	public float OilSpillSizeZ;
//	public float OilSpillSizeY;
//
//	public float OceanSizeX;
//	public float OceanSizeZ;
//	public float OceanSizeY;

//	public float NewGrassSizeX;
//	public float NewGrassSizeZ;
//	public float NewGrassSizeY;
	
	// Use this for initialization
	void Start () {

//		renderer.material = OilSpillOriginal;

		// Start the world generation coroutine
		// StartCoroutine function always returns immediately, however you can yield the result. 
//		Debug.Log ("SimpleGenerator() has started");
//		StartCoroutine(SimpleGenerator());
//		Debug.Log ("SimpleGenerator() has finished");

		//StartCoroutine (CheckForCollision ());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	void OnTriggerEnter() {
////		collided = true;
//	}
//	
//	IEnumerator CheckForCollision() {
////		yield return null;
////		Debug.Log (collided);
//		
//	}

//	public static void CloneAndPlaceNewGrass(Vector3 newPositionNewGrass, GameObject originalGameobject)
//	{
//		// Clone
//		GameObject cloneNewGrass = (GameObject)Instantiate(originalGameobject, newPositionNewGrass, Quaternion.identity);
//		
//		// Place
//		cloneNewGrass.transform.position = newPositionNewGrass;
//		
//		// Rename
//		cloneNewGrass.name = "NewGrassVoxel@" + cloneNewGrass.transform.position;
//		
//	}

	public static void CloneAndPlace(Vector3 newPosition, GameObject originalGameobject)
	{
		// Clone
		GameObject clone = (GameObject)Instantiate(originalGameobject, newPosition, Quaternion.identity);
		
		// Place
		clone.transform.position = newPosition;
		
		// Rename
		clone.name = "Voxel@" + clone.transform.position;

		//clone.AddComponent<Animator> ("GrassGrow");



		//
		//clone.transform(Vector3.up * Time.deltaTime, Space.World);
		
	}
	
//	public static void CloneAndPlaceSand(Vector3 newPositionSand, GameObject originalGameobjectSand)
//	{
//		GameObject cloneSand = (GameObject)Instantiate(originalGameobjectSand, newPositionSand, Quaternion.identity);
//		
//		cloneSand.transform.position = newPositionSand;
//		
//		cloneSand.name = "SandVoxel@" + cloneSand.transform.position;
//	}
//
//	public static void CleanUpOilSpill(Vector3 newMatericalOilSpill, Texture originalMaterialOilSpill)
//	{
//
//	}



}
