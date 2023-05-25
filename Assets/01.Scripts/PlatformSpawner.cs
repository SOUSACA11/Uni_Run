using UnityEngine;

public class PlatformSpawner : MonoBehaviour //������ �����ϰ� �ֱ������� ���ġ�ϴ� ��ũ��Ʈ
{
    public GameObject platformPrefab; //������ ������ ���� ������
    public int count = 3; //������ ���� �� / const ����� ���� ����

    public float timeBetSpawnMin = 1.25f; //���� ��ġ������ �ð� ���� �ּڰ�
    public float timeBetSpawnMax = 2.25f; //���� ��ġ������ �ð� ���� �ִ�
    private float timeBetSpqwn; //���� ��ġ������ �ð� ����

    public float yMin = -3.5f; //��ġ�� ��ġ�� �ּ� y��
    public float yMax = 1.5f; //��ġ�� ��ġ�� �ִ� y��
    private float xPos = 20f; //��ġ�� ��ġ�� x��

    private GameObject[] platforms; //�̸� ������ ���ǵ�
    private int currentIndex = 0; //����� ���� ������ ���� / ������� ����ϱ� ���ؼ�

    //Ǯ�� ���� ����
    private Vector2 poolPosition = new Vector2(0, -25); //�ʹݿ� ������ ������ ȭ�� �ۿ� ���ܵ� ��ġ
    private float lastSpawnTime; //������ ��ġ ����


    void Start() //������ �ʱ�ȭ�ϰ� ����� ������ �̸� ����
    {
        platforms = new GameObject[count]; //count��ŭ�� ������ ������ ���ο� ���� �迭 ����

        for (int i =0; i < count; i++) //count��ŭ �����ϸ鼭 ���� ����
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
            //������Ʈ(platformPrefab), ��ġ(poolPosition), ȸ��(Quaternion.identity(0,0))
            //platformPrefab�� �������� �� ������ poolPosition ��ġ�� ���� ����
            //������ ������ platforms �迭�� �Ҵ�
        }

        lastSpawnTime = 0f; //������ ��ġ ���� �����Ȱ� �����ϱ� �ʱ�ȭ
        timeBetSpqwn = 0f; //������ ��ġ������ �ð� ������ 0���� �ʱ�ȭ (�������ڸ��� �ٷ� ��ġ)
    }

    
    void Update() //������ ���ư��� �ֱ������� ������ ��ġ              
    {
        if (GameManager.instance.isGameover) //���ӿ��� ���¿����� �������� ����
        {
            return;
        }


        if (Time.time >= lastSpawnTime + timeBetSpqwn) 
            //������ ��ġ �������� timeBetSpawn �̻� �ð��� �귶�ٸ�
            //������ ���۵��ڸ��� �ߵ�
           //Time.time - (�������) 0.00166�� ����, ������ ����ǰ� ������� �󸶸�ŭ�� �ð��� ������
           //Time.time - �������� ������ ���������� �ð� (������ ��ŸƮ ~ )
           //Time.deltaTime - �������� �����ϰ� ������ �ð� (������ ��ŸƮ ~ ������ ����) / 1�ʴ� ������ �԰�ȭ ���� 

        {
            lastSpawnTime = Time.time; //��ϵ� ������ ��ġ ������ ���� �������� ����

            timeBetSpqwn = Random.Range(timeBetSpawnMin, timeBetSpawnMax); //���� ��ġ������ �ð� ������ timeBetSpawnMin, timeBetSpawnMax ���̿��� ���� ����

            float yPos = Random.Range(yMin, yMax); //��ġ�� ��ġ�� ���̸� yMin�� yMax ���̿��� ���� ����

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);
            //����� ���� ������ ���� ���� ������Ʈ�� ��Ȱ��ȭ�ϰ� ��� �ٽ� Ȱ��ȭ
            //�̶� ������ Platform ������Ʈ�� OnEnable �޼��尡 �����

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);
            //���� ������ ������ ȭ�� �����ʿ� ���ġ
            //transform.position���� ����( = )�� �����̵� / �ݶ��̴� �浹�� ���󰡿�
            //transform.position���� ( += ) �� �̵��� �� ���� / transform.position = transform.position + Vector2(xPos, yPos)

            currentIndex++; //���� �ѱ��

            if (currentIndex >= count) //������ ������ �����ߴٸ� ������ ����
            {
                currentIndex = 0;
            }
        }
    }
}
