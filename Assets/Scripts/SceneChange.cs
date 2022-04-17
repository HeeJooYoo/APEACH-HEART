using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			//현재 실행되고 있는 씬의 값을 가져와 비교
			if (SceneManager.GetActiveScene ().buildIndex == 0) //씬이 게임스타트이면
				SceneManager.LoadScene (1);//스테이지1 호ㄹ
			else if (SceneManager.GetActiveScene ().buildIndex == 2)//씬이 Start_Stage2이면
				SceneManager.LoadScene (3);//스테이지2호출
			else if (SceneManager.GetActiveScene ().buildIndex == 4)//씬이 Start_Stage3이면
				SceneManager.LoadScene (5);//스테이지3호출
			else if (SceneManager.GetActiveScene ().buildIndex == 6)//씬이 Start_Boss이면
				SceneManager.LoadScene (7);//스테이지파이널호출
			else if (SceneManager.GetActiveScene ().buildIndex == 8)//씬이 GameOver이면
				SceneManager.LoadScene (0);//게임스타트호출
			else if (SceneManager.GetActiveScene ().buildIndex == 9)//씬이 ㅁ ClearScene이면
				SceneManager.LoadScene (0);//게임스타트호출
		}
	}
}
