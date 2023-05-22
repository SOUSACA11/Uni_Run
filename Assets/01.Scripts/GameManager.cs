using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
    //���ӿ��� ���¸� ǥ���ϰ�, ���� ������ UI�� �����ϴ� ���� �Ŵ���
    //������ �� �ϳ��� ���� �Ŵ����� ������ �� ����
    //�̱��� - �� �Ѹ� ����, �ս��� ����

{
    public static GameManager instance; //�̱����� �Ҵ��� ���� ���� //�ڱ� �ڽ��� ���� ����

    public bool isGameover = false; //���ӿ��� ����
    public TextMeshProUGUI scoreText; //������ ����� UI �ؽ�Ʈ
    public GameObject gameoverUI; //���ӿ��� �� Ȱ��ȭ�� UI ���� ������Ʈ

    //SetActive (�޼���, �� ����) : ���� ������Ʈ Ȱ��ȭ��Ȱ��ȭ
    //enabled (����, ���Կ���) : ������Ʈ Ȱ��ȭ��Ȱ��ȭ

    private int score = 0; //���� ����

    private void Awake() //���� ���۰� ���ÿ� �̱����� ����
    {
        if (instance == null)//�̱��� ���� instance�� ��� �ִ°�?
        {
            instance = this; //��� �ִٸ�(null) �װ��� �ڱ� �ڽ��� �Ҵ�
        }

        else //instance�� �̹� �ٸ� GameManager ������Ʈ�� �Ҵ�Ǿ� �ִ� ��� (���� �� �� �̻� �������� �ǹ�)
        {
            Debug.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�!");
            Destroy(this.gameObject);
            
            //�̱��� ������Ʈ�� �ϳ��� �����ؾ� �ϹǷ� �ڽ��� ���� ������Ʈ�� �ı�

        }
   
    }
    private void Update() //���ӿ��� ���¿��� ������ ����� �� �� �ְ� �ϴ� ó��
    {
        if (isGameover && Input.GetMouseButtonDown(0)) //���ӿ��� ���¿��� ���콺 ���� ��ư�� Ŭ���ϸ� ���� �� �����
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //���� Ȱ��ȭ �Ǿ� �ִ� ���� �̸��� �ҷ���
        }
    }

    public void AddScore(int newScore) //������ ������Ű�� �޼��� 
    {
        if (!isGameover) //���ӿ����� �ƴ϶��
        {
            score += newScore; //������ ����
            scoreText.text = "Score :" + score;
        }
    }

    public void OnplayerDead() //�÷��̾� ĳ���� ��� �� ���ӿ����� �����ϴ� �޼���
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}
