using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laundry : MonoBehaviour
{
    public bool isLaundry = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Washing()
    {  
        if(!isLaundry){
            GetComponent<MeshRenderer>().enabled = false;
            transform.parent.position = new Vector3(-50,1,-5);
            transform.localPosition = new Vector3(0,0,0);
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            isLaundry = true;
        }
        else
            SendMessage("Shake");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
