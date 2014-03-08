
using UnityEngine;
using System.Collections;

public class GameController: MonoBehaviour {

	//status
	public enum SCENE{START, RUN, RESULT};
	public static SCENE cur_scene;

	//system
	private const float DEFAULT_TIMESCALE = 1.0f;
	public static float cur_timeScale;

	//property
	public static int score;
	public static float advance;
	public static uint difficulty;
	
	//Size of Display
	public static float w;
	public static float h;
	public static float margin_side;
	public static float margin_updown;

	private GUIController gui;
	private Pauser pauser;

	public GameObject resultDispley;


	//BackGround
	//public GameObject backGround_run;
	
	// Use this for initialization
	void Awake () {

		gui = GetComponent<GUIController>();
		pauser = GetComponent<Pauser>();

		cur_timeScale = DEFAULT_TIMESCALE;
		Time.timeScale = cur_timeScale;

		w = Screen.width;
		h = Screen.height;
		margin_side = w * 0.05f;
		margin_updown = h * 0.05f; 

		cur_scene = SCENE.START;
		score = 0;
		advance = 0.0f;
		difficulty = 1;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log(Time.timeScale);
		switch(cur_scene){
			case SCENE.START:
				cur_scene = SCENE.RUN;
				break;
			case SCENE.RUN:
				break;
			case SCENE.RESULT:
				gui.enabled = false;
				pauser.enabled = false;
				break;
			default:
				break;
		}
	}

	public void switchScene(string nextScene){
		if(nextScene == "result"){
			Instantiate(resultDispley);
			cur_scene = SCENE.RESULT;
		}else if(nextScene == "run"){
			cur_scene = SCENE.RUN;
		}else{
			print ("exception occurred.");
		}
	}

	public static void AddScore(int num){
		if(score % 9 == 0 && score != 0){
			//backGround_run.GetComponent<BackGround_Run>().switchPic();
			//Time.timeScale += 0.05f;
			Time.timeScale += 0.15f;
			cur_timeScale = Time.timeScale;
			score += num; 
		}else{
			score += num;
		}
	}

	public void SetTimeScaleAsDefault(){
		Time.timeScale = DEFAULT_TIMESCALE;
	}

	//public uint GetScore(){
	//	return this.score;
	//}

	void reset(){
		score = 0;
		advance = 0;
	}
}
