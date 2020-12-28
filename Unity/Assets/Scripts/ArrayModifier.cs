﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayModifier : MonoBehaviour
{
    public int CountX;
    public int CountY;
    public GameObject TheObject;
    public float offset;
    void OnValidate()
    {
        Apply();

    }

    private void Apply()
    {
        if (offset == null) offset = 0;
        if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode) return;
        if (TheObject == null) return;
        Renderer renderer = TheObject.GetComponent<Renderer>();
        if(renderer != null)
        {
            foreach(Transform t in transform)
            {
                UnityEditor.EditorApplication.delayCall += () =>
                {
                    DestroyImmediate(t.gameObject);
                };
            }
        }

        float lastX = 0;
        float lastY = 0;

        for (int i=0; i<CountY; i++)
        {
            for(int j=0; j <CountX; j++)
            {
                Vector3 pos = new Vector3(transform.localPosition.x, lastY + transform.localPosition.y, transform.localPosition.z + lastX);
                GameObject go = Instantiate(TheObject, pos, Quaternion.identity, transform) as GameObject;
                go.name = TheObject.name + "_" + i + "_" + j;
                lastX -= renderer.bounds.size.z + offset;
            }
            lastX = 0;
            lastY += renderer.bounds.size.y;
        }
    }
}
