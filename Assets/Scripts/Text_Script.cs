using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Text_Script : MonoBehaviour {

	string currRoom = "Lobby";
	bool hasStudentID = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string textBuffer = "Your are currently in: " + currRoom;
		if (currRoom == "Lobby") {
			// add lobby code
			textBuffer += "\nYou see the security guard.";
			textBuffer += "\npress [W] to go to elvators";
			textBuffer += "\npress [S] to go outside";

			if (Input.GetKeyDown (KeyCode.W)) {
				currRoom = "Elevators";
			} else if (Input.GetKeyDown (KeyCode.S)) {
				currRoom = "Outside";
			}


		} else if (currRoom == "Elevators") {
			textBuffer += "\nYour waiting.";

			if (hasStudentID == false) {
				textBuffer += "\nYou can't go in without an id.";
			} else {
				textBuffer += "\nYou swipe your id and the guard smiles";
			}
			// add elevator code
		} else if(currRoom == "Outside"){
			// add outside code
			textBuffer += "\nIT'S HOT OUTSIDE WHAT IS WRONG WITH YOU";
			textBuffer += "\npress [S] to go back to the lobby Right now.";
			textBuffer += "\nbut wait you found an id on the ground.";

			hasStudentID = true;
			if (Input.GetKeyDown (KeyCode.S)) {
				currRoom = "Lobby";
			}
			
		}
		GetComponent<Text> ().text = textBuffer;

	
	}
}
