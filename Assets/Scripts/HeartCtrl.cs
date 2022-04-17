using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCtrl : MonoBehaviour {
	//public int damge = 20; //하트총알의 파괴력
	public float speed = 1000.0f;  //총알 발사 속도;
	private Transform tr;

	// Use this for initialization
	void Start () { //처음 한번만 호출
		GetComponent<Rigidbody2D> ().AddForce (transform.right * speed);	//총알이 생성됨과 동시에 x축으로 날아간다.
		tr = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		//화면 밖으로 나오면 오브젝트를 파괴한다.
		if (tr.position.x > 8.67) { // heart의 좌표가 8.67이상이 되면
			//heart게임 오브젝트를 발사한다.
			Destroy (gameObject);
		}
	}
}