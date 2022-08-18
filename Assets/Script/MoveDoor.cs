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
    // Start is called before the first frame update
    void Start()
    {

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
        StartCoroutine("ShowToiletCamera");
        open = !open;
        if(open)
        {
            StartCoroutine("WaitForIt");
        }
        StartCoroutine("ShowMainCamera");
    }

     public void ShowToiletCamera()
    {
        mainCamera.enabled = false;
        toiletCamera.enabled = true;
    }

    public void ShowMainCamera()
    {
        mainCamera.enabled = true;
        toiletCamera.enabled = false;
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(5.5f);
        StartCoroutine("Slide");
    }
}
