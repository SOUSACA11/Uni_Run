using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathclip; //��� �� ����� ����� Ŭ��
    public float jumpForce = 700f; //���� ��
    private int jumpCount = 0; //���� ���� Ƚ��
    private bool isGrounded = false; //�ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false; //��� ����
    //private AudioClip deathclip = audio

    private Rigidbody2D playerRigidbody; //����� ������ٵ� ������Ʈ
    private Animator animator; // ����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio; //����� ����� �ҽ� ������Ʈ

    private void Start() //�ʱ�ȭ
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    private void Update() //����� �Է� ���� �� ���� ó��
    {
        if (isDead)
        {
            return; //����� ó���� �� �̻� �������� �ʰ� ����
        }

        if (Input.GetMouseButtonDown(0) && jumpCount <2) //���콺 ���� ��ư�� ������, �ִ����� Ƚ���� 2 �̸��϶�
        {
            jumpCount++; //���� Ƚ�� ����
            playerRigidbody.velocity = Vector2.zero; //���� ������ �ӵ��� ���������� ����(0,0)���� ����
            playerRigidbody.AddForce(new Vector2(0, jumpForce)); //������ٵ� �������� �� �ֱ�
            playerAudio.Play(); //����� �ҽ� ���
        }
    }

    private void Die() //���
    {

    }

    private void OnTriggerEnter2D(Collider2D other) //Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹 ����
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision) //�ٴڿ� ������� ����
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision) //�ٴڿ� ������� ����
    {
        
    }


}
