using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour {

	// Public fields are visible and their values can be changed dirrectly in the editor
	
	// Drag and drop here the Voxel from the Scene
	// Used to create new instances
	public GameObject Voxel;
	public GameObject SandVoxel;
	
	//Specify the dimensions of the world
	public float GrassSizeX;
	public float GrassSizeZ;
	public float GrassSizeY;
	public float SandSizeX;
	public float SandSizeZ;
	public float SandSizeY;

	// Use this for initialization
	void Start () {

		// Start the world generation coroutine
		// StartCoroutine function always returns immediately, however you can yield the result. 
		//StartCoroutine(SimpleGenerator());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void CloneAndPlace(Vector3 newPosition, GameObject originalGameobject)
	{
		// Clone
		GameObject clone = (GameObject)Instantiate(originalGameobject, newPosition, Quaternion.identity);

		// Place
		clone.transform.position = newPosition;

		// Rename
		clone.name = "Voxel@" + clone.transform.position;

	}

	public static void CloneAndPlaceSand(Vector3 newPositionSand, GameObject originalGameobjectSand)
	{
		GameObject cloneSand = (GameObject)Instantiate(originalGameobjectSand, newPositionSand, Quaternion.identity);

		cloneSand.transform.position = newPositionSand;

		cloneSand.name = "SandVoxel@" + cloneSand.transform.position;
	}

	/* from docs.unity.com
		 * The execution of a coroutine can be paused at any point using the yield statement. 
		 * The yield return value specifies when the coroutine is resumed. 
		 * Coroutines are excellent when modelling behaviour over several frames. 
		 * Coroutines have virtually no performance overhead. 
		 * StartCoroutine function always returns immediately, however you can yield the result. 
		 * This will wait until the coroutine has finished execution.
		*/

	IEnumerator SimpleGenerator()
	{
		// In this Coroutine we will instantiate 50 voxels per frame
		uint numberOfInstances = 0;
		uint instancesPerFrame = 50;

		for(int x = 1; x <= SandSizeX; x++)
		{
			for(int z = 1; z<= SandSizeZ; z++)
			{
				// Compute a random height
				// float height = Random.Range(0, SizeY);
				for (int y = 2; y <= 2; y++)
				{
					// Compute the position for every voxel
					Vector3 newPositionSand = new Vector3(x, y, z);
					// Call the method giving the new position and a Voxel instance as parameters
					CloneAndPlace(newPositionSand, SandVoxel);
					// Increment numberOfInstances
					numberOfInstances++;
					
					// If the number of instances per frame was met
					if(numberOfInstances == instancesPerFrame)
					{
						// Reset numberOfInstances
						numberOfInstances = 0;
						// Wait for next frame
						yield return new WaitForEndOfFrame();
					}
				}
				
			}
			
		}

		for(int x = 1; x <= GrassSizeX; x++)
		{
			for(int z = 1; z<= GrassSizeZ; z++)
			{
				// Compute a random height
				// float height = Random.Range(0, SizeY);
				for (int y = 3; y <= 3; y++)
				{
					// Compute the position for every voxel
					Vector3 newPosition = new Vector3(x, y, z);
					// Call the method giving the new position and a Voxel instance as parameters
					CloneAndPlace(newPosition, Voxel);
					// Increment numberOfInstances
					numberOfInstances++;
					
					// If the number of instances per frame was met
					if(numberOfInstances == instancesPerFrame)
					{
						// Reset numberOfInstances
						numberOfInstances = 0;
						// Wait for next frame
						yield return new WaitForEndOfFrame();
					}
				}
				
			}
			
		}
	}

}
