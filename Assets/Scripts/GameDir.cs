using System.Collections;
using UnityEngine;
using UnityEngine.UI;//UI사용하려면 이 네임스페이스를 꼭 써야한다
using UnityEngine.SceneManagement; //씬을 바꾸기 위한 네임스페이스


public class GameDir : MonoBehaviour {

	GameObject hpGage;

	// Use this for initialization
	void Start () {
		hpGage = GameObject.Find ("hpGage");
	}


	public void DecreaseHp() { //사용자 정의 함수
		

		hpGage.GetComponent<Image> ().fillAmount -= 0.201f;

		if (hpGage.GetComponent<Image> ().fillAmount <= 0f) {//hp가 0이하가 되면
			SceneManager.LoadScene ("GameOver");//GameOver씬 불러오기
		}
	}
}