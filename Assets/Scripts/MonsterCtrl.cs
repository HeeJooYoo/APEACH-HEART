using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //씬을 바꾸기 위한것

public class MonsterCtrl : MonoBehaviour {

	private Transform tr;
	GameObject player; //오브젝트 플레이어 변수
	GameObject director;
	public GameObject Boss;
	public Sprite image;
	public int hitCount = 0;//화살에 맞은 횟수
	public float sp = -0.1f;

	void Start () {
		tr = GetComponent<Transform> ();
		player = GameObject.Find ("Player");
		director = GameObject.Find("GameDir");
	}
		
	void Update () {
		tr.Translate(sp, 0, Time.deltaTime);  //x축으로 왼쪽으로 0.1f 만큼의 속도로 몬스터가 나타난다.

		//화면 밖으로 나오면 오브젝트를 파괴한다.
		if (tr.position.x < -8.67) { // heart의 x좌표가 8.67이상이 되면
			Destroy (gameObject);//heart게임 오브젝트를 삭제한다.
			if(SceneManager.GetActiveScene ().buildIndex != 7)  //현재 씬이 보스 스테이지가 아니라면 몬스터가 벽에 닿으면 hp깎임
				director.GetComponent<GameDir> ().DecreaseHp ();//즉 보스 스테이지에서 나오는 몬스터인 f가 벽에 닿아도 플레이어의 hp가 깎이지 않는다.
		}

		Vector2 p1 = tr.position;//몬스터의 중심 좌표
		Vector2 p2 = player.transform.position;//플레이어의 중심 좌표
		float d = Vector2.Distance (p1, p2);//두개의 오브젝트 사이의 거리값을 계산해줌
		float r1 = 0.5f;		//화살의 반경
		float r2 = 1.0f;		//플레이어의 반경

		if (d < r1 + r2) {//충돌한 경우에
				Destroy (gameObject);//게임오브젝트를 삭제한다.

				player.GetComponent<PlayerCtrl> ().ImageChange(); //Stage1,2,3 경우 맞으면 이미지가 바뀌는 PlayerCtrl함수 호출
				director.GetComponent<GameDir> ().DecreaseHp (); //충돌한 경우 게이지를 줄여야한다 - GameDir 함수호출

		}
	}

	void OnCollisionEnter2D(Collision2D coll)  //2d에서 충돌한 오브젝트를 삭제하는 함수
	{
		if (coll.collider.tag == "HEART") {  //태그가 HEART로 되어있는 오브젝트를  
			Destroy (coll.gameObject);  //삭제한다.

			if (++hitCount >= 3) { //맞은 수가 3번이상이면
				ExpMonster ();  //ExpMonster()실행
			}
		}
	}

	void ExpMonster() {
		gameObject.GetComponent<SpriteRenderer> ().sprite = image; //이미지 변경
		Destroy (gameObject,0.1f);//이미지가 변경되고 0.1f후에 변경된 이미지 삭제

		GameObject director = GameObject.Find("Player");
		director.GetComponent<PlayerCtrl> ().SceneChange();
	}
}