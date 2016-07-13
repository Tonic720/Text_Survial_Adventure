using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Survial_Game : MonoBehaviour {

	string currRoom = "Bedroom";

	//Booleans for gameplay
	bool hasBasementKey = false;
	bool hasHouseKey = false;
	bool wakeUp = false;
	bool masterBedroomEnterFirst = false;
	bool masterBedroomEnterSecond = false;
	bool captured  = false;
	bool chased = false;
	bool noteFound = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		string textBuffer = "Your are currently in: " + currRoom;
		if (currRoom == "Bedroom") {
			// add lobby code
			if (wakeUp == false) {
				textBuffer += "\nYou wake up in a strange room.";

			}
			if (wakeUp == true && chased == true) {
				
				textBuffer += "\nYou got away for now.";
				textBuffer += "\nYou see a note under the bed.";
				textBuffer += "\nIt reads to get out of here alive \nget to the basement \nfind the key is in his room.";
				noteFound = true;

				
			}
			if (noteFound == true && chased == false) {
				textBuffer += "\nthe room is empty.";
				
			}
			if (noteFound == false && chased == false) {
				textBuffer += "\nthe room is empty.";
			}



			textBuffer += "\npress [W] to exit room";


			if (Input.GetKeyDown (KeyCode.W)) {
				currRoom = "Hallway";
				wakeUp = true;
				chased = false;

			} 


		} else if (currRoom == "Hallway") {
			if (chased == false) {
				textBuffer += "\nthe house seems empty.";
				textBuffer += "\npress [S] to go into bedroom";
				textBuffer += "\npress [W] to go into the master bedroom";
				textBuffer += "\npress [X] to go into the Living room";

				if (Input.GetKeyDown (KeyCode.S)) {
					currRoom = "Bedroom";
				} else if (Input.GetKeyDown (KeyCode.W)) {
					currRoom = "MasterBedroom";
				}else if (Input.GetKeyDown (KeyCode.X)) {
					currRoom = "LivingRoom";

				}
			} else {
				textBuffer += "\nhes after you get away.";
				textBuffer += "\npress [S] to go hide in the bedroom";
				textBuffer += "\npress [X] to go hide in the living room";
				if (Input.GetKeyDown (KeyCode.S)) {
					currRoom = "Bedroom";

				} else if (Input.GetKeyDown (KeyCode.X)) {
					currRoom = "LivingRoom";

				}

			}


		} else if (currRoom == "MasterBedroom") {
			
			if (masterBedroomEnterFirst == false) {
				textBuffer += "\nYou enter the room an see a man standing in the corner";
				textBuffer += "\nas you get closer you see him Shia LaBeouf!!!";
				textBuffer += "\nHe stares at your with cold blank expression.";
				textBuffer += "\npress [S] run away";
				textBuffer += "\npress [W] to say you were horrible in Indiana Jones";

				if (Input.GetKeyDown (KeyCode.S)) {
					currRoom = "Hallway";
					chased = true;
					masterBedroomEnterFirst = true;
				} else if (Input.GetKeyDown (KeyCode.W)) {
					currRoom = "Basement";
					captured = true;
				}
			}if (masterBedroomEnterFirst == true && masterBedroomEnterSecond == false) {
				if (hasBasementKey == false) {
					textBuffer += "\nYou enter the room an see key on his desk";
					textBuffer += "\npress [W] to grab it and leave";
					if (Input.GetKeyDown (KeyCode.W)) {
						hasBasementKey = true;
						currRoom = "Hallway";
						masterBedroomEnterSecond = true;

					}
				}

				
			}
			if (masterBedroomEnterFirst == true && masterBedroomEnterSecond == true){
				textBuffer += "\nTheres nothing else in here.";
				textBuffer += "\npress [S] to go to the hallway";
				if (Input.GetKeyDown (KeyCode.S)) {
					currRoom = "Hallway";


				}

			}





		} else if (currRoom == "Basement") {




			if (captured == true) {
				textBuffer += "\nShia LaBeouf has knocked you out and dragged you to his basement";

				textBuffer += "\nShia LaBeouf has captured you";
				textBuffer += "\npress [W] to try again";
				if (Input.GetKeyDown (KeyCode.W)) {
					currRoom = "Bedroom";
					hasBasementKey = false;
					hasHouseKey = false;
					wakeUp = false;
					masterBedroomEnterFirst = false;
					masterBedroomEnterSecond = false;
					captured  = false;
					chased = false;
					noteFound = false;

				}
			}
			if (captured == false && hasHouseKey == false) {
				textBuffer += "\nYou see a pile of movies that Shia LeBeouf starred in";

				textBuffer += "\nyou See a key under the movies \npress [S] to grab it and get out of here";

				if (Input.GetKeyDown (KeyCode.S)) {
					hasHouseKey = true;
					currRoom = "LivingRoom";
				}
				
				
				
			}
			if (hasHouseKey == true) {
				textBuffer += "\nNothing else in here";
			}


		}
		else if(currRoom == "LivingRoom"){
			if (chased == true) {
				textBuffer += "\nYou might have gotten away";
				textBuffer += "\npress [W] to look behind you";
				if (Input.GetKeyDown (KeyCode.W)) {
					currRoom = "Basement";
					captured = true;
				} 


			}
			if (chased == false) {
				
				textBuffer += "\npress [W] to go to hallway";
				textBuffer += "\npress [S] to into the basement door";
				textBuffer += "\npress [X] to go outside";
				if (Input.GetKeyDown (KeyCode.W)) {
					currRoom = "Hallway";

				}
				if (hasBasementKey == false) {
					textBuffer += "\nthe basment door is locked";
					

				}
				if (hasHouseKey == false) {
					textBuffer += "\nthe door to freedom is locked";


				}
				if (Input.GetKeyDown (KeyCode.S) && hasBasementKey == true) {
					currRoom = "Basement";


				}
				if (Input.GetKeyDown (KeyCode.X) && hasHouseKey == true) {
					currRoom = "Outside";


				}

			} 


			


		}
		else if (currRoom == "Outside"){

			textBuffer += "\nYou've done it";
			textBuffer += "\nYou've escaped from Shia LeBeouf for now...";

		}
		GetComponent<Text> ().text = textBuffer;


	}
}
