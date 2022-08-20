using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material opaqueMat;
    public Material transparentMat;
    public float offset = 10f;
    public List<ChangeMaterial> childObject = new List<ChangeMaterial>();
    private Renderer rend;
    public int childCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        childCount = childObject.Count;
    }
    public void UpdateMaterial(bool transparent,bool isChild = false)
    {
        if (transparent)
        {
            rend.material = transparentMat;
            rend.material.color = new Color32(255, 255, 255, 150);

            if (!isChild)
            {
                transform.parent.rotation = GameManager.Player.transform.rotation;
                transform.parent.position = new Vector3(GameManager.Player.transform.position.x, transform.parent.position.y, GameManager.Player.transform.position.z) + GameManager.Player.transform.forward * offset;
            }
               
        }
        else
        {
            rend.material = opaqueMat;
        }

        if(childCount > 0)
        {
            SetChildMaterial(transparent);
        }
    }
    public void SetColorObject(bool canDrop,bool isChild = false)
    {
        if (canDrop) // 초록색
            rend.material.color = new Color32(0, 150, 0, 150);
        else // 빨간색
            rend.material.color = new Color32(150, 0, 0, 150);


        if (childCount > 0)
        {
            SetChildColor(canDrop);
        }
    }
    public void SetChildColor(bool canDrop)
    {
        for (int i = 0; i < childCount; i++)
        {
            childObject[i].SetColorObject(canDrop,true);
        }
    }

    public void SetChildMaterial(bool transparent)
    {
        for (int i = 0; i < childCount; i++)
        {
            childObject[i].UpdateMaterial(transparent, true);
        }
    }
}
