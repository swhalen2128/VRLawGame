using UnityEngine;
using System.Collections;

public class testcontrol : MonoBehaviour {

	public GameObject panelinfo;

	// Use this for initialization
	void Start () {

		panelinfo = GameObject.FindGameObjectWithTag("info");
		panelinfo.SetActive(false);
	
	}

	// Update is called once per frame
	void Update () {

		//GameManager.Instance.changeTime ();
		
		//if (Input.GetButtonDown ("Fire1")) {
		//	transform.Rotate (transform.rotation.eulerAngles + new Vector3 (0f, 0.1f, 0f));
	
		//}

		//float h = Input.GetAxis ("Horizontal");
		//float v = Input.GetAxis ("Vertical");

		//transform.position += new Vector3 (h, v, 0f);
	}


}
