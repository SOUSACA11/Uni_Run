using UnityEngine;

public class ScrollingObject : MonoBehaviour //���� ������Ʈ�� ��� �������� �����̴� ��ũ��Ʈ
{
    public float speed = 10f; //�̵��ӵ�
    
    void Update() //���� ������Ʈ�� ���� �ӵ��� �������� �����̵��ϴ� ó��

    {
        if (!GameManager.instance.isGameover) //���ӿ����� �ƴ϶��
        {
          transform.Translate(Vector3.left * speed * Time.deltaTime); //�ʴ� speed�� �ӵ��� �������� �����̵�
        }

        
    }
}
