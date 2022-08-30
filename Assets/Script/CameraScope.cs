using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScope : MonoBehaviour
{
    public static GameObject hitObject;
    public GameObject UIButton;
    private void Update()
    {
        //Debug.Log(hitObject);

        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayObject();
        }

        DrawOutLine();

    }
    private void DrawOutLine()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, 30f))
        {
            RemoveOutLine();
            hitObject = hitInfo.transform.gameObject;

            if (hitObject != null && GameManager.something_Grab == true)
            {
                return;
            }

            if (hitObject.GetComponent<SelectObject>() != null && hitObject.GetComponent<SelectObject>().isSelected == false)
            {
                if (hitObject.GetComponent<MoveObject>() != null && hitObject.GetComponent<MoveObject>().isGrab != true)
                    hitObject.GetComponent<SelectObject>().RayEnter();
                else if (hitObject.GetComponent<MoveObject>() == null)
                    hitObject.GetComponent<SelectObject>().RayEnter();

                UIButton.SetActive(true);
            }
        }
        else
        {
            RemoveOutLine();
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
        if(hitObject!= null)
        {
            if (GameManager.something_Grab == true)
                return;

            if (hitObject.GetComponent<AudioSource>() != null)
            {
                hitObject.GetComponent<AudioSource>().Play();
            }

            if (hitObject.GetComponent<SelectObject>() != null)
            {
                hitObject.GetComponent<SelectObject>().RunningFunction();
            }
        }
    }
}
