using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; //씬을 바꾸기 위한것
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour {

	public float Speed = 1f;
	public int monsterCount = 0;
	public Sprite player_U;
	public Sprite player;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.UpArrow)) { // 위의 방향키를 누를 때 움직임
			transform.Translate (Vector2.up * Speed * Time.deltaTime);
		}
			
		if (Input.GetKey (KeyCode.DownArrow)) { // 아래 방향키
			transform.Translate (Vector2.down * Speed * Time.deltaTime);
		}
			
		if (Input.GetKey (KeyCode.RightArrow)) { // 오른쪽 방향키
			transform.Translate (Vector2.right * Speed * Time.deltaTime);
		}
			
		if (Input.GetKey (KeyCode.LeftArrow)) { // 왼쪽 방향키
			transform.Translate (Vector2.left * Speed * Time.deltaTime);
		}

		transform.position = new Vector2(Mathf.Clamp(transform.position.x,-8.0f,-0.8f), 
			Mathf.Clamp(transform.position.y,-4.0f,4.0f)); //이동제한 함수
		//이동범위제한 함수 x축의 -8과 -0.8만큼만 이동할 수 있고, y축의 -4와 4만큼만 움직일 수 있다. 
	} 

	public void SceneChange() {
		if (SceneManager.GetActiveScene ().buildIndex == 1) { //스테이지 1
			if (++monsterCount >= 20) {//몬스터를 10번죽이면 씬이 바뀐다.
				SceneManager.LoadScene (2);//스테이지지2로가기
			}
		}
		if (SceneManager.GetActiveScene ().buildIndex == 3) {//스테이지2
			if (++monsterCount >= 30) {//몬스터를 10번죽이면 씬이 바뀐다.
				SceneManager.LoadScene (4);//스테이지3으로 가기기
		
			}
		}
		if (SceneManager.GetActiveScene ().buildIndex == 5) {//스테이즈3
			if (++monsterCount >= 30) {//몬스터를 10번죽이면 씬이 바뀐다.
				SceneManager.LoadScene (6);//파이널스테이지로가기

			}
		}

		if (SceneManager.GetActiveScene ().buildIndex == 7) {//파이널스테이지
				SceneManager.LoadScene ("ClearScene");//스테이지를 완료하면 clearscene
		}
	}


	public void ImageChange() {
		gameObject.GetComponent<SpriteRenderer> ().sprite = player_U;//이미지변경
		Invoke("Change",0.3f); //함수호출지연 함수 - Change함수를 0.3f 뒤에 호출
	}

	void Change() {
		gameObject.GetComponent<SpriteRenderer> ().sprite = player;//이미지변경
	}
}
	