using UnityEngine;
using System.Collections;

public class buttonClick : MonoBehaviour {

	public GameObject panelinfo;
	public GameObject question1;
	// Use this for initialization
	void Start () {

		panelinfo = GameObject.FindGameObjectWithTag("info");
		panelinfo.SetActive(false);
		question1 = GameObject.FindGameObjectWithTag("adfasdf");
		question1.SetActive (false);
	}

	// Update is called once per frame
	void Update () {

//		if (GameManager.Instance.Question1 == )
//		{
//			if (Input.GetButtonDown ("Fire1")) {
//				Debug.Log ("state 0 test click");
//				if (question1 == true)
//					GameManager.Instance.SetGameState (GameState.TurnCorrect);
//				else {
//					GameManager.Instance.SetGameState (GameState.TurnWrong);
//				}
//					
//			} 
//
//			else {
//				//do nothing
//			}
//		}


		}

		

}