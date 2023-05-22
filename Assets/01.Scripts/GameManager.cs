using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
    //게임오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
    //씬에는 단 하나의 게임 매니저만 존재할 수 있음
    //싱글턴 - 단 한만 존재, 손쉬운 접근

{
    public static GameManager instance; //싱글턴을 할당할 전역 변수 //자기 자신을 담을 공간

    public bool isGameover = false; //게임오버 상태
    public TextMeshProUGUI scoreText; //점수를 출력할 UI 텍스트
    public GameObject gameoverUI; //게임오버 시 활성화할 UI 게임 오브젝트

    //SetActive (메서드, 값 설정) : 게임 오브젝트 활성화비활성화
    //enabled (변수, 대입연산) : 컴포넌트 활성화비활성화

    private int score = 0; //게임 점수

    private void Awake() //게임 시작과 동시에 싱글턴을 구성
    {
        if (instance == null)//싱글턴 변수 instance가 비어 있는가?
        {
            instance = this; //비어 있다면(null) 그곳에 자기 자신을 할당
        }

        else //instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우 (씬에 두 개 이상 존재함을 의미)
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(this.gameObject);
            
            //싱글턴 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴

        }
   
    }
    private void Update() //게임오버 상태에서 게임을 재시작 할 수 있개 하는 처리
    {
        if (isGameover && Input.GetMouseButtonDown(0)) //게임오버 상태에서 마우스 왼쪽 버튼을 클릭하면 현재 씬 재시작
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //현재 활성화 되어 있는 씬의 이름을 불러와
        }
    }

    public void AddScore(int newScore) //점수를 증가시키는 메서드 
    {
        if (!isGameover) //게임오버가 아니라면
        {
            score += newScore; //점수를 증가
            scoreText.text = "Score :" + score;
        }
    }

    public void OnplayerDead() //플레이어 캐릭터 사망 시 게임오버를 실행하는 메서드
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}
