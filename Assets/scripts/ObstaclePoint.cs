using UnityEngine;
using System.Collections;

public class ObstaclePoint: MonoBehaviour {

	private const float OFFSET_Y = 1.3f;

	//Game Objects
	public GameObject[] obstaclePrefab = new GameObject[5];

	// Use this for initialization
	void Start () {
		int seed = (int)Mathf.Floor(Random.value * 10.0f % 5.0f);
		Instantiate(obstaclePrefab[seed], this.transform.position + new Vector3(0, OFFSET_Y,0), this.transform.rotation);
		Destroy(this.gameObject);
	}
}
