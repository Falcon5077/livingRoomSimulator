using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCleaner : MonoBehaviour
{
    public bool isCleaning = false;
    public float rotaSpeed = 10f;
    public List<GameObject> popCorns = new List<GameObject>();
    public List<Vector3> currentPoses = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator rota()
    {
        float elapsedTime = 0f;
        float waitTime = 5f;
        while(isCleaning)
        {
            for(int i = 0 ; i < popCorns.Count; i++)
            {
                popCorns[i].transform.position = Vector3.Lerp(currentPoses[i], transform.position, (elapsedTime / waitTime));
                
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        for(int i = 0 ; i < popCorns.Count; i++)
        {
            Destroy(popCorns[i]);
        }
        popCorns.Clear();

    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "keycaps")
        {
            popCorns.Add(other.gameObject);
            currentPoses.Add(other.transform.position);
            Transform Temp = other.transform.parent;
            other.transform.parent = null;
            Destroy(Temp.gameObject);
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<MeshCollider>().isTrigger = true;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log(other.tag);
        }
            
    }
}
