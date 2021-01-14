using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Color highlightColor;
    [SerializeField] private Renderer characterMaterials;
    void Start()
    {
        highlightColor = new Color(0.1698113f, 0.1698113f, 0.1698113f, 1);
        //gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        //GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        characterMaterials = GetComponentInChildren<Renderer>();
        foreach(Material mat in characterMaterials.materials)
        {
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", Color.black);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetObject()
    {
        Destroy(gameObject);
    }

    public void HighlightObject()
    {
        foreach (Material mat in characterMaterials.materials)
        {
            mat.SetColor("_EmissionColor", highlightColor);
        }
        //GetComponent<Renderer>().material.SetColor("_EmissionColor", highlightColor);
    }

    public void ReturnOriginalColor()
    {
        foreach (Material mat in characterMaterials.materials)
        {
            mat.SetColor("_EmissionColor", Color.black);
        }
        //GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
    }
}
