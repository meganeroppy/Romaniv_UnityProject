using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

	private float speed;
	private float scale;


	// Use this for initialization
	void Start () {
		//speed = (Random.value * -0.07f) -0.01f;
		speed = (Random.value * -0.03f) -0.005f;
		scale = Random.Range(0.6f, 1.0f);
		this.transform.localScale = new Vector3(scale, scale, 1.0f);


	}
	
	// Update is called once per frame
	void Update () {
		if(GameController.cur_scene != GameController.SCENE.PAUSE){
			this.transform.Translate(speed, 0.0f, 0.0f);
		}
	}
}
