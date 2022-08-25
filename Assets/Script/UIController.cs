using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController UI;
    public GameObject OutDoorPannel;
    // Start is called before the first frame update
    void Start()
    {
        UI = this;
    }

    public void UIOn()
    {
        PlayerMove.canMove = false;
        OutDoorPannel.SetActive(true);
        
        Cursor.visible = true; //마우스 커서가 보이지 않게 함        
        Cursor.lockState = CursorLockMode.None; //마우스 커서를 고정시킴
    }
    public void UIOff()
    {
        PlayerMove.canMove = true;
        OutDoorPannel.SetActive(false);

        Cursor.visible = false; //마우스 커서가 보이지 않게 함        
        Cursor.lockState = CursorLockMode.Locked; //마우스 커서를 고정시킴

        MainDoor.open = false;
    }
}
