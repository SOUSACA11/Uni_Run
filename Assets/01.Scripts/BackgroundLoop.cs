using UnityEngine;

public class BackgroundLoop : MonoBehaviour //왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트
                                           //해당 오브젝트가 특정 위치에 도달했을때 되돌리기

{
    private float width; //배경의 가로 길이

    private void Awake() //가로 길이 측정
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>(); //BoxCollider2D 컴포넌트의 size 필드의 x값을 가로길이로 사용
        //BoxCollider2D(타입), backgroundCollider(변수)

        if (backgroundCollider != null)
        {
            width = backgroundCollider.size.x;
        }
        
    }

    private void Update() //현재 위치가 원점에서 왼쪽으로 width 이상 이동했을 때 위치를 재배치
    {
        if (transform.position.x <= -width) //현재 위치가 원점에서 왼쪽으로 width(가로길이) 이상 이동했을 때 위치를 재배치
        {
            Reposition();
        }
    }

    private void Reposition() //위치 재배치 메서드
    {
        Vector2 offset = new Vector2(width * 2f, 0); //현재 위치에서 오른쪽으로 가로 길이*2 만큼 이동
        //벡터는 구조체라서 new 필요

        transform.position = (Vector2)transform.position + offset;
    }
}
