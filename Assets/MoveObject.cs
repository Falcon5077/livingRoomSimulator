using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Material opaqueMat;
    public Material transparentMat;
    private Renderer rend;
    public bool isAlpha = false;
    public Vector3 offset = new Vector3(10,0,0);
    public GameObject Player;
    public float turnSpeed = 2.0f;
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
        if(isAlpha)
        {
            transform.parent.parent = Player.transform;
            
        }
        else
        {
            transform.parent.parent = null;
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            isAlpha = !isAlpha;
            UpdateMaterial(isAlpha);
        }
    }
    
    void UpdateMaterial(bool transparent) {
        if (transparent) {
            //rend.material = transparentMat;
            
            transform.parent.rotation = Player.transform.rotation;

            //transform.parent.position = new Vector3(Player.transform.position.x,transform.parent.position.y,Player.transform.position.z) + offset;
        }
        else {
            //rend.material = opaqueMat;
        }
    }
}