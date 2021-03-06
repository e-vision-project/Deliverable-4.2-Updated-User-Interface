﻿//MAPNAV Navigation ToolKit v.1.5.0
using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if(other.tag == "Player"){
			GetComponent<AudioSource>().Play();
		}
	}
	void OnTriggerExit (Collider other) {
		if(other.tag == "Player"){
			GetComponent<AudioSource>().Stop();
		}
	}
}
