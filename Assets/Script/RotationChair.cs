using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationChair : MonoBehaviour
{
    public GameObject Player;
    public float rotateTime = 1f;
    public float targetAngle = 90.0f;

    private void Start() {
        Player = GameObject.FindWithTag("Player");
    }
    public void Tornado()
    {
        SendMessage("SetPlayerPosition");
        StartCoroutine("Typhoon");
    }
    float round90(float f)
    {
        float r = f % 90;
        return (r < 45) ? f - r : f - r + 90;
        
    }

    IEnumerator Typhoon()
    {
        Player.transform.parent = this.transform;

        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + targetAngle;
        float t = 0.0f;

        while ( t  < rotateTime )
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / rotateTime) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, 
            transform.eulerAngles.z);
            yield return null;
        }

        Player.transform.parent = null;
        Player.transform.position = new Vector3(transform.position.x,10,transform.position.z) + (transform.right * 5);
    }
}
