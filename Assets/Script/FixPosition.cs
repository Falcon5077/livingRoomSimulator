using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPosition : MonoBehaviour
{
    public Vector3 mPosition;
    public Vector3 mRotationEuler;
    public GameObject Player;
    public Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    public void SetPlayerPosition()
    {
        lastPosition = Player.transform.localPosition;
        
        if (Player.transform.parent == null)
            Player.transform.parent = this.transform;

        Player.transform.localPosition = mPosition;
        Player.transform.localRotation = Quaternion.Euler(mRotationEuler);

        if(CameraScope.hitObject == GameObject.FindWithTag("Bed")){
            GameManager.isLay = true;          


            Camera.main.transform.localPosition = new Vector3(0, -5, 0);
            Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(-15, 0, 0));
            GameManager.instance.FadeOut();
        }

        if (Player.transform.parent == this.transform)
            Player.transform.parent = null;
            
    }

    void Update()
    {
        
    }
}