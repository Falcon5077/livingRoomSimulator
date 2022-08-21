using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPopCorn : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject PopCorn;
    public int i = 0;
    public int keyCount = 5;
    public void repeatFunc()
    {
        SendMessage("Shake");
        for (int i = 0; i < keyCount; i++)
        {
            GameObject Temp = Instantiate(PopCorn, spawnPosition.position, Quaternion.Euler(new Vector3(Random.Range(-45f, 45f), 0, 0)),spawnPosition);
        }

        if (i-- >= 0)
            Invoke("repeatFunc", 0.3f);
    }

    public void CreatePop()
    {
        i = 10;
        repeatFunc();
    }

}
