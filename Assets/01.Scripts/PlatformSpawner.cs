using UnityEngine;

public class PlatformSpawner : MonoBehaviour //발판을 생성하고 주기적으로 재배치하는 스크립트
{
    public GameObject platformPrefab; //생성할 발판의 원본 프리팹
    public int count = 3; //생성할 발판 수 / const 상수로 정의 가능

    public float timeBetSpawnMin = 1.25f; //다음 배치까지의 시간 간격 최솟값
    public float timeBetSpawnMax = 2.25f; //다음 배치까지의 시간 간격 최댓값
    private float timeBetSpqwn; //다음 배치까지의 시간 간격

    public float yMin = -3.5f; //배치할 위치의 최소 y값
    public float yMax = 1.5f; //배치할 위치의 최대 y값
    private float xPos = 20f; //배치할 위치의 x값

    private GameObject[] platforms; //미리 생성한 발판들
    private int currentIndex = 0; //사용할 현재 순번의 발판 / 순서대로 사용하기 위해서

    //풀링 공간 지정
    private Vector2 poolPosition = new Vector2(0, -25); //초반에 생성한 발판을 화면 밖에 숨겨둘 위치
    private float lastSpawnTime; //마지막 배치 시점


    void Start() //변수를 초기화하고 사용할 발판을 미리 생성
    {
        platforms = new GameObject[count]; //count만큼의 공간을 가지는 새로운 발판 배열 생성

        for (int i =0; i < count; i++) //count만큼 루프하면서 발판 생성
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
            //오브젝트(platformPrefab), 위치(poolPosition), 회전(Quaternion.identity(0,0))
            //platformPrefab을 원본으로 새 발판을 poolPosition 위치에 복제 생성
            //생성된 발판을 platforms 배열에 할당
        }

        lastSpawnTime = 0f; //마지막 배치 시점 지정된게 없으니깐 초기화
        timeBetSpqwn = 0f; //다음번 배치까지의 시간 간격을 0으로 초기화 (생성되자마자 바로 배치)
    }

    
    void Update() //순서를 돌아가며 주기적으로 발판을 배치              
    {
        if (GameManager.instance.isGameover) //게임오버 상태에서는 동작하지 않음
        {
            return;
        }


        if (Time.time >= lastSpawnTime + timeBetSpqwn) 
            //마지막 배치 시점에서 timeBetSpawn 이상 시간이 흘렀다면
            //게임이 시작되자마자 발동
           //Time.time - (현재시점) 0.00166초 시작, 게임이 실행되고 현재까지 얼마만큼의 시간이 지났나
           //Time.time - 프레임이 시작한 순간부터의 시간 (프레임 스타트 ~ )
           //Time.deltaTime - 프레임이 시작하고 끝나는 시간 (프레임 스타트 ~ 프레임 종료) / 1초당 프레임 규격화 위해 

        {
            lastSpawnTime = Time.time; //기록된 마지막 배치 시점을 현재 시점으로 갱신

            timeBetSpqwn = Random.Range(timeBetSpawnMin, timeBetSpawnMax); //다음 배치까지의 시간 간격을 timeBetSpawnMin, timeBetSpawnMax 사이에서 랜덤 설정

            float yPos = Random.Range(yMin, yMax); //배치할 위치의 높이를 yMin과 yMax 사이에서 랜덤 설정

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);
            //사용할 현재 순번의 발판 게임 오브젝트를 비활성화하고 즉시 다시 활성화
            //이때 발판의 Platform 컴포넌트의 OnEnable 메서드가 실행됨

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);
            //현재 순번의 발판을 화면 오른쪽에 재배치
            //transform.position에서 대입( = )은 순간이동 / 콜라이더 충돌시 날라가여
            //transform.position에서 ( += ) 은 이동일 수 있음 / transform.position = transform.position + Vector2(xPos, yPos)

            currentIndex++; //순번 넘기기

            if (currentIndex >= count) //마지막 순번에 도달했다면 순번을 리셋
            {
                currentIndex = 0;
            }
        }
    }
}
