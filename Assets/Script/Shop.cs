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
    void Update()
    {
        
    }
    public void showShop()
    {
        shopUI.SetActive(true);
        PlayerMove.canMove = false;

        Cursor.visible = true; //마우스 커서가 보이지 않게 함        
        Cursor.lockState = CursorLockMode.None; //마우스 커서를 고정시킴
    }
    public void closeShop()
    {
        shopUI.SetActive(false);
        PlayerMove.canMove = true;

        Cursor.visible = false; //마우스 커서가 보이지 않게 함        
        Cursor.lockState = CursorLockMode.Locked; //마우스 커서를 고정시킴
    }
}
