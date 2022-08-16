using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingBed : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    public void Sleep()
    {
        SendMessage("SetPlayerPosition");
    }
}
