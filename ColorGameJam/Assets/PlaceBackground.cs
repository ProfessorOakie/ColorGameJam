using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBackground : MonoBehaviour {

	public GameObject viewport;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (viewport.transform.position.x, viewport.transform.position.y, viewport.transform.position.y + 30);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
