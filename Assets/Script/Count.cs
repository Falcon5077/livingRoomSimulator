using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    public int count = 0;
    public int price = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void countPlus()
    {
        if(count >= 99)
        {
            return;
        }

        TotalPrice.instance.totalPrice += price;
        GetComponent<TextMeshProUGUI>().text = (++count).ToString();
        TotalPrice.instance.setPrice();
    }
    public void countMinus()
    {
        if (count <= 0)
        {
            return;
        }
        TotalPrice.instance.totalPrice -= price;
        GetComponent<TextMeshProUGUI>().text = (--count).ToString();
        TotalPrice.instance.setPrice();
    }
    
}
