using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScope : MonoBehaviour
{
    GameObject hitObject;
    public GameObject UIButton;
    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            PlayObject();
        }
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            PickUp();
        }
        
        RaycastHit hitInfo;

        if(Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo,30f))
        {
            RemoveOutLine();
            hitObject = hitInfo.transform.gameObject;
            if(hitObject.GetComponent<SelectObject>() != null && hitObject.GetComponent<SelectObject>().isSelected == false){
                hitObject.GetComponent<SelectObject>().RayEnter();
                UIButton.SetActive(true);
            }
        }
        else
        {
            RemoveOutLine();
        }
    }

    void PickUp()
    {
        if(hitObject != null){

        }
    }

    void RemoveOutLine()
    {
        if(hitObject != null){
            if(hitObject.GetComponent<SelectObject>() != null && hitObject.GetComponent<SelectObject>().isSelected == true)
            {
                hitObject.GetComponent<SelectObject>().RayExit();
                hitObject = null;
                UIButton.SetActive(false);
            }
        }
    }

    void PlayObject()
    {
        if(hitObject != null)
        {
            Debug.Log(hitObject.name);
            if(hitObject.GetComponent<SelectObject>() != null)
                hitObject.GetComponent<SelectObject>().RunningFunction();
        }
    }
}
