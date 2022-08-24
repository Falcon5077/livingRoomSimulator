using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalPrice : MonoBehaviour
{
    public int totalPrice = 0;
    public static TotalPrice instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setPrice()
    {
        GetComponent<TextMeshProUGUI>().text = "Price : " + string.Format("{0:0,0}", totalPrice);
    }
}
