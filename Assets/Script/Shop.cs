using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopUI;
    // Start is called before the first frame update
    void Start() 
    { 
        shopUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showShop()
    {
        shopUI.SetActive(true);
    }
    public void closeShop()
    {
        shopUI.SetActive(false);
    }
}
