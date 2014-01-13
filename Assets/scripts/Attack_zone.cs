using UnityEngine;
using System.Collections;

public class Attack_zone : MonoBehaviour {

	public bool invisible = false;
	public float delay = 2.5f;
	public float duration = 1.0f;

	private float t_time;
	private bool attacking = false;
	private bool hittable = false;

	// Use this for initialization
	void Start () {
		if(invisible){
		transform.renderer.enabled = false;
		}
	}
	// Update is called once per frame
	void Update () {
//		print (Time.realtimeSinceStartup - t_time);
//		print("attacking = " + attacking.ToString());
//		print("hittable = " + hittable.ToString());

		if(attacking && (Time.realtimeSinceStartup - t_time > delay)){
			hittable = true;
			attacking = false;
			t_time = Time.realtimeSinceStartup;
		}else if(hittable &&(Time.realtimeSinceStartup - t_time > duration))
			Destroy(gameObject);
	}

	void execute(){
		t_time = Time.realtimeSinceStartup;
		attacking = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		if(hittable && other.gameObject.tag == "hair"){
			print("attack_zone.OnTriggerEnter()");
//			Destroy(other.gameObject);
//			hittable = false;
		}
	}
}
