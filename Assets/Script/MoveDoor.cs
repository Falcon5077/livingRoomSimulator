using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{
    public Camera mainCamera;
    public Camera toiletCamera;

    public bool open = false;
    public GameObject door;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float smoot = 2f;

    GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
        }   
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smoot * Time.deltaTime);
        }
        
    }
    public void Slide(){
        open = !open;
        if(open)
        {
            StartCoroutine("WaitForIt");
        }
    }

     public void ShowToiletCamera()
    {
        GetComponent<SelectObject>().enabled = false;
        mainCamera.GetComponent<CameraScope>().enabled = false;
        canvas.SetActive(false);
        mainCamera.enabled = false;
        toiletCamera.enabled = true;
    }

    public void ShowMainCamera()
    {
        GetComponent<SelectObject>().enabled = true;
        mainCamera.GetComponent<CameraScope>().enabled = true;
        canvas.SetActive(true);
        mainCamera.enabled = true;
        toiletCamera.enabled = false;
    }

    IEnumerator WaitForIt()
    {
        
        yield return new WaitForSeconds(0.5f);
        ShowToiletCamera();
        yield return new WaitForSeconds(4f);
        ShowMainCamera();
        open = !open;
    }
}
