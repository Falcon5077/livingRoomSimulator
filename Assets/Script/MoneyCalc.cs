using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyCalc : MonoBehaviour
{
    public int totalMoney = 0;
    public static MoneyCalc instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<TextMeshProUGUI>().text = "Money : " + string.Format("{0:0,0}", totalMoney);
    }

    public void BuyItem()
    {
        int temp = totalMoney;
        temp -= TotalPrice.instance.totalPrice;
        if(temp <= 0)
            return;
        totalMoney = temp;
    }
}
