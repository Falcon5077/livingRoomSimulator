using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPopCorn : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject PopCorn;

    public void CreatePop()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject Temp = Instantiate(PopCorn, spawnPosition.position, Quaternion.Euler(new Vector3(Random.Range(-45f, 45f), 0, 0)));
        }
    }

}
