using UnityEngine;

public class Platform : MonoBehaviour //발판으로서 필요한 동작을 담은 스크립트
{

    public GameObject[] obstacles; //장애물 오브젝트들
    private bool stepped = false; //플레이어 캐릭터가 밟았는가

    private void OnEnable() //컴포넌트가 활성활될 때마다 매번 실행되는 메서드
                            //발판 리셋하는 처리
    {
        stepped = false; //밟힘 상태를 리셋

        for (int i = 0; i < obstacles.Length; i++) //장애물의 수만큼 루프
        {
            if (Random.Range(0,3) == 0) //현재 순번의 장애물을 1/3의 확률로 활성화
            {
                obstacles[i].SetActive(true);
            }

            else
            {
                obstacles[i].SetActive(false);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision) //플레이어 캐릭터가 자신을 밟았을 때 점수를 추가하는 처리
    {
        
    }

}
