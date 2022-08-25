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
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
