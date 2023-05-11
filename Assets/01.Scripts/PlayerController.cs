using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathclip; //사망 시 재생할 오디오 클립
    public float jumpForce = 700f; //점프 힘
    private int jumpCount = 0; //누적 점프 횟수
    private bool isGrounded = false; //바닥에 닿았는지 나타냄
    private bool isDead = false; //사망 상태
    //private AudioClip deathclip = audio

    private Rigidbody2D playerRigidbody; //사용할 리지드바디 컴포넌트
    private Animator animator; // 사용할 애니메이터 컴포넌트
    private AudioSource playerAudio; //사용할 오디오 소스 컴포넌트

    private void Start() //초기화
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    private void Update() //사용장 입력 감지 후 점프 처리
    {
        if (isDead)
        {
            return; //사망시 처리를 더 이상 진행하지 않고 종료
        }

        if (Input.GetMouseButtonDown(0) && jumpCount <2) //마우스 왼쪽 버튼을 누르고, 최대점프 횟수가 2 미만일때
        {
            jumpCount++; //점프 횟수 증가
            playerRigidbody.velocity = Vector2.zero; //점프 직전에 속도를 순간적으로 제로(0,0)으로 변경
            playerRigidbody.AddForce(new Vector2(0, jumpForce)); //리지드바디 위쪽으로 힘 주기
            playerAudio.Play(); //오디오 소스 재생
        }
    }

    private void Die() //사망
    {

    }

    private void OnTriggerEnter2D(Collider2D other) //트리거 콜라이더를 가진 장애물과의 충돌 감지
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision) //바닥에 닿았음을 감지
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision) //바닥에 벗어났음을 감지
    {
        
    }


}

