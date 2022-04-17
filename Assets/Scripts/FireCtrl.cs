using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour {

	public GameObject heart; //하트총알 프리팹
	public Transform firePos;  //하트총알 발사좌표

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Fire ();
		}
	}

	void Fire() {
		CreateBullet ();
	}

	void CreateBullet() {
		Instantiate (heart, firePos.position, firePos.rotation);
	}
}