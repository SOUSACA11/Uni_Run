using UnityEngine;

public class ScrollingObject : MonoBehaviour //게임 오브젝트를 계속 왼쪽으로 움직이는 스크립트
{
    public float speed = 10f; //이동속도
    
    void Update() //게임 오브젝트를 일정 속도로 왼쪽으로 평행이동하는 처리

    {
        if (!GameManager.instance.isGameover) //게임오버가 아니라면
        {
          transform.Translate(Vector3.left * speed * Time.deltaTime); //초당 speed의 속도로 왼쪽으로 평행이동
        }

        
    }
}
