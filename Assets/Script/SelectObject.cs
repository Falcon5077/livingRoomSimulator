using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    Material outline;   
    Renderer renderers;
    public List<Material> materialList = new List<Material>();
    public bool isSelected = false;
    void Start()
    {
        outline = new Material(Shader.Find("Draw/OutlineShader"));
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
}
