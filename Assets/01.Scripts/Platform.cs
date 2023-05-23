using UnityEngine;

public class Platform : MonoBehaviour //발판으로서 필요한 동작을 담은 스크립트
{

    public GameObject[] obstacles; //장애물 오브젝트들
    private bool stepped = false; //플레이어 캐릭터가 밟았는가

    private void OnEnable() //컴포넌트(부품)가 활성활될 때마다 매번 실행되는 메서드
                            //유니티 제공 이벤트 메서드, 스펠링 맞춰줘야되염
                            //발판 리셋하는 처리
    {
        stepped = false; //밟힘 상태를 리셋

        for (int i = 0; i < obstacles.Length; i++) //장애물의 수만큼 루프
        {
           
            //Random.Range(범위) = 범위로서 가져온다
            //    float 형태 - 최솟값 포함, 최댓값 포함
            //    int   형태 - 최솟값 포함, 최댓값 불포함
            
            if (Random.Range(0,3) == 0) //현재 순번의 장애물을 1/3의 확률로 활성화 
            {
                obstacles[i].SetActive(true);
            }

            else
            {
                obstacles[i].SetActive(false);
            }
        }

        //foreach 배열 최적화로서 최적화 월등
        //for는 조건문, foreach는 조건식, 조건식이 훨씬 빨라여

        // foreach(GameObject i in obstacles) //foreach는 배열을 한번에 받아오기 때문 오브젝트 타입으로 접근
        // {
        //    i.SetActive(Random.Range(0, 3) == 0 ? true : false);
        // }

    }

    private void OnCollisionEnter2D(Collision2D collision) //플레이어 캐릭터가 자신을 밟았을 때 점수를 추가하는 처리
    {
        if (collision.collider.tag == "Player" && !stepped) //충돌한 상대방의 태그가 Player이고 이전에 플레이어 캐릭터가 밟지 않았다면
        
        {
            stepped = true; //점수를 추가하고 밟힘 상태를 참으로 변경
            GameManager.instance.AddScore(10); //인수로서 int 값 넘겨준다
        }
    }

}
