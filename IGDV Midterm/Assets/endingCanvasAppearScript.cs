using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingCanvasAppearScript : MonoBehaviour {

	public Canvas endingCanvas;

	public GameObject quest1;
	public GameObject quest2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (quest1.GetComponent<friendScript> ().questComplete == true &&
		    quest2.GetComponent<friendScript> ().questComplete == true) {
			endingCanvas.enabled = true;
		} else {
			endingCanvas.enabled = false;
		}
	}
}
