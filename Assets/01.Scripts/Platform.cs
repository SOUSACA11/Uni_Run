using UnityEngine;

public class Platform : MonoBehaviour //�������μ� �ʿ��� ������ ���� ��ũ��Ʈ
{

    public GameObject[] obstacles; //��ֹ� ������Ʈ��
    private bool stepped = false; //�÷��̾� ĳ���Ͱ� ��Ҵ°�

    private void OnEnable() //������Ʈ(��ǰ)�� Ȱ��Ȱ�� ������ �Ź� ����Ǵ� �޼���
                            //����Ƽ ���� �̺�Ʈ �޼���, ���縵 ������ߵǿ�
                            //���� �����ϴ� ó��
    {
        stepped = false; //���� ���¸� ����

        for (int i = 0; i < obstacles.Length; i++) //��ֹ��� ����ŭ ����
        {
           
            //Random.Range(����) = �����μ� �����´�
            //    float ���� - �ּڰ� ����, �ִ� ����
            //    int   ���� - �ּڰ� ����, �ִ� ������
            
            if (Random.Range(0,3) == 0) //���� ������ ��ֹ��� 1/3�� Ȯ���� Ȱ��ȭ 
            {
                obstacles[i].SetActive(true);
            }

            else
            {
                obstacles[i].SetActive(false);
            }
        }

        //foreach �迭 ����ȭ�μ� ����ȭ ����
        //for�� ���ǹ�, foreach�� ���ǽ�, ���ǽ��� �ξ� ����

        // foreach(GameObject i in obstacles) //foreach�� �迭�� �ѹ��� �޾ƿ��� ���� ������Ʈ Ÿ������ ����
        // {
        //    i.SetActive(Random.Range(0, 3) == 0 ? true : false);
        // }

    }

    private void OnCollisionEnter2D(Collision2D collision) //�÷��̾� ĳ���Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��
    {
        if (collision.collider.tag == "Player" && !stepped) //�浹�� ������ �±װ� Player�̰� ������ �÷��̾� ĳ���Ͱ� ���� �ʾҴٸ�
        
        {
            stepped = true; //������ �߰��ϰ� ���� ���¸� ������ ����
            GameManager.instance.AddScore(10); //�μ��μ� int �� �Ѱ��ش�
        }
    }

}
