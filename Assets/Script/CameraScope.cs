using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScope : MonoBehaviour
{
    private Vector3 ScreenCenter;
    public GameObject hitObject;
    private void Start() {
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
    }

    private void FixedUpdate() {
        // Ray ray = Camera.main.ScreenPointToRay(ScreenCenter);
        // Debug.DrawRay(transform.position,transform.forward * 10f, Color.red);
        RaycastHit hitInfo;

        if(Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo,30f))
        {
            RemoveOutLine();
            hitObject = hitInfo.transform.gameObject;
            if(hitObject.GetComponent<SelectObject>() != null && hitObject.GetComponent<SelectObject>().isSelected == false)
                hitObject.GetComponent<SelectObject>().RayEnter();
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
            }
        }
    }
}
