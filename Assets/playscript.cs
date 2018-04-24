using UnityEngine;
using System.Collections;

public class playscript : MonoBehaviour {

	public GameObject option1609;

	// Use this for initialization
	void Start () {
		option1609 = GameObject.FindGameObjectWithTag("609option1");
		option1609.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

	
	}
}
