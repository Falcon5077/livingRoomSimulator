using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameObject Player;
    public static bool isLay = false;
    public static bool something_Grab = false;
    public Image sleepImage;
    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        Player = this.gameObject;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent != null)
        {
            GetComponent<CapsuleCollider>().isTrigger = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }  
        else if(isLay){
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            Player.GetComponent<PlayerMove>().enabled = false;
        }  
        else
        {
            GetComponent<CapsuleCollider>().isTrigger = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        }
    }

    public void FadeOut()
    {
        StartCoroutine("FadeRoutine");
    }

    IEnumerator FadeRoutine()
    {
        for(int i = 0; i < 100; i++)
        {
            sleepImage.color = new Color(0,0,0,i * 0.01f);
            yield return new WaitForSeconds(0.01f);
        }


        yield return new WaitForSeconds(1f);

        Wakeup();
        
        for(int i = 0; i < 50; i++)
        {
            sleepImage.color = new Color(0,0,0,1 - (i * 0.02f));
            yield return new WaitForSeconds(0.02f);
        }
    }


    public void Wakeup(){
        Player.GetComponent<PlayerMove>().enabled = true;
        isLay = false;
        
        Camera.main.transform.localPosition = new Vector3(0, 0, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }


}
