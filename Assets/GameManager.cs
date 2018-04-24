using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum GameState { 
	NullState, 
	Intro, 
	MainMenu, 


	Round1Question1, 
	Round1Question2, 
	Round1Question3,
	Round1Question4,
	Round1Question5, 
	Round1Question6, 
	Round1Question7,


	Round2Question1,
	Round2Question2,
	Round2Question3,
	Round2Question4,
	Round2Question5,

	Round3Question1,
	Round3Question2,
	Round3Question3,
	Round3Question4,
	Round3Question5,
	Round3Question6,
	Round3Question7,
	Round3Question8
}

public delegate void OnStateChangeHandler();




public class GameManager : MonoBehaviour {

	private static GameManager _instance = null;
	public event OnStateChangeHandler OnStateChange;
	public GameState gameState { get; private set; }
	public GameManager() {
		//rule 404
//		rule404Button1 = rule404Button1.GetComponent<Button> ();
//		rule404Button1.onClick.AddListener (buttonhandler);
//		rule404Button2 = rule404Button2.GetComponent<Button> ();
//		rule404Button2.onClick.AddListener (buttonhandler);
//		rule404Button3 = rule404Button3.GetComponent<Button> ();
//		rule404Button3.onClick.AddListener (buttonhandler);
//		rule404Button4 = rule404Button4.GetComponent<Button> ();
//		rule404Button4.onClick.AddListener (buttonhandler);

		//rule 405
//		Button rule405btn1 = rule405Button1.GetComponent<Button> ();
//		rule405btn1.onClick.AddListener (buttonhandler);
//		Button rule405btn2 = rule405Button2.GetComponent<Button> ();
//		rule405btn2.onClick.AddListener (buttonhandler);
//		Button rule405btn3 = rule405Button3.GetComponent<Button> ();
//		rule405btn3.onClick.AddListener (buttonhandler);
//		Button rule405btn4 = rule405Button4.GetComponent<Button> ();
//		rule405btn4.onClick.AddListener (buttonhandler);
//
//		//rule 608
//		Button rule608btn1 = rule608Button1.GetComponent<Button> ();
//		rule608btn1.onClick.AddListener (buttonhandler);
//		Button rule608btn2 = rule608Button2.GetComponent<Button> ();
//		rule608btn2.onClick.AddListener (buttonhandler);
//		Button rule608btn3 = rule608Button3.GetComponent<Button> ();
//		rule608btn3.onClick.AddListener (buttonhandler);
//		Button rule608btn4 = rule608Button4.GetComponent<Button> ();
//		rule608btn4.onClick.AddListener (buttonhandler);
//
//		//rule 609
//		Button rule609btn1 = rule609Button1.GetComponent<Button> ();
//		rule609btn1.onClick.AddListener (buttonhandler);
//		Button rule609btn2 = rule609Button2.GetComponent<Button> ();
//		rule609btn2.onClick.AddListener (buttonhandler);
//		Button rule609btn3 = rule609Button3.GetComponent<Button> ();
//		rule609btn3.onClick.AddListener (buttonhandler);
//		Button rule609btn4 = rule609Button4.GetComponent<Button> ();
//		rule609btn4.onClick.AddListener (buttonhandler);

	}

	public Text scoreText;
	public int score;
	public int angry;
	public float sizeX  = 100;
	public float sizeY  = 40;
	public float offsetY = 40;
	//public Text timerText;


	//No Objection
	public Button no_Objection;

	//Rule 404 buttons
//	public Button rule404Button1;
//	public Button rule404Button2;
//	public Button rule404Button3;
//	public Button rule404Button4;

//	//Rule 405 buttons
//	private Button rule405Button1;
//	private Button rule405Button2;
//	private Button rule405Button3;
//	private Button rule405Button4;
//
//	//Rule 608 buttons
//	private Button rule608Button1;
//	private Button rule608Button2;
//	private Button rule608Button3;
//	private Button rule608Button4;
//
//	//Rule 609 buttons
//	private Button rule609Button1;
//	private Button rule609Button2;
//	private Button rule609Button3;
//	private Button rule609Button4;



	// Singleton pattern implementation
	public static GameManager Instance {
		get {
			if (_instance == null) {
				_instance = new GameManager();
			}  
			return _instance;
		}
	}

	public void SetGameState(GameState gameState) {
		this.gameState = gameState;
		if(OnStateChange!=null) {
			OnStateChange();
		}
	}


	//public int score { get; set; }

//***********************************************************************//
//AUDIOOOOOOOOOOOOOOOOOO
//***********************************************************************//
//AudioSource audio;

public AudioClip clipOverruled;
public AudioClip clipSustained;
public AudioClip clipJudgeIntro;
public AudioClip clipQuestion1;
public AudioClip clipQuestion2;
public AudioClip clipQuestion3;
public AudioClip clipQuestion4;
public AudioClip clipQuestion5;


public AudioSource audioOverruled;
public AudioSource audioSustained;
public AudioSource audioJudgeIntro;
public AudioSource audioQuestion1;
public AudioSource audioQuestion2;
public AudioSource audioQuestion3;
public AudioSource audioQuestion4;
public AudioSource audioQuestion5;


public AudioSource AddAudio (AudioClip clip, bool loop,  float vol) {

	AudioSource newAudio = gameObject.AddComponent<AudioSource>();

	newAudio.clip = clip;
	newAudio.loop = loop;

	newAudio.volume = vol;

	return newAudio;

}
//***********************************************************************//
//AUDIOOOOOOOOOOOOOOOOOO END
//***********************************************************************//

	void Start()
	{
		_instance = this;

		score = 0;
		angry = 0;


		SetGameState (GameState.Intro);
		Debug.Log ("you are in the intro state");

		//Audio
		//audio = GetComponent<AudioSource>();
		audioOverruled = AddAudio(clipOverruled, false,  0.4f);
		audioSustained = AddAudio(clipSustained, false,  0.4f);
		audioJudgeIntro = AddAudio (clipJudgeIntro, false, 0.4f);
		audioQuestion1 = AddAudio (clipQuestion1, false, 0.4f);
		audioQuestion2 = AddAudio (clipQuestion2, false, 0.4f);
		audioQuestion3 = AddAudio (clipQuestion3, false, 0.4f);
		audioQuestion4 = AddAudio (clipQuestion4, false, 0.4f);
		audioQuestion5 = AddAudio (clipQuestion5, false, 0.4f);
			
		gameIntro ();
	
	}

//***********************************************************************//
//************************** Game Intro ********************************//
//*********************************************************************//
	void gameIntro(){
		switch (gameState)
		{

		case GameState.Intro:
			audioJudgeIntro.Play ();
			SetGameState (GameState.Round1Question1);
			Debug.Log ("You are in Game State Round1Question 1");
			audioQuestion1.PlayDelayed (65);
			break;
		}
	}



//***********************************************************************//
//********************* Timer Functions ********************************//
//*********************************************************************//
	void ResetTimer(){
		gameTimer game_Timer = GetComponent<gameTimer>();
		game_Timer.ResetTimer ();
		
	}


//***********************************************************************//
//	void updateJudgeBar()
//	{
//		health game_health = GetComponent<health>();
//		game_health.Update();
//	}
//
//***********************************************************************//
//********************* Score Functions ********************************//
//*********************************************************************//

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();

	}

	public void angryscore(int newAngryValue)
	{
		angry += newAngryValue;
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score.ToString();


	}

//	void onGUI()
//	{
//		scoreText.text = "Score: " + score.ToString();
//		GUI.Box (new Rect (Screen.width/2, Screen.height/2, sizeX, sizeY), "Score" + scoreText.text);
//	}

//***********************************************************************//
//********************* Button Handler *********************************//
//*********************************************************************//

	public void buttonhandler()//Button clickedbutton
	{
		Debug.Log ("button handler working");
		gameTimer game_Timer = GetComponent<gameTimer>();

		switch (gameState)
			{

//****************** ROUND ONE QUESTION ONE ************************************//
		case GameState.Round1Question1:
			
			Debug.Log ("You are in Game State Button Handler Round1Question 1");
			if (EventSystem.current.currentSelectedGameObject.name == "rule404btn3") {
				Debug.Log ("Question 1 Round 1 correct answer");
				AddScore (50);
				audioSustained.Play ();

			} else {
				Debug.Log ("Question 1 Round 1 wrong answer");
				audioOverruled.Play ();
				AddScore (-50);
				angryscore (1);
				ResetTimer();
			}
			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
			ResetTimer();
			audioQuestion2.PlayDelayed (3);
			SetGameState (GameState.Round1Question2);
			Debug.Log ("You changed Game State to Round1Question 2");
			break;

//****************** ROUND ONE QUESTION TWO ************************************//
		case GameState.Round1Question2:
			Debug.Log ("You are in Game State Round1Question 2");
			if (EventSystem.current.currentSelectedGameObject.name == "rule404btn3") {
				AddScore (10);
				audioSustained.Play ();
				Debug.Log ("Question 2 Round 1 correct answer");
			} else {
				Debug.Log ("Question 2 Round 1 wrong answer");
				AddScore (-10);
				audioOverruled.Play ();
				angryscore (1);

			}

			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
			ResetTimer();
			audioQuestion3.PlayDelayed (3);
			SetGameState (GameState.Round1Question3);

			Debug.Log ("You changed Game State to Round1Question 3");
			break;

//****************** ROUND ONE QUESTION THREE ************************************//
		case GameState.Round1Question3:
			Debug.Log ("You are in Game State Round1Question 3");
			if (EventSystem.current.currentSelectedGameObject.name == "rule404btn1") {
				Debug.Log ("Question 3 Round 1 correct answer");
				AddScore (50);
				audioSustained.Play ();


			} else {
				Debug.Log ("Question 3 Round 1 wrong answer");
				AddScore (-50);
				audioOverruled.Play ();
				angryscore (1);

			}
			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
			SetGameState (GameState.Round1Question4);
			audioQuestion4.PlayDelayed (5);
			game_Timer.ResetTimer();
			Debug.Log ("You changed Game State to Round1Question 4");
			break;

//****************** ROUND ONE QUESTION FOUR ************************************//
		case GameState.Round1Question4:
			Debug.Log ("You are in Game State Round1Question 4");
			if (EventSystem.current.currentSelectedGameObject.name == "noObjection") {
				AddScore (10);
				audioSustained.Play ();
				Debug.Log ("Question 4 Round 1 correct answer");
			} else {
				Debug.Log ("Question 4 Round 1 wrong answer");
				AddScore (-10);
				audioOverruled.Play ();
				angryscore (1);
			}
			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
			SetGameState (GameState.Round1Question5);
			audioQuestion5.PlayDelayed (5);
			game_Timer.ResetTimer();
			Debug.Log ("You changed Game State to Round1Question 5");
			break;

//****************** ROUND ONE QUESTION FIVE ************************************//
		case GameState.Round1Question5:
			Debug.Log ("You are in Game State Round1Question 5");
			if (EventSystem.current.currentSelectedGameObject.name == "rule404btn2") {
				Debug.Log ("Question 5 Round 1 correct answer");
				audioSustained.Play ();
				AddScore (25);
			} else {
				Debug.Log ("Question 5 Round 1 wrong answer");
				AddScore (-25);
				audioOverruled.Play ();
				//
				angryscore (1);
			}
			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
			SetGameState (GameState.Round1Question6);
			game_Timer.ResetTimer();
			Debug.Log ("You changed Game State to Round1Question 6");
			break;

//****************** ROUND ONE QUESTION SIX ************************************//
		case GameState.Round1Question6:
			Debug.Log ("You are in Game State Round1Question6");
			if (EventSystem.current.currentSelectedGameObject.name == "rule404btn2") {
				Debug.Log ("Question 6 Round 1 correct answer");
				audioSustained.Play ();
				AddScore (50);
			} else {
				Debug.Log ("Question 6 Round 1 wrong answer");
				audioOverruled.Play ();
			}
			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
			SetGameState (GameState.Round1Question7);
			game_Timer.ResetTimer();
			//Debug.Log ("You changed Game State to Round1Question 7");
			break;

////****************** ROUND ONE QUESTION SEVEN ************************************//
//		case GameState.Round1Question7:
//			Debug.Log ("You are in Game State Round1Question7");
//			if (EventSystem.current.currentSelectedGameObject.name == "rule404btn2") {
//				Debug.Log ("Question 7 Round 1 correct answer");
//				audioSustained.Play ();
//				AddScore (50);
//			} else {
//				Debug.Log ("Question 7 Round 1 wrong answer");
//				audioOverruled.Play ();
//			}
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			SetGameState (GameState.Round2Question1);
//			game_Timer.ResetTimer();
//			Debug.Log ("You changed Game State to Round1Question 7");
//			break;
//
////********************** Round Two *********************************//
////*********************************************************************//
//
////****************** ROUND TWO QUESTION ONE ************************************//
//		case GameState.Round2Question1:
//			Debug.Log ("You are in Game State Button Handler Round 2 Question 1");
//			if (EventSystem.current.currentSelectedGameObject.name == "noObjection") {
//				Debug.Log ("Question 1 Round 2 correct answer");
//				//audioSustained.Play ();
//				AddScore (10);
//
//			} else {
//				Debug.Log ("Question 1 Round 2 wrong answer");
//				audioOverruled.Play ();
//			}
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			game_Timer.ResetTimer();
//			SetGameState (GameState.Round2Question2);
//			Debug.Log ("You changed Game State to Round 2 Question 2");
//			break;
//
////****************** ROUND TWO QUESTION TWO ************************************//
//		case GameState.Round2Question2:
//			Debug.Log ("You are in Game State Round 2 Question 2");
//			if (EventSystem.current.currentSelectedGameObject.name == "rule609btn2") {
//				AddScore (100);
//				audioSustained.Play ();
//				Debug.Log ("Question 2 Round 2 correct answer");
//			} else {
//				Debug.Log ("Question 2 Round 2 wrong answer");
//				audioOverruled.Play ();
//			}
//
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			game_Timer.ResetTimer();
//			SetGameState (GameState.Round2Question3);
//
//			Debug.Log ("You changed Game State to Round 2 Question 3");
//			break;
//
////****************** ROUND TWO QUESTION THREE ************************************//
//		case GameState.Round2Question3:
//			Debug.Log ("You are in Game State Round 2 Question 3");
//			if (EventSystem.current.currentSelectedGameObject.name == "rule404btn2") {
//				Debug.Log ("Question 3 Round 2 correct answer");
//				audioSustained.Play ();
//				AddScore (300);
//			} else {
//				Debug.Log ("Question 3 Round 2 wrong answer");
//				audioOverruled.Play ();
//			}
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			game_Timer.ResetTimer();
//			SetGameState (GameState.Round2Question4);
//			Debug.Log ("You changed Game State to Round 2 Question 4");
//			break;
//
////****************** ROUND TWO QUESTION FOUR ************************************//
//		case GameState.Round2Question4:
//			Debug.Log ("You are in Game State Round 2 Question 4");
//			if (EventSystem.current.currentSelectedGameObject.name == "rule608btn1") {
//				AddScore (50);
//				audioSustained.Play ();
//				Debug.Log ("Question 4 Round 2 correct answer");
//			} else {
//				Debug.Log ("Question 4 Round 2 wrong answer");
//				audioOverruled.Play ();
//			}
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			SetGameState (GameState.Round2Question5);
//			game_Timer.ResetTimer();
//			Debug.Log ("You changed Game State to Round 2 Question 5");
//			break;
//
////****************** ROUND TWO QUESTION FIVE ************************************//
//		case GameState.Round2Question5:
//			Debug.Log ("You are in Game State Round 2 Question 5");
//			if (EventSystem.current.currentSelectedGameObject.name == "rule608btn4") {
//				Debug.Log ("Question 5 Round 2 correct answer");
//				audioSustained.Play ();
//				AddScore (50);
//			} else {
//				Debug.Log ("Question 5 Round 2 wrong answer");
//				audioOverruled.Play ();
//			}
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			SetGameState (GameState.Round3Question1);
//			game_Timer.ResetTimer();
//			Debug.Log ("You changed Game State to Round 3 Question 1");
//			break;
//
////********************** Round THREE *********************************//
////*********************************************************************//
//
////****************** ROUND THREE QUESTION ONE ************************************//
//		case GameState.Round3Question1:
//			Debug.Log ("You are in Game State Button Handler Round3Question 1");
//			if (EventSystem.current.currentSelectedGameObject.name == "noObjection") {
//				Debug.Log ("Question 1 Round 3 correct answer");
//				//audioSustained.Play ();
//				AddScore (10);
//
//			} else {
//				Debug.Log ("Question 1 Round 3 wrong answer");
//				audioOverruled.Play ();
//			}
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			SetGameState (GameState.Round3Question2);
//			game_Timer.ResetTimer();
//			Debug.Log ("You changed Game State to Round3Question 2");
//			break;
//
////****************** ROUND THREE QUESTION TWO ************************************//
//		case GameState.Round3Question2:
//			Debug.Log ("You are in Game State Round3Question 2");
//			if (EventSystem.current.currentSelectedGameObject.name == "rule404btn2") {
//				AddScore (500);
//				audioSustained.Play ();
//				Debug.Log ("Question 2 Round 3 correct answer");
//			} else {
//				Debug.Log ("Question 2 Round 3 wrong answer");
//				audioOverruled.Play ();
//			}
//
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			SetGameState (GameState.Round3Question3);
//			game_Timer.ResetTimer();
//			Debug.Log ("You changed Game State to Round 3 Question 3");
//			break;
//
////****************** ROUND THREE QUESTION THREE ************************************//
//		case GameState.Round3Question3:
//			Debug.Log ("You are in Game State Round 3 Question 3");
//			if (EventSystem.current.currentSelectedGameObject.name == "noObjection") {
//				Debug.Log ("Question 3 Round 3 correct answer");
//				//audioSustained.Play ();
//				AddScore (50);
//			} else {
//				Debug.Log ("Question 3 Round 3 wrong answer");
//				audioOverruled.Play ();
//			}
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			SetGameState (GameState.Round3Question4);
//			game_Timer.ResetTimer();
//			Debug.Log ("You changed Game State to Round 3 Question 4");
//			break;
//
////****************** ROUND THREE QUESTION FOUR ************************************//
//		case GameState.Round3Question4:
//			Debug.Log ("You are in Game State Round 3 Question 4");
//			if (EventSystem.current.currentSelectedGameObject.name == "rule608btn3") {
//				AddScore (50);
//				audioSustained.Play ();
//				Debug.Log ("Question 4 Round 3 correct answer");
//			} else {
//				Debug.Log ("Question 4 Round 3 wrong answer");
//				audioOverruled.Play ();
//			}
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			SetGameState (GameState.Round3Question5);
//			game_Timer.ResetTimer();
//			Debug.Log ("You changed Game State to Round 3 Question 5");
//			break;
//
////****************** ROUND THREE QUESTION FIVE ************************************//
//		case GameState.Round3Question5:
//			Debug.Log ("You are in Game State Round 3 Question 5");
//			if (EventSystem.current.currentSelectedGameObject.name == "rule609btn3") {
//				Debug.Log ("Question 5 Round 3 correct answer");
//				audioSustained.Play ();
//				AddScore (25);
//			} else {
//				Debug.Log ("Question 5 Round 3 wrong answer");
//				audioOverruled.Play ();
//			}
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			SetGameState (GameState.Round3Question6);
//			game_Timer.ResetTimer();
//			Debug.Log ("You changed Game State to Round 3 Question 6");
//			break;
//
////****************** ROUND THREE QUESTION SIX ************************************//
//		case GameState.Round3Question6:
//			Debug.Log ("You are in Game State Round 3 Question6");
//			if (EventSystem.current.currentSelectedGameObject.name == "noObjection") {
//				Debug.Log ("Question 6 Round 3 correct answer");
//				//audioSustained.Play ();
//				AddScore (10);
//			} else {
//				Debug.Log ("Question 6 Round 3 wrong answer");
//				audioOverruled.Play ();
//			}
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			SetGameState (GameState.Round3Question7);
//			game_Timer.ResetTimer();
//			Debug.Log ("You changed Game State to Round 3 Question 7");
//			break;
//
////****************** ROUND THREE QUESTION SEVEN ************************************//
//		case GameState.Round3Question7:
//			Debug.Log ("You are in Game State Round 3 Question7");
//			if (EventSystem.current.currentSelectedGameObject.name == "rule404btn2") {
//				Debug.Log ("Question 7 Round 3 correct answer");
//				audioSustained.Play ();
//				AddScore (250);
//			} else {
//				Debug.Log ("Question 7 Round 3 wrong answer");
//				audioOverruled.Play ();
//			}
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			SetGameState (GameState.Round3Question8);
//			game_Timer.ResetTimer();
//			Debug.Log ("You changed Game State to Round 3 Question 8");
//			break;
////****************** ROUND THREE QUESTION EIGHT ************************************//
//		case GameState.Round3Question8:
//			Debug.Log ("You are in Game State Round 3 Question8");
//			if (EventSystem.current.currentSelectedGameObject.name == "rule404btn2") {
//				Debug.Log ("Question 8 Round 3 correct answer");
//				audioSustained.Play ();
//				AddScore (500);
//			} else {
//				Debug.Log ("Question 8 Round 3 wrong answer");
//				audioOverruled.Play ();
//			}
//			Debug.Log (EventSystem.current.currentSelectedGameObject.name);
//			//SetGameState (END GAME);
//			game_Timer.ResetTimer();
//			Debug.Log ("END OF GAME");
//			break;
//***********************************************************************//
//************************** DEFAULT ************************************//
		default:
			Debug.Log("ERROR: Unknown game state: " + gameState);
			break;

			}

			

	}

//***********************************************************************//
//********************** Timer Handler *********************************//
//*********************************************************************//
	public void timerhandler(){
		Debug.Log ("this is the timer handler");


		switch (gameState) 
		{
//********************** Round One *********************************//
//*********************************************************************//
		case GameState.Round1Question1:
			Debug.Log ("You are in Game State Timer Handler Round1Question1");
			//if (game_Timer.timer > 20) {

				Debug.Log ("time is up Round 1 Question 1");
				SetGameState (GameState.Round1Question2);
				
			//}
			break;
		case GameState.Round1Question2:
			Debug.Log ("You are in Game State Timer HandlerRound1Question2");
			//if (game_Timer.timer > 20) {
				//game_Timer.ResetTimer();
				Debug.Log ("time is up Round 1 Question 2");
				SetGameState (GameState.Round1Question3);
				
			//}
			break;
		case GameState.Round1Question3:
			Debug.Log ("You are in Game State Round1Question3");
			//if (game_Timer.timer > 20) {
				//game_Timer.ResetTimer();
				Debug.Log ("time is up Round 1 Question 3");
				SetGameState (GameState.Round1Question4);
				
			//}
			break;
		case GameState.Round1Question4:
			Debug.Log ("You are in Game State Timer Handler Round1Question4");
			//if (game_Timer.timer > 20) {
				Debug.Log ("time is up Round 1 Question 4");
				SetGameState (GameState.Round1Question5);
				//game_Timer.ResetTimer();
			//}
			break;
		case GameState.Round1Question5:
			Debug.Log ("You are in Game State Timer HandlerRound1Question5");
			//if (game_Timer.timer > 20) {
				Debug.Log ("time is up Round 1 Question 5");
				SetGameState (GameState.Round1Question6);
				//reset_time ();
			//}
			break;
		case GameState.Round1Question6:
			Debug.Log ("You are in Game State Round1Question6");
			//if (game_Timer.timer > 20) {
				Debug.Log ("time is up Round 1 Question 6");
				//SetGameState (GameState.Round1Question7);
				//reset_time ();
		//	}
			break;
//		case GameState.Round1Question7:
//			Debug.Log ("You are in Game State Round1Question7");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 1 Question 7");
//				SetGameState (GameState.Round2Question1);
//				//reset_time ();
//			//}
//			break;
////********************** Round Two *********************************//
////*********************************************************************//
//		case GameState.Round2Question1:
//			Debug.Log ("You are in Game State Timer Handler Round1Question1");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 2 Question 1");
//				SetGameState (GameState.Round2Question2);
//				//reset_time ();
//			//}
//			break;
//		case GameState.Round2Question2:
//			Debug.Log ("You are in Game State Timer HandlerRound1Question2");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 2 Question 2");
//				SetGameState (GameState.Round2Question3);
//				//reset_time ();
//			//}
//			break;
//		case GameState.Round2Question3:
//			Debug.Log ("You are in Game State Round1Question3");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 2 Question 3");
//				SetGameState (GameState.Round1Question4);
//				//reset_time ();
//			//}
//			break;
//		case GameState.Round2Question4:
//			Debug.Log ("You are in Game State Timer Handler Round2Question4");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 2 Question 4");
//				SetGameState (GameState.Round2Question5);
//				//reset_time ();
//			//}
//			break;
//		case GameState.Round2Question5:
//			Debug.Log ("You are in Game State Timer HandlerRound1Question5");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 2 Question 5");
//				SetGameState (GameState.Round3Question1);
//				//reset_time ();
//			//}
//			break;
////********************** Round Three *********************************//
////*********************************************************************//
//		case GameState.Round3Question1:
//			Debug.Log ("You are in Game State Timer Handler Round1Question1");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 3 Question 1");
//				SetGameState (GameState.Round3Question2);
//				
//			//}
//			break;
//		case GameState.Round3Question2:
//			Debug.Log ("You are in Game State Timer HandlerRound1Question2");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 3 Question 2");
//				SetGameState (GameState.Round3Question3);
//				//reset_time ();
//			//}
//			break;
//		case GameState.Round3Question3:
//			Debug.Log ("You are in Game State Round 3 Question3");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 3 Question 3");
//				SetGameState (GameState.Round3Question4);
//				
//			//}
//			break;
//		case GameState.Round3Question4:
//			Debug.Log ("You are in Game State Timer Handler Round 3 Question4");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 3 Question 4");
//				SetGameState (GameState.Round3Question5);
//				//reset_time ();
//			//}
//			break;
//		case GameState.Round3Question5:
//			Debug.Log ("You are in Game State Timer Handler Round 3 Question5");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 3 Question 5");
//				SetGameState (GameState.Round3Question6);
//				//reset_time ();
//			//}
//			break;
//		case GameState.Round3Question6:
//			Debug.Log ("You are in Game State Round 3 Question6");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 3 Question 6");
//				SetGameState (GameState.Round3Question7);
//				
//			//}
//			break;
//		case GameState.Round3Question7:
//			Debug.Log ("You are in Game State Round 3 Question7");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 3 Question 7");
//				SetGameState (GameState.Round3Question8);
//				//reset_time ();
//			//}
//			break;
//		case GameState.Round3Question8:
//			Debug.Log ("You are in Game State Round 3 Question8");
//			//if (game_Timer.timer > 20) {
//				Debug.Log ("time is up Round 3 Question 8");
//				//SetGameState GameOver State;
//				//reset_time ();
//			//}
//			break;
		default:
			Debug.Log("ERROR: Unknown game state: " + gameState);
			break;
		}
//*********************************************************************//
	}
}
