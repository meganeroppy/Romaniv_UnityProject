using UnityEngine;
using System.Collections;

public class ObstaclePoint: MonoBehaviour {

	//status
	private enum STATUS{ALIVE, DEAD};
	private STATUS cur_status;
	private const float OFFSET_Y = 1.3f;

	//Game Objects
	public GameObject[] obstaclePrefab = new GameObject[5];
	//int seed;


	// Use this for initialization
	void Start () {
		cur_status = STATUS.ALIVE;
		int seed = (int)Mathf.Floor(Random.value * 10.0f % 5.0f);
		Instantiate(obstaclePrefab[seed], this.transform.position + new Vector3(0, OFFSET_Y,0), this.transform.rotation);
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
