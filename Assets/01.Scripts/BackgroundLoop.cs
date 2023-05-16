using UnityEngine;

public class BackgroundLoop : MonoBehaviour //���� ������ �̵��� ����� ������ ������ ���ġ�ϴ� ��ũ��Ʈ
                                           //�ش� ������Ʈ�� Ư�� ��ġ�� ���������� �ǵ�����

{
    private float width; //����� ���� ����

    private void Awake() //���� ���� ����
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>(); //BoxCollider2D ������Ʈ�� size �ʵ��� x���� ���α��̷� ���
        //BoxCollider2D(Ÿ��), backgroundCollider(����)

        if (backgroundCollider != null)
        {
            width = backgroundCollider.size.x;
        }
        
    }

    private void Update() //���� ��ġ�� �������� �������� width �̻� �̵����� �� ��ġ�� ���ġ
    {
        if (transform.position.x <= -width) //���� ��ġ�� �������� �������� width(���α���) �̻� �̵����� �� ��ġ�� ���ġ
        {
            Reposition();
        }
    }

    private void Reposition() //��ġ ���ġ �޼���
    {
        Vector2 offset = new Vector2(width * 2f, 0); //���� ��ġ���� ���������� ���� ����*2 ��ŭ �̵�
        //���ʹ� ����ü�� new �ʿ�

        transform.position = (Vector2)transform.position + offset;
    }
}
