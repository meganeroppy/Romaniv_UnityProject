using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float duration = 1.0f;

	public GameObject ojisan;
	public GameObject ojichan;
	public GameObject onisan;
		// Use this for initialization
	void Start () {
		Destroy(gameObject, duration);
		if(GameController.score >= 10){
			Instantiate(onisan, gameObject.transform.position, gameObject.transform.rotation);
		}else if(GameController.score >= 5){
			Instantiate(ojisan, gameObject.transform.position, gameObject.transform.rotation);
		}else{
			Instantiate(ojichan, gameObject.transform.position, gameObject.transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {	
	}
}
