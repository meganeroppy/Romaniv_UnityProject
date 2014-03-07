using UnityEngine;
using System.Collections;

public class FontManager : MonoBehaviour {

	public enum STYLE{DEFAULT, FILLED};
	public STYLE cur_style = STYLE.DEFAULT;

	//default
	public Texture2D tex_saikou_default;
	public Texture2D tex_score_default;
	public Texture2D[] tex_num_default = new Texture2D[10];
	public Texture2D tex_ke_default;
	public Texture2D tex_hon_default;
	public Texture2D tex_hitohada_default;
	public Texture2D tex_cm_default;

	//filled
	public Texture2D tex_saikou_filled;
	public Texture2D tex_score_filled;
	public Texture2D[] tex_num_filled = new Texture2D[10];
	public Texture2D tex_ke_filled;
	public Texture2D tex_hon_filled;
	public Texture2D tex_hitohada_filled;
	public Texture2D tex_cm_filled;

	//for use
	[HideInInspector]
	public Texture2D tex_saikou;
	[HideInInspector]
	public Texture2D tex_score;
	[HideInInspector]
	public Texture2D[] tex_num = new Texture2D[2];
	[HideInInspector]
	public Texture2D tex_ke;
	[HideInInspector]
	public Texture2D tex_hon;
	[HideInInspector]
	public Texture2D tex_hitohada;
	[HideInInspector]
	public Texture2D tex_cm;

	private void Awake(){
		switch(cur_style){
			case STYLE.DEFAULT:
				tex_saikou = tex_saikou_default;
				tex_score = tex_score_default;
				tex_num = tex_num_default;
				tex_ke = tex_ke_default;
				tex_hon = tex_hon_default;
				tex_hitohada = tex_hitohada_default;
				tex_cm = tex_cm_default;
				break;
			case STYLE.FILLED:
				tex_saikou = tex_saikou_filled;
				tex_score = tex_score_filled;
				tex_num = tex_num_filled;
				tex_ke = tex_ke_filled;
				tex_hon = tex_hon_filled;
				tex_hitohada = tex_hitohada_filled;
				tex_cm = tex_cm_filled;
				break;
			default:
				break;
		}
	}

	public void SetStyle(int key){
		cur_style = (STYLE)key;
	}
}





