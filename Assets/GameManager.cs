using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static int globalTileCount;

	public List<GameObject> tiles;

	public List<Transform> floors;

	float averagex=0;
	float averagez=0;

	Camera mc;
	// Use this for initialization
	void Start () {
		globalTileCount = 0;

		floors = new List<Transform> ();

		mc = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.R)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
		Debug.Log ("There are currently " + globalTileCount + " tiles on the map");

		Debug.Log ("There are currently " + floors.Count + "floors in floors");

		//only want to zoom out if we are still building
		if (GameObject.FindObjectOfType<Pathmaker> ()) {
			foreach (Transform floor in floors) {

				Vector3 screenPoint = mc.WorldToViewportPoint(floor.position);
				bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
				if (onScreen == false) {
					mc.fieldOfView += 5;
				}
				averagex += floor.position.x;
				averagez += floor.position.z;





			
			}

		}
		else{
			averagex = averagex / floors.Count;
			averagez = averagez / floors.Count;

			mc.transform.position = new Vector3 (averagex, mc.transform.position.y, averagez);

		}
	








	}
}
