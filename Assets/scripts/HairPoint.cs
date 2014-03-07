using UnityEngine;
using System.Collections;

public class HairPoint: MonoBehaviour {

	//private enum SIZE{S, M, L, LL};
	private float t_time;
	
	public GameObject[] hair = new GameObject[4];
	
	private float hair_height;
	// Use this for initialization
	void Start () {
		int size = (int)Mathf.Floor(Random.value * 10.0f % 4.0f);
		//hair_height = (hair[size].GetComponent<BoxCollider2D>().center.y * -2.0f) * 0.9f ;
		hair_height = (hair[size].GetComponent<BoxCollider2D>().size.y * hair[size].transform.lossyScale.y) * 0.45f;
		Instantiate(hair[size], transform.position + new Vector3(0, hair_height, 0), transform.rotation);
		Destroy(this.gameObject);
	}
	
}