using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMusicScript : MonoBehaviour {

	public AudioMixerSnapshot redMixerOn;
	public AudioMixerSnapshot redMixerOff;
	public AudioMixerSnapshot yellowMixerOn;
	public AudioMixerSnapshot yellowMixerOff;
	public AudioMixerSnapshot blueMixerOn;
	public AudioMixerSnapshot blueMixerOff;

	public bool playRed;
	public bool swapRed;
	public bool playYellow;
	public bool swapYellow;
	public bool playBlue;
	public bool swapBlue;

	// Use this for initialization
	void Start () {
		swapRed = false;
		swapYellow = false;
		swapBlue = false;
	}

	// Update is called once per frame
	void Update () {
		playRed = false;
		playYellow = false;
		playBlue = false;
		redMixerOff.TransitionTo(0);
		foreach (Player p in PlayerList.Instance.GetPlayers()) {
			if (p.GetIsFiring ()) {
				if (p.GetPlayerColor () == Player.ColorColor.Red) {
					playRed = true;
				} else if (p.GetPlayerColor () == Player.ColorColor.Yellow) {
					playYellow = true;
				} else {
					playBlue = true;
				}
			}
		}

		if (playRed != swapRed) {
			if (playRed)
				redMixerOn.TransitionTo (0);
			else
				redMixerOff.TransitionTo (0);
			swapRed = playRed;
		}

		if (playYellow != swapYellow) {
			if (playYellow)
				yellowMixerOn.TransitionTo (0);
			else
				yellowMixerOff.TransitionTo (0);
			swapYellow = playYellow;
		}

		if (playBlue != swapBlue) {
			if (playBlue) {
				blueMixerOn.TransitionTo (0);
			} else {
				blueMixerOff.TransitionTo (0);
			}
			swapBlue = playBlue;
		}

	}
}
