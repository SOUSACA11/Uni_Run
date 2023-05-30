using UnityEngine.SceneManagement;
using UnityEngine;


  //버튼 컴포넌트는 이미지를 인식하는 크기 범위
  //이미지에 의해서 인식

public class Exit : MonoBehaviour
{
    public void ClickExit()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }

    //public void ClickRestart()
    //{
    //    Debug.Log("게임 재시작");
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    //on click - Time.timeScale = 1;
    //}


    // Time.timeScale은 극단적 상황

    //public void TTime(int time) //게임의 시간 흐름 조정 기능
    //{
    //    Debug.Log("일시정지");
    //    Time.timeScale = time; //기본값 1 - 시간 흐름 / 0 - 시간정지
    //}
}


// 일시정지 때 바탕화면 클릭시 게임 이어하기
// 패널 컴포넌트 안에 버튼 추가
// on click - 자기 자신 컴포넌트 드래그 앤 드롭 - Gameobject.setactive 비활성화
// on click - Time.timeScale = 1;


// interactable = 상호작용 - 이미지 활성화 비활성화 부분