using UnityEngine;
using System.Collections;

public class audioScript : MonoBehaviour {

	public AudioClip clipOverruled;
	public AudioClip clipSustained;


	private AudioSource audioOverruled;
	private AudioSource audioSustained;


	public AudioSource AddAudio (AudioClip clip, bool loop,  float vol) {

		AudioSource newAudio = gameObject.AddComponent<AudioSource>();

		newAudio.clip = clip;
		newAudio.loop = loop;

		newAudio.volume = vol;

		return newAudio;

	}

	public void overruled(){
		// add the necessary AudioSources:
		audioOverruled = AddAudio(clipOverruled, true,  0.4f);
		audioOverruled.Play ();
	}

	public void sustained(){
		audioSustained = AddAudio(clipSustained, false,  0.4f);
		audioSustained.Play ();
	}
}
