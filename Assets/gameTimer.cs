using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class gameTimer : MonoBehaviour {

	public Text timerText;
	private float startTime;
	public float timer = 60.0f;
	public bool stoptimer;




	void Awake() {
		
		stoptimer = false;

	}

	public void Update(){
			
		checkAudioIntro ();

		if (stoptimer == true)
		{
			startTime = Time.time;
			timer -= Time.deltaTime;

			if (timer < 0) 
				{
					GameManager.Instance.timerhandler ();
					ResetTimer ();
				}
		}
		else{
			//pause timer
		}


		string minutes = ((int)timer / 60).ToString ();
		string seconds = (timer % 60).ToString ("f2");

		timerText.text = minutes + ":" + seconds;


	}

	public void checkAudioIntro ()
	{
		GameManager game_Manager = GetComponent<GameManager> ();
		if (!game_Manager.audioJudgeIntro.isPlaying) {
			stoptimer = true;
		}
		else{
			stoptimer = false;
		}
			
	}

	public void checkAudioJudgeRuling ()
	{
		GameManager game_Manager = GetComponent<GameManager> ();
		if (!game_Manager.audioOverruled.isPlaying) {
			stoptimer = true;
		} 
		if (!game_Manager.audioSustained.isPlaying){
			stoptimer = true;
		}
		else {
			stoptimer = false;
		}
	}

	public void ResetTimer()
	{
		timer = 60.0f;
	}


}
