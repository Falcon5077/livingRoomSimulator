using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPosition : MonoBehaviour
{
    public Vector3 mPosition;
    public Vector3 mRotationEuler;
    public Vector3 camRotationEuler;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    public void SetPlayerPosition()
    {
        Player.transform.position = mPosition;
        Player.transform.rotation = Quaternion.Euler(mRotationEuler);
        //Camera.main.transform.localRotation = Quaternion.LookRotation(Vector3.zero);
        //Player.GetComponent<CameraMove>().StopCam();
        Player.GetComponent<CameraMove>().isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
