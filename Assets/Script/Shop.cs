using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    // Start is called before the first frame update
    void Start() 
    { 
        shopUI.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoneyCalc.instance.totalMoney += 5;
    }
    public void showShop()
    {
        shopUI.SetActive(true);
        PlayerMove.canMove = false;

        Cursor.visible = true; //���콺 Ŀ���� ������ �ʰ� ��        
        Cursor.lockState = CursorLockMode.None; //���콺 Ŀ���� ������Ŵ
    }
    public void closeShop()
    {
        shopUI.SetActive(false);
        PlayerMove.canMove = true;

        Cursor.visible = false; //���콺 Ŀ���� ������ �ʰ� ��        
        Cursor.lockState = CursorLockMode.Locked; //���콺 Ŀ���� ������Ŵ
    }
}
