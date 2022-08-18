using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    Material outline;   
    Renderer renderers;
    List<Material> materialList = new List<Material>();
    Quaternion mRota;
    public bool isSelected = false;
    bool isRight = false;
    bool isUp = false;
    public string FunctionName = "";
    void Start()
    {
        outline = new Material(Shader.Find("Draw/OutlineShader"));
        mRota = transform.rotation;
    }

    public void SetMyRota()
    {
        mRota = transform.rotation;
    }

    public void RayEnter()
    {
        renderers = this.GetComponent<Renderer>();

        materialList.Clear();
        materialList.AddRange(renderers.sharedMaterials);
        materialList.Add(outline);

        renderers.materials = materialList.ToArray();

        isSelected = true;
    }

    public void RayExit()
    {
        Renderer renderer = this.GetComponent<Renderer>();

        materialList.Clear();
        materialList.AddRange(renderer.sharedMaterials);       
        materialList.Remove(outline);

        renderer.materials = materialList.ToArray();  

        isSelected = false;
    }

    public void RunningFunction()
    {
        if(FunctionName == "")
        {
            Shake();
        }
        else
        {
            SendMessage(FunctionName);
        }
    }
    public void Shake()
    {
        StartCoroutine("ShakeObject");
    }

    IEnumerator ShakeObject()
    {
        int way = -1;
        for(int i = 0; i < 10; i++)
        {
            if(isUp)
                transform.Rotate(Vector3.up,0.3f * way * (i+1),Space.Self);
            else if(isRight)
                transform.Rotate(Vector3.right,0.3f * way * (i+1),Space.Self);
            else
                transform.Rotate(Vector3.forward,0.3f * way * (i+1),Space.Self);
                
            yield return new WaitForSeconds(0.05f);
            way *= -1;
            transform.rotation = mRota;
        }
    }
}
