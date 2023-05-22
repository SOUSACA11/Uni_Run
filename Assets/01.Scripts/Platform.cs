using UnityEngine;

public class Platform : MonoBehaviour //�������μ� �ʿ��� ������ ���� ��ũ��Ʈ
{

    public GameObject[] obstacles; //��ֹ� ������Ʈ��
    private bool stepped = false; //�÷��̾� ĳ���Ͱ� ��Ҵ°�

    private void OnEnable() //������Ʈ�� Ȱ��Ȱ�� ������ �Ź� ����Ǵ� �޼���
                            //���� �����ϴ� ó��
    {
        stepped = false; //���� ���¸� ����

        for (int i = 0; i < obstacles.Length; i++) //��ֹ��� ����ŭ ����
        {
            if (Random.Range(0,3) == 0) //���� ������ ��ֹ��� 1/3�� Ȯ���� Ȱ��ȭ
            {
                obstacles[i].SetActive(true);
            }

            else
            {
                obstacles[i].SetActive(false);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision) //�÷��̾� ĳ���Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��
    {
        
    }

}
