using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	//system
	private float w;
	private float h;
	private float margin_side;
	private float margin_updown;
	
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

	//Script
	private InputManager input;
	private FontManager fontManager;

	// Use this for initialization
	void Start () {
		input = GetComponent<InputManager>();
		fontManager = GetComponent<FontManager>();

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

		tex_num = fontManager.tex_num;
		tex_ke = fontManager.tex_ke;
		tex_hon = fontManager.tex_hon;
		tex_hitohada = fontManager.tex_hitohada;
		tex_cm = fontManager.tex_cm;
	}

	void OnGUI(){

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

		bool btn_jump = false;
		bool btn_slap = false;

		if(!Pauser.pausing){
			// Jump button
			btn_jump = GUI.Button(new Rect(0, Screen.height - act_btn_height, act_btn_width, act_btn_height), tex_btn_jump, GUIStyle.none);
			//Slap button
			btn_slap = GUI.Button(new Rect(Screen.width - act_btn_width, Screen.height - act_btn_height, act_btn_width, act_btn_height), tex_btn_slap, GUIStyle.none);
			//Pause button
			if( GUI.Button(new Rect(w - pause_btn_size - margin_side, margin_updown, pause_btn_size, pause_btn_size), tex_btn_pause, GUIStyle.none)){
				input.Pause();
			}
		}

		if(btn_jump){
			input.Jump();
		}
		if(btn_slap){
			input.Slap();
		}
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
}

