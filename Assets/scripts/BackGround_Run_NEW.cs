using UnityEngine;
using System.Collections;

public class BackGround_Run_NEW: MonoBehaviour {
	
	public enum METHOD{BY_SCORE, BY_DATE, BY_MODE};
	public METHOD changeMethod = METHOD.BY_DATE;
	private enum HOUR{DAYTIME, SUNSET, NIGHT};
//	private HOUR cur_hour;

	private float[] PreviousNumber = {0, 0};

	//GameObject;
	public GameObject daytime;
	public GameObject sunset;
	public GameObject night;
	private GameObject cur_BG;

	public GameObject[] cloudPrefab;
	
	// Use this for initialization
	void Start () {
		
		if(changeMethod == METHOD.BY_DATE){
			float cur_hour = System.DateTime.Now.Hour;
			if(cur_hour >= 6 && cur_hour < 15){
				cur_BG = Instantiate(daytime, this.transform.position, this.transform.rotation) as GameObject;
				cur_BG.transform.parent = this.transform;
			}else if(cur_hour >= 15 && cur_hour < 20){
				cur_BG = Instantiate(sunset, this.transform.position, this.transform.rotation) as GameObject;
				cur_BG.transform.parent = this.transform;
			}else{
				cur_BG = Instantiate(night, this.transform.position, this.transform.rotation) as GameObject;
				cur_BG.transform.parent = this.transform;
			}
		}else if(changeMethod == METHOD.BY_SCORE){
//			cur_hour = HOUR.DAYTIME;
		}
	}
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown("z")){
			Destroy(cur_BG.gameObject);
			cur_BG = Instantiate(daytime, this.transform.position, this.transform.rotation) as GameObject;
			cur_BG.transform.parent = this.transform;
		}
		if(Input.GetKeyDown("x")){
			Destroy(cur_BG.gameObject);
			cur_BG = Instantiate(sunset, this.transform.position, this.transform.rotation) as GameObject;
			cur_BG.transform.parent = this.transform;
		}
		if(Input.GetKeyDown("c")){
			Destroy(cur_BG.gameObject);
			cur_BG = Instantiate(night, this.transform.position, this.transform.rotation) as GameObject;
			cur_BG.transform.parent = this.transform;
		}
	//	Debug.Log(Time.frameCount);

		if(Time.frameCount % 30 == 0 && GameController.cur_scene != GameController.SCENE.PAUSE){
			Judge();
		}
	}

	private void Judge(){
		Debug.Log((int)Mathf.Floor(Random.Range(1, 3)));
		if((int)Mathf.Floor(Random.Range(0, 2)) == 0){
			MakeCloud();
		}
	}

	/*
	public void switchPic(){
		if(changeMethod == METHOD.BY_SCORE){
			switch(cur_hour){
			case HOUR.DAYTIME:
				cur_hour = HOUR.SUNSET;
				Destroy(cur_BG.gameObject);
				cur_BG = Instantiate( sunset, this.transform.position, this.transform.rotation) as GameObject;
				cur_BG.transform.parent = this.transform;
				break;
			case  HOUR.SUNSET:
				cur_hour = HOUR.NIGHT;
				Destroy(cur_BG.gameObject);
				cur_BG = Instantiate( night, this.transform.position, this.transform.rotation) as GameObject;
				cur_BG.transform.parent = this.transform;
				break;
			case HOUR.NIGHT:
				Destroy(cur_BG.gameObject);
				cur_hour = HOUR.DAYTIME;
				cur_BG = Instantiate( daytime, this.transform.position, this.transform.rotation) as GameObject;
				cur_BG.transform.parent = this.transform;
				break;
			default:
				break;
			}
		}
	}
	*/
	private void MakeCloud(){
		int cloudType = (int)Mathf.Floor(Random.value * 10.0f % 8.0f);
		if(cloudType == PreviousNumber[0]){
			while(cloudType == PreviousNumber[0]){
				cloudType = (int)Mathf.Floor(Random.value * 10.0f % 8.0f);
			}
		}else{
			PreviousNumber[0] = cloudType;
		}
		float posY = (Random.value * 8.0f) - 3.0f ;
		if(posY == PreviousNumber[1]){
			while(posY == PreviousNumber[1]){
				posY = (Random.value * 8.0f) - 3.0f ;
			}
		}else{
			PreviousNumber[1] = posY;
		}
		Instantiate( cloudPrefab[cloudType], new Vector3(this.transform.position.x + 12.0f, this.transform.position.y + posY, this.transform.position.z - 5.0f), this.transform.rotation);
	}
}
