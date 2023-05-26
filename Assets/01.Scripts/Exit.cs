using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ClickExit()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}
