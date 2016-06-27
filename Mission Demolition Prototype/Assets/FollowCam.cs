﻿using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	//singleton is a design pattern that is used when there will be only one instance of a specific class in the game
	static public FollowCam S;	//a FollowCam Singleton

	//fields set in the Unity Inspector pane
	public float easing = 0.05f;
	public Vector2 minXY;
	public bool ____________;

	//fields set dynamically
	public GameObject poi;	//the point of interest
	public float camZ;	//the desired Z pos of the camera

	void Awake() {
		S = this;
		camZ = this.transform.position.z;
	}

	void FixedUpdate() {
		//if there's only one line following an if, it doesn't need braces
		if (poi == null)
			return;	//return if there is no poi

		//get the position of the poi
		Vector3 destination = poi.transform.position;
		//limit the X & Y to minimum values
		destination.x = Mathf.Max (minXY.x, destination.x);
		destination.y = Mathf.Max (minXY.y, destination.y);
		//interpolate from the current Camera position toward destination
		destination = Vector3.Lerp (transform.position, destination, easing);
		//retain a destination.z of camZ
		destination.z = camZ;
		//set the camera to the destination
		transform.position = destination;
		//set the orthographicSize of the Camera to keep Ground in view
		this.camera.orthographicSize = destination.y + 10;
	}

}
