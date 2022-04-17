using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCtrl : MonoBehaviour {
	public float Scroll_speed = 0.5f;
	public Material sky;

	// Use this for initialization
	void Start () {
		sky = GetComponent<Renderer> ().material; 
	}

	// Update is called once per frame
	void Update () {
		float newOffsetX = sky.mainTextureOffset.x + Scroll_speed * Time.deltaTime;
		//사용할 화면의 x축에 스크롤 될 화면의 스피드를 곱해서 변수에 넣어준다.

		Vector2 newOffset = new Vector2 (newOffsetX, 0); //엑스축으로 변경이 되는 배경이므로 변수를 엑스축에 넣어준다
		sky.mainTextureOffset = newOffset;//sky머터리얼에 새롭게 만든 것을 넣어준다.
	}
}