using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Material opaqueMat;
    public Material transparentMat;
    public float offset = 10f;

    public float TurnSpeed = 100f;

    private Renderer rend;
    private bool isAlpha = false;
    private GameObject Player;
    public bool isGrab = false;
    public bool canDrop = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Player = GameObject.FindWithTag("Player");
    }

 //the layers the ray can hit
    void Awake() {
        rend = GetComponent<Renderer>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(canDrop){
                if(isGrab == true)
                {
                    isGrab = false;
                    GrabObject();
                    GetComponent<MeshCollider>().isTrigger = false;
                }
                else if(GetComponent<SelectObject>().isSelected == true)
                {
                    isGrab = true;
                    GrabObject();
                    GetComponent<MeshCollider>().isTrigger = true;
                }
            }
        }

        if(isAlpha)
        {
            transform.parent.parent = Player.transform;
        }
        else
        {
            transform.parent.parent = null;
        }

        if(isGrab){
            GetComponent<SelectObject>().SetMyRota();
            if (Input.GetMouseButton(1))
            {
                transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
            }

            if(canDrop)
                GetComponent<Renderer>().material.color = new Color32(0, 150, 0, 150);
            else
                GetComponent<Renderer>().material.color = new Color32(150, 0, 0, 150);
        }
        else
            GetComponent<Renderer>().material.color = new Color(1,1,1,1);


    }

    public void GrabObject()
    {
        isAlpha = !isAlpha;
        UpdateMaterial(isAlpha);
    }
    
    void UpdateMaterial(bool transparent) {
        if (transparent) {
            rend.material = transparentMat;
            transform.parent.rotation = Player.transform.rotation;
            transform.parent.position = new Vector3(Player.transform.position.x, transform.parent.position.y, Player.transform.position.z) + Player.transform.forward * offset;
        }
        else {
            rend.material = opaqueMat;
        }
    }

    private void OnTriggerEnter(Collider other) {
        canDrop = false;
    }

    private void OnTriggerStay(Collider other) {
        canDrop = false;
    }
    private void OnTriggerExit(Collider other) {
        canDrop = true;
    }
}
