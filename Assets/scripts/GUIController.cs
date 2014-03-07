using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	//system
	private float w;
	private float h;
	private float margin_side;
	private float margin_updown;
	
	//Romaniv
	private GameObject romaniv;
	private Romaniv romanivScript;
	
	//button
	public Texture2D tex_btn_jump;
	public Texture2D tex_btn_slap;
	public Texture2D tex_btn_pause;


	private float act_btn_width;
	private float act_btn_height;
	private float pause_btn_size;

	//collected hair
	//private Rect score_field;
	//private Rect advance_field;
	
	//private float size_tex;
	private float size_font_score;
	private uint digit = 1;

	//Texture
	private Texture2D[] tex_num = new Texture2D[10];
	private Texture2D tex_ke;
	private Texture2D tex_hon;
	private Texture2D tex_hitohada;
	private Texture2D tex_cm;

	//Pause Menu
	public GameObject PauseMenuPrefab;
	public GameObject fontManagerPrefab;
	// Use this for initialization
	void Start () {
		romaniv = GameObject.Find("Romaniv");
		romanivScript =  romaniv.GetComponent<Romaniv>();

		w = GameController.w;
		h = GameController.h;
		act_btn_width = w * 0.22f;
		act_btn_height = h * 0.26f;
		pause_btn_size = w * 0.07f;
		margin_side = GameController.margin_side;
		margin_updown = GameController.margin_updown;
		//advance_field = new Rect(w * 0.35f, h * 0.05f, w * 0.2f, h * 0.05f);
		//score_field = new Rect(w * 0.05f, h * 0.05f, w * 0.2f, h * 0.05f);
		size_font_score = w * 0.05f;

		GameObject fontManager = Instantiate(fontManagerPrefab) as GameObject;
		tex_num = fontManager.GetComponent<FontManager>().tex_num;
		tex_ke = fontManager.GetComponent<FontManager>().tex_ke;
		tex_hon = fontManager.GetComponent<FontManager>().tex_hon;
		tex_hitohada = fontManager.GetComponent<FontManager>().tex_hitohada;
		tex_cm = fontManager.GetComponent<FontManager>().tex_cm;
		Destroy(fontManager.gameObject);
	}


	void OnGUI(){

		//control with Keyboard
		if(Input.GetKeyDown("j")){
			romanivScript.jump();
		}
		if(Input.GetKeyDown("s")){
			romanivScript.slap();
		}
		if(Input.GetKeyDown("p") && GameController.cur_scene != GameController.SCENE.PAUSE){
			Pause();
		}

		//Score Display
	
		GUI.Box(new Rect(w * 0.008f, margin_updown, size_font_score, size_font_score), tex_ke, GUIStyle.none);

		digit = getDigits(GameController.score);

		for(uint i = digit ; i != 0 ; i--){
			if(i > 1 ){	
				int index = (int)GameController.score;

				for(uint j = i ; j > 1 ; j--){
					index /= 10;
				}
				index %= 10;
				GUI.Box(new Rect(w * 0.13f - ( w * 0.03f * i), margin_updown, size_font_score, size_font_score), tex_num[index], GUIStyle.none);
				
			}else{
				int index = (int)GameController.advance;
				index %= 10;
				
				GUI.Box(new Rect(w * 0.13f - ( w * 0.03f * i), margin_updown, size_font_score, size_font_score), tex_num[(int)GameController.score % 10], GUIStyle.none);
			}
		}

		GUI.Box(new Rect(w * 0.14f, margin_updown, size_font_score, size_font_score), tex_hon, GUIStyle.none);


		GUI.Box(new Rect(w * 0.2f, margin_updown * 0.5f, size_font_score * 3.0f, size_font_score * 3.0f), tex_hitohada, GUIStyle.none);

		digit = getDigits((int)GameController.advance);

		for(uint i = digit ; i != 0 ; i--){
			if(i > 1 ){	
				int index = (int)GameController.advance;

				for(uint j = i ; j > 1 ; j--){
					index /= 10;
				}
				index %= 10;
				GUI.Box(new Rect(w * 0.43f - ( w * 0.03f * i), margin_updown, size_font_score, size_font_score), tex_num[index], GUIStyle.none);

			}else{
				int index = (int)GameController.advance;
				index %= 10;

				GUI.Box(new Rect(w * 0.43f - ( w * 0.03f * i), margin_updown, size_font_score, size_font_score), tex_num[(int)GameController.advance % 10], GUIStyle.none);
			}
		}

		GUI.Box(new Rect(w * 0.45f, margin_updown * 0.5f, size_font_score * 1.5f, size_font_score * 1.5f), tex_cm, GUIStyle.none);

		// jump button
		bool btn_jump = GUI.Button(new Rect(0, Screen.height - act_btn_height, act_btn_width, act_btn_height), tex_btn_jump, GUIStyle.none);

		//slap button
		bool btn_slap = GUI.Button(new Rect(Screen.width - act_btn_width, Screen.height - act_btn_height, act_btn_width, act_btn_height), tex_btn_slap, GUIStyle.none);

		//pause button
		if(GameController.cur_scene != GameController.SCENE.PAUSE){
			if( GUI.Button(new Rect(w - pause_btn_size - margin_side, margin_updown, pause_btn_size, pause_btn_size), tex_btn_pause, GUIStyle.none)){
				Pause();
			}
		}

		if(btn_jump){
			romanivScript.jump();
		}
		if(btn_slap){
			romanivScript.slap();
		}

	}

	void Pause(){
		GameController.cur_scene = GameController.SCENE.PAUSE;
		Instantiate(PauseMenuPrefab);
	}

	uint getDigits(int num){
		if(num < 10){
			return 1;
		}
		uint numOfDigits = 1;
		while(num >= 10){
			num /= 10;
			numOfDigits++;
		}
		return numOfDigits;

	}

	void OnMouseDown(){
		print("OnMouseDown()");
	}
}

