using UnityEngine;
using UnityEngine.UI; // <-- you need this to access UI (button in this case) functionalities

public class ButtonListener : MonoBehaviour {
	Button myButton;

	void Awake()
	{
		myButton = GetComponent<Button>(); // <-- you get access to the button component here

		myButton.onClick.AddListener( () => {myFunctionForOnClickEvent("stringValue", 4.5f);} );  // <-- you assign a method to the button OnClick event here
		myButton.onClick.AddListener(() => {myAnotherFunctionForOnClickEvent("stringValue", 3);});// <-- you can assign multiple methods
	
	}

	public void myFunctionForOnClickEvent(string argument1, float argument2)
	{
		// your code goes here
		print(argument1 + ", " + argument2.ToString());
	}

	public void myAnotherFunctionForOnClickEvent(string argument1, int argument2)
	{
		// your code goes here
		print(argument1 + ", " + argument2.ToString());
	}

	public void onclicker()
	{
		Debug.Log ("we can access the button Listener");
	}
}