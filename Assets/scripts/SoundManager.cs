using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	//public AudioClip se_menu;
	// Use this for initialization
	void Start () {
//		BGM.Play(44100);
		//audio.Play();
	}
	
	//public void PlayMenuSE(){
	//	if(se_menu){
	//		audio.PlayOneShot(se_menu);
	//	}
	//}

	public void PlaySE(AudioClip clip, float volume){
		if(clip){
			audio.clip = clip;
			audio.volume = volume;
			audio.Play();
		}
	}

	public void PlaySE(AudioClip clip){
		if(clip){
			audio.clip = clip;
			audio.Play();
		}
	}
}
