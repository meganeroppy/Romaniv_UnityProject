using UnityEngine;
using System.Collections;

public class Romaniv : MonoBehaviour {

	//system
	private float t_time;

	//status
	public float speed = 10.0f;
	public float jumpSpeed = 10.0f;
//	public float re_attack_delay = 0.5f;
//	private bool attackable = true;
	private enum STATUS{RUN, STOP, JUMP, SLAP, DEAD};
	private STATUS cur_status;
	private float cur_jumpSpeed;
	private bool gameOver = false;
	
	//gameover
	public GameObject resultDispley;

	private Animator anim;

	//game objects
	public GameObject attack_zone;
	public GameObject explosion;

	// Use this for initialization
	void Start () {

		cur_status = STATUS.RUN;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		switch(cur_status){
			case STATUS.RUN:
		//		if(!attackable && t_time - Time.realtimeSinceStartup * Time.deltaTime >= re_attack_delay ){
		//			attackable = true;
		//		}
				transform.Translate(Vector2.right * speed * Time.deltaTime);	//walking right direction
				GameController.advance += Time.deltaTime;
				break;
			case STATUS.STOP:
				break;
			case STATUS.JUMP:
				transform.Translate(Vector2.right * speed * Time.deltaTime);	//walking right direction
				GameController.advance += Time.deltaTime;

				transform.Translate(Vector2.up * cur_jumpSpeed * Time.deltaTime);
				cur_jumpSpeed += Physics.gravity.y * Time.deltaTime;
				if(cur_jumpSpeed <= 0.0f){
					cur_status = STATUS.RUN;
	//				anim.SetTrigger("jump_end_t");
				}
				break;
			case STATUS.SLAP:
				transform.Translate(Vector2.right * speed * Time.deltaTime);	//walking right direction
				GameController.advance += Time.deltaTime;

				anim.SetTrigger("slap_t");
				GameObject atk = 
				 Instantiate(attack_zone, (new Vector3(this.transform.position.x + (float)1.5, this.transform.position.y - (float)0.5, 0)), Quaternion.identity) as GameObject;;
				atk.transform.parent = this.gameObject.transform;
				atk.SendMessage("execute", SendMessageOptions.DontRequireReceiver);
				cur_status = STATUS.RUN;
				break;
			case STATUS.DEAD:
				if(Time.realtimeSinceStartup - t_time >= 3.0f && !gameOver){
					Instantiate(resultDispley);
				GameController.switchScene("result");
					gameOver = true;
				}
				break;
			default:
				break;
		}//end of switch

	}
	public void jump(){
		if(cur_status == STATUS.RUN){
			cur_jumpSpeed = jumpSpeed;
			anim.SetTrigger("jump_t");
			cur_status = STATUS.JUMP;
		}
	}
	
	public void slap(){
		if(cur_status == STATUS.RUN){
			anim.SetTrigger("slap_t");
			cur_status = STATUS.SLAP;
		}
	}


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "hair"){
			if(coll.gameObject.GetComponent<Hair>().judge()){
				explode ();
			}
		}
	}

	void explode(){
		cur_status = STATUS.DEAD;
		gameObject.renderer.enabled = false;
		Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
		t_time = Time.realtimeSinceStartup;
	}


}
