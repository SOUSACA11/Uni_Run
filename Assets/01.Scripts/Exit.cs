using UnityEngine.SceneManagement;
using UnityEngine;


  //��ư ������Ʈ�� �̹����� �ν��ϴ� ũ�� ����
  //�̹����� ���ؼ� �ν�

public class Exit : MonoBehaviour
{
    public void ClickExit()
    {
        Debug.Log("���� ����");
        Application.Quit();
    }

    //public void ClickRestart()
    //{
    //    Debug.Log("���� �����");
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //    //on click - Time.timeScale = 1;
    //}


    // Time.timeScale�� �ش��� ��Ȳ

    //public void TTime(int time) //������ �ð� �帧 ���� ���
    //{
    //    Debug.Log("�Ͻ�����");
    //    Time.timeScale = time; //�⺻�� 1 - �ð� �帧 / 0 - �ð�����
    //}
}


// �Ͻ����� �� ����ȭ�� Ŭ���� ���� �̾��ϱ�
// �г� ������Ʈ �ȿ� ��ư �߰�
// on click - �ڱ� �ڽ� ������Ʈ �巡�� �� ��� - Gameobject.setactive ��Ȱ��ȭ
// on click - Time.timeScale = 1;


// interactable = ��ȣ�ۿ� - �̹��� Ȱ��ȭ ��Ȱ��ȭ �κ�