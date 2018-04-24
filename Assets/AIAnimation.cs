using UnityEngine;
using System.Collections;

public class AIAnimation : MonoBehaviour {
	public float minimumRunSpeed = 1.0F;
	public WrapMode wrapMode;

	public void Start () {
		// Set all animations to loop
		GetComponent<Animation>().wrapMode = WrapMode.Loop;

		// Except our action animations, Dont loop those
		//animation["ShootStraight"].wrapMode = WrapMode.Once;

		// Put idle and run in a lower layer. They will only animate if our action animations are not playing
		GetComponent<Animation>()["Idle"].layer =0;


		GetComponent<Animation>().Stop();
	}

	public void SetSpeed (float speed) {
		GetComponent<Animation>().CrossFade("Idle");
	}
}
