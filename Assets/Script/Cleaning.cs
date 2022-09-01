using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaning : MonoBehaviour
{
    public GameObject cloth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TurnOn(){
        cloth = GameObject.FindWithTag("socks");
        if(cloth.GetComponent<Laundry>().isLaundry){
            SendMessage("Shake");
            Invoke("Wait",3f);    
        }
    }

    void Wait()
    {
        cloth.GetComponent<Laundry>().isLaundry = false;
        cloth.GetComponent<MeshRenderer>().enabled = true;
        cloth.transform.parent.position = transform.position;
        cloth.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cloth.transform.localPosition = Vector3.zero;
        cloth.transform.localRotation = Quaternion.Euler(Vector3.zero);
        cloth.GetComponent<Rigidbody>().AddRelativeForce(transform.up * 30f,ForceMode.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
