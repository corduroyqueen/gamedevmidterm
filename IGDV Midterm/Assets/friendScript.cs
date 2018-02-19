using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class friendScript : MonoBehaviour {

	public bool present;

	public bool c1Pressed;
	public bool cs1Pressed;
	public bool d1Pressed;
	public bool ds1Pressed;
	public bool e1Pressed;
	public bool f1Pressed;
	public bool fs1Pressed;
	public bool g1Pressed;
	public bool gs1Pressed;
	public bool a1Pressed;
	public bool as1Pressed;
	public bool b1Pressed;
	public bool c2Pressed;

	public bool quest1;
	public bool quest2;
	public bool quest3;

	public Canvas questText;

	public bool timerStart;
	public float timer;
	public int noteCount;
	public float timerWindow;

	public GameObject quest2song;

	public bool questComplete;

	public Text questTextObj;

	public bool questEnabled;

	// Use this for initialization
	void Start () {
		timerStart = false;
		timer = 0f;
		questEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (present) {
			questText.enabled = true;

			if (quest1) {
				if (Input.GetKeyDown (KeyCode.Z) && questEnabled) {
					c1Pressed = true;
				}
				if (Input.GetKeyDown (KeyCode.C) && c1Pressed) {
					e1Pressed = true;
				} else if (Input.GetKeyDown (KeyCode.C)) {
					c1Pressed = false;
					e1Pressed = false;
				}

				if (Input.GetKeyDown (KeyCode.B) && e1Pressed && c1Pressed) {
					g1Pressed = true;
				} else if (Input.GetKeyDown (KeyCode.B)) {
					c1Pressed = false;
					e1Pressed = false;
				}

				if (Input.GetKeyDown (KeyCode.Q) && e1Pressed && c1Pressed && g1Pressed) {
					c2Pressed = true;
				} else if (Input.GetKeyDown (KeyCode.Q)) {
					c1Pressed = false;
					e1Pressed = false;
					g1Pressed = false;
				}

				if (c2Pressed) {
					questComplete = true;
					questTextObj.GetComponent<Text> ().text = "Good job!!!";
					questEnabled = false;

				}
			}

			if (quest2) {
				
				if (Input.anyKeyDown && timerStart==false) {
					timerStart = true;
				}
				if (timerStart == true) {
					timer++;

					if (Input.GetKeyDown (KeyCode.Z) ||
					   Input.GetKeyDown (KeyCode.X) ||
					   Input.GetKeyDown (KeyCode.C) ||
					   Input.GetKeyDown (KeyCode.V) ||
					   Input.GetKeyDown (KeyCode.B) ||
					   Input.GetKeyDown (KeyCode.N) ||
					   Input.GetKeyDown (KeyCode.M) ||
					   Input.GetKeyDown (KeyCode.Q)) {

						noteCount += 1;
					}

					if (Input.GetKeyDown (KeyCode.S) ||
						Input.GetKeyDown (KeyCode.D) ||
						Input.GetKeyDown (KeyCode.G) ||
						Input.GetKeyDown (KeyCode.H) ||
						Input.GetKeyDown (KeyCode.J)) {

						noteCount -= 1;
					}

					if (timer > timerWindow && questEnabled==true) {

						if (noteCount > 35) {
							questComplete = true;
							questTextObj.GetComponent<Text> ().text = "Wow!! Amazing!";
							questEnabled = false;
						}

						if (noteCount <= 35){

						}


						timer = 0f;
						timerStart = false;
						noteCount = 0;
					}
				}
			}
		} else {
			questText.enabled = false;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "player") {
			present = true;
			if (quest2) {
				quest2song.GetComponent<AudioSource> ().Play ();
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "player") {
			present = false;
			if (quest2) {
				quest2song.GetComponent<AudioSource> ().Stop ();
			}
		}
	}
}
