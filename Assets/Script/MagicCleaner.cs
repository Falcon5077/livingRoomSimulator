using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCleaner : MonoBehaviour
{
    public Vector3 Center = new Vector3(-25, 0, -25);
    public float smoot = 2f;
    public GameObject Target;
    public bool isRota = true;
    public float rotaSpeed = 10f;
    public GameObject roomCleaner;

    public void FlyCleaner()
    {
        roomCleaner.SetActive(true);
        isRota = true;
        roomCleaner.GetComponent<RoomCleaner>().isCleaning = true;
        StartCoroutine(roomCleaner.GetComponent<RoomCleaner>().rota());
        StartCoroutine("Magic");
        StartCoroutine("rota");
    }
    IEnumerator rota()
    {
        while(isRota)
        {
            transform.Rotate(Vector3.up * rotaSpeed);
            transform.Rotate(Vector3.up * rotaSpeed, Space.World);
            yield return null;
        }
    }
    IEnumerator Magic()
    {
        Vector3 firstPos = transform.parent.position;
        Quaternion firstRot = transform.rotation;
        Quaternion firstParentRot = transform.parent.rotation;

        float elapsedTime = 0f;
        float waitTime = 0.9f;
        Vector3 currentPos = transform.parent.position;
        Vector3 Gotoposition = currentPos;
        Gotoposition.y = 3f;

        while (elapsedTime < waitTime)
        {
            transform.parent.position = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }
        // Make sure we got there
        transform.parent.position = Gotoposition;

        elapsedTime = 0f;

        while (elapsedTime < waitTime)
        {
            transform.parent.localRotation = Quaternion.Slerp(transform.parent.localRotation, Quaternion.LookRotation(new Vector3(-25, 0, -25), new Vector3(-1,1,1)), (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }
        yield return null;


        elapsedTime = 0f;
        currentPos = transform.parent.position;
        Gotoposition = new Vector3(-25, 5, -25);

        while (elapsedTime < waitTime)
        {
            transform.parent.position = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }
        // Make sure we got there
        transform.parent.position = Gotoposition;

        
        for(int i = 0; i < 10; i++)
        {
            elapsedTime = 0f;
            currentPos = transform.parent.position;
            Gotoposition = new Vector3(Random.Range(-40, -4), Random.Range(0, 5), Random.Range(-10, -50));

            while (elapsedTime < waitTime)
            {
                transform.parent.position = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;

                // Yield here
                yield return null;
            }
            // Make sure we got there
            transform.parent.position = Gotoposition;
        }

        elapsedTime = 0f;
        currentPos = transform.parent.position;
        Gotoposition = firstPos;

        while (elapsedTime < waitTime)
        {
            
            transform.parent.position = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));
            transform.parent.localRotation = Quaternion.Slerp(transform.parent.localRotation, firstParentRot, (elapsedTime / waitTime));
            transform.localRotation = Quaternion.Slerp(transform.localRotation, firstRot, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }
        // Make sure we got there
        transform.parent.position = Gotoposition;

        isRota = false;
        roomCleaner.GetComponent<RoomCleaner>().isCleaning = false;

        roomCleaner.SetActive(false);
        GetComponent<MoveObject>().canDrop = true;
    }
}
