using UnityEngine;
using System.Collections;

public class Obstacles: MonoBehaviour {

	//status
	private enum STATUS{ALIVE, DEAD};
	private STATUS cur_status;
	private const float OFFSET_Y = 1.3f;
	//Game Objects
	public GameObject[] obstacle = new GameObject[5];
	private GameObject obstaclePrefab;
	int seed;


	// Use this for initialization
	void Start () {
		//Debug.Log("origin = " + this.transform.position.y.ToString());
		cur_status = STATUS.ALIVE;
		seed = (int)Mathf.Floor(Random.value * 10.0f % 5.0f);
		obstaclePrefab = Instantiate(obstacle[seed], this.transform.position + new Vector3(0, OFFSET_Y,0), this.transform.rotation) as GameObject;

		//Debug.Log("real = " + (this.transform.position.y + OFFSET_Y).ToString());

		//obstaclePrefab.GetComponent<CircleCollider2D>().radius = 1.0f;
	
		Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public bool CheckisAlive(){
		if(cur_status == STATUS.ALIVE){
			return true;
		}else{
			return false;
		}
	}
}
