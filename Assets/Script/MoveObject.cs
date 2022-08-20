using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
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
                    GameManager.something_Grab = false;
                    GrabObject();
                    GetComponent<MeshCollider>().isTrigger = false;
                    transform.parent.parent = null;
                }
                else if(GetComponent<SelectObject>().isSelected == true)
                {
                    isGrab = true;
                    GameManager.something_Grab = true;
                    GrabObject();
                    GetComponent<MeshCollider>().isTrigger = true;
                    transform.parent.parent = Player.transform;
                }
            }
        }

        if(isGrab){
            GetComponent<SelectObject>().SetMyRota();
            GetComponent<ChangeMaterial>().SetColorObject(canDrop);
            RotateObject_Mouse_X();
        }
        else
            rend.material.color = new Color(1,1,1,1);
    }
    private void RotateObject_Mouse_X()
    {
        if (Input.GetMouseButton(1))
        {
            transform.parent.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        }

    }
    private void GrabObject()
    {
        isAlpha = !isAlpha;
        GetComponent<ChangeMaterial>().UpdateMaterial(isAlpha);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" || (this.tag != "Untagged" && other.tag == this.tag))
            return;
        canDrop = false;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || (this.tag != "Untagged" && other.tag == this.tag))
            return;
        canDrop = false;
    }
    private void OnTriggerExit(Collider other) {
        canDrop = true;
    }
}
