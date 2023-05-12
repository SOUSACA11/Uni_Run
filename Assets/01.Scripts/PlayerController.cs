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

        //�˰��� ���� (� ����� �˷��ִ� ����)

        if (Input.GetMouseButtonDown(0) && jumpCount <2) //���콺 ���� ��ư�� ������ �ִ����� Ƚ���� 2 �̸��϶�
        {
            jumpCount++; //���� Ƚ�� ����
            playerRigidbody.velocity = Vector2.zero; //���� ������ �ӵ��� ���������� ����(0,0)���� ���� // .zero - ������ �ӱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce)); //������ٵ� �������� �� �ֱ�
            playerAudio.Play(); //����� �ҽ� ���
        }

        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y >0)  //���콺 ���� ��ư�� ������ ����, �ӵ� y ���� ������(���� ���)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f; //���� �ӵ��� �������� ����
        }

        //�˰��� ��

        animator.SetBool("Grounded", isGrounded); //�ִϸ������� Grounded �Ķ���͸� isGrounded ������ ����
    }

    private void Die() //���
    {
        animator.SetTrigger("Die"); //�ִϸ������� Die Ʈ���� �Ķ���͸� ��
        playerAudio.clip = deathclip; //����� �ҽ��� �Ҵٿ� ����� Ŭ���� deathClip���� ����
        playerAudio.Play(); //��� ȿ���� ���

        playerRigidbody.velocity = Vector2.zero; //�ӵ��� ����(0,0)���� ����
        isDead = true; //��� ���¸� true�� ����
    }

    private void OnTriggerEnter2D(Collider2D other) //Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹 ����
    {
       if (other.tag == "Dead" && !isDead) //�浹�� ������ �±װ� Dead �̰� ������� ���� ����
        {
            Die();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) //�ٴڿ� ������� ����
    {
        if (collision.contacts[0].normal.y > 0.7f) // � �ݶ��̴��� �������, �浹 ǥ���� ������ ���� ������
        {
            isGrounded = true; //isGrounded ������ ����
            jumpCount = 0; //���� ���� Ƚ�� 0���� ����
        }
    }

    private void OnCollisionExit2D(Collision2D collision) //�ٴڿ� ������� ���� 
                                                          //� �ݶ���� ������ ��� 
    {
        isGrounded = false;
    }


}

