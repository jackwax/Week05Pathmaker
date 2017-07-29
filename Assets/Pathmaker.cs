using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathmaker : MonoBehaviour {

	public int counter;
	public Transform floorPrefab;
	public Transform pathmakerSpherePrefab;

	bool hallwaygenerate;

	List<string> roomtypes;


	string room;


	// Use this for initialization
	void Start () {
		roomtypes = new List<string> ();

		roomtypes.Add ("hallways");
		roomtypes.Add ("caves");
		roomtypes.Add ("random");

		counter = 0;
		int type = Random.Range (0, 3);

		room = roomtypes [type];



		print ("yeah");


		//Debug.Log ("This Pathmaker is building " + room);







	}
	
	// Update is called once per frame
	void Update () {
		pathmakerSpherePrefab.transform.position = this.transform.position;

		if (GameManager.globalTileCount < 500) {
			floorPrefab = GameObject.Find ("gM").GetComponent<GameManager> ().tiles [Random.Range(0,3)].transform;
				
			if (counter < 50) {
				float buddy = Random.Range (0f, 1f); //random number generator
				if (room == "hallways") {
					//print (buddy);
					if (buddy < 0.125f) { //turn to the right
						this.transform.Rotate (0f, 90f, 0);
					}
					if (buddy >= 0.125f && buddy <= 0.25f) { //turn to the left
						this.transform.Rotate (0f, -90f, 0);
					}
				}
				if (room == "caves") {
					if (buddy < 0.25f) { //turn to the right
						this.transform.Rotate (0f, 90f, 0);
					}
					if (buddy >= 0.25f && buddy <= 0.50f) { //turn to the left
						this.transform.Rotate (0f, -90f, 0);
					}
					
				}

				if (room == "random") {
					int turn = Random.Range (0, 3);
					if (turn == 0) {
						this.transform.Rotate (0f, 90f, 0);

					}
					if (turn == 1) {
						this.transform.Rotate (0f, -90f, 0);
					}
					
				}

				if (buddy >=0.98f && buddy <= 1.0f) {
					Instantiate (this);
				}
				Transform newFloor = Instantiate (floorPrefab, this.transform.position, this.transform.rotation);
				GameObject.Find ("gM").GetComponent<GameManager> ().floors.Add(newFloor);


	//				
				transform.Translate (Vector3.forward * 5);

			


				counter++;
				GameManager.globalTileCount++;

			} else {
				Destroy (this.gameObject);
			}
		} else {
			Destroy (this.gameObject);
		}
		
	}
}
