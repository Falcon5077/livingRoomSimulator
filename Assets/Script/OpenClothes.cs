using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClothes : MonoBehaviour
{
    public GameObject LeftDoor;
    public GameObject RightDoor;
    public float rotateTime = 1f;
    public enum doorState
    {
        Idle, isOpening, Open, isClosing
    };

    public static doorState status = doorState.Idle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenDoor()
    {
        if(status == doorState.Idle)
            StartCoroutine("OpeningCoroutine");
        else if(status == doorState.Open)
            StartCoroutine("ClosingCoroutine");
    }  

    IEnumerator OpeningCoroutine()
    {
        status = doorState.isOpening;

        float startRotation = LeftDoor.transform.eulerAngles.z;
        float endRotation = startRotation - 150;

        float startRotation2 = RightDoor.transform.eulerAngles.z;
        float endRotation2 = startRotation2 + 150;

        float t = 0.0f;

        while ( t  < rotateTime )
        {
            t += Time.deltaTime;

            float zRotation = Mathf.Lerp(startRotation, endRotation, t / rotateTime) % 360.0f;
            LeftDoor.transform.eulerAngles = new Vector3(LeftDoor.transform.eulerAngles.x, LeftDoor.transform.eulerAngles.y, 
            zRotation);

            float zRotation2 = Mathf.Lerp(startRotation2, endRotation2, t / rotateTime) % 360.0f;
            RightDoor.transform.eulerAngles = new Vector3(RightDoor.transform.eulerAngles.x, RightDoor.transform.eulerAngles.y, 
            zRotation2);
            yield return null;
        }

        status = doorState.Open;
    }
    IEnumerator ClosingCoroutine()
    {
        status = doorState.isClosing;
        
        float startRotation = LeftDoor.transform.eulerAngles.z;
        float endRotation = startRotation + 150;

        float startRotation2 = RightDoor.transform.eulerAngles.z;
        float endRotation2 = startRotation2 - 150;

        float t = 0.0f;

        while ( t  < rotateTime )
        {
            t += Time.deltaTime;

            float zRotation = Mathf.Lerp(startRotation, endRotation, t / rotateTime) % 360.0f;
            LeftDoor.transform.eulerAngles = new Vector3(LeftDoor.transform.eulerAngles.x, LeftDoor.transform.eulerAngles.y, 
            zRotation);

            float zRotation2 = Mathf.Lerp(startRotation2, endRotation2, t / rotateTime) % 360.0f;
            RightDoor.transform.eulerAngles = new Vector3(RightDoor.transform.eulerAngles.x, RightDoor.transform.eulerAngles.y, 
            zRotation2);
            yield return null;
        }

        status = doorState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
