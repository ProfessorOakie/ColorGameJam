using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicScript : MonoBehaviour {

	public AudioMixerSnapshot gameIntro;
	public AudioMixerSnapshot gameMain;

	public static float BPM = 124;

	private float waitTime;

	// Use this for initialization
	void Start () {
		waitTime = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		waitTime++;
		if ((waitTime / 48) >= (16 / (BPM / 60))) {
			gameMain.TransitionTo (0);
		}
	}
}
