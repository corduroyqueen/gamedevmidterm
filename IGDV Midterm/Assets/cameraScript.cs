using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	public GameObject target;//the target object
	private float speedMod = 10.0f;//a speed modifier
	private Vector3 point;//the coord to the point where the camera looks at
	private Vector3 direction;

	void Start () {//Set up things on the start method
		//get target's coords
		transform.LookAt(point);//makes the camera look to it
	}

	void Update () {//makes the camera rotate around "point" coords, rotating around its Y axis, 20 degrees per second times the speed modifier
		point = target.transform.position;
		transform.LookAt(point);

		if (Input.GetKey(KeyCode.RightArrow))
		{
			direction = new Vector3(0.0f, -1.0f, 0.0f);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			direction = new Vector3(0.0f, 1.0f, 0.0f);
		}
		else
		{
			direction = new Vector3(0.0f, 0.0f, 0.0f);
		}

		transform.RotateAround (point,direction,20 * Time.deltaTime * speedMod);
	}
}
