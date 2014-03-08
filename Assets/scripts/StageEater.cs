using UnityEngine;
using System.Collections;

public class StageEater : MonoBehaviour {

	private const float DISTANCE = 55.0f;

	private GameObject stageMaker;

	// Use this for initialization
	void Start () {
		stageMaker = GameObject.Find("StageMaker");
	}

	void Update(){
		this.transform.position = stageMaker.transform.position + Vector3.left * DISTANCE;
	}

	void OnTriggerEnter2D(Collider2D col){
//		if(col.tag == "ground" || col.tag == "tools" || col.tag == "obstacle" || col.tag == "hair"){
			Destroy(col.gameObject);
//		}
	}
}
