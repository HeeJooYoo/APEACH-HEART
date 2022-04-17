using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGen : MonoBehaviour {

	public GameObject monsterPrefeb;
	public float span = 1.0f;
	float delta = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		delta += Time.deltaTime;
		if (delta > span) {
			delta = 0;
			GameObject go = Instantiate (monsterPrefeb) as GameObject;
			int px = Random.Range (-4, 4);
			go.transform.position = new Vector2 (10, px);  //x축 10부터 적오브젝트가 나오는데 범위는 y축 -4,4이다(px)
		}
	}
}