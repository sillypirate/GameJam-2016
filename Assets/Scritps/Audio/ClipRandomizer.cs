using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClipRandomizer : MonoBehaviour {

	public AudioSource source;
	public List<AudioClip> clips;
	public List<int> availableIndexes;

	// Use this for initialization
	void Start () {
		refreshAvailableIndexes ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void refreshAvailableIndexes(){
		if (availableIndexes.Count > 0) {
			availableIndexes.Clear ();
		}
		if (clips.Count < 1) {
			Debug.Log ("No AudioSources assigned in List on ClipRandomizer component");
		}
		for (int i = 0; i < clips.Count; i++) {
			availableIndexes.Add (i);
		}
	}

	void playRandomFromClips(bool noRepeats){
		if (availableIndexes.Count < 1) {
			refreshAvailableIndexes ();
		}
			
		if (noRepeats) {
			int randIndex = Mathf.RoundToInt (Random.Range (0, availableIndexes.Count));
			int clipIndex = availableIndexes [randIndex];
			source.PlayOneShot (clips[clipIndex]);
			availableIndexes.RemoveAt (randIndex);
		} else {
			int clipIndex = Mathf.RoundToInt (Random.Range (0, clips.Count));
			source.PlayOneShot (clips[clipIndex]);
		}
	}

	public void playRandomClip(){
		playRandomFromClips (true);
	}

	public void playRandomClipDelayed(){
		Invoke ("playRandomClip", 0.05f);
	}
}
