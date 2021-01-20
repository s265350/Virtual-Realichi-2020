﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ArrayMod1 : MonoBehaviour
{
    [SerializeField] Transform _prefab;
    [SerializeField, Range(1, 300)] int _count = 1;
    [SerializeField] Vector3 _translate = Vector3.zero;
    [SerializeField] Vector3 _rotation = Vector3.zero;
    [SerializeField] Vector3 _scale = Vector3.one;
    [SerializeField] Vector3 _randomizeTranslateFactor = Vector3.zero;
    [SerializeField] Vector3 _randomizeRotationFactor = Vector3.zero;
    [SerializeField] Vector3 _randomizeScaleFactor = Vector3.zero;
    Transform _transform;

    void Start()
    {
        _transform = transform;
        UnityEditor.EditorApplication.delayCall += Reset;
    }

    void Destroy()
    {
        UnityEditor.EditorApplication.delayCall += Reset;
    }

    void OnValidate()
    {
        _transform = transform;
        UnityEditor.EditorApplication.delayCall += Reset;
    }

    void Reset()
    {
        UnityEditor.EditorApplication.delayCall -= Reset;

        if (_prefab == null)
        {
            Debug.LogError("prefab is null");
        }

        // Get children to remove
        var objToRemove = new List<GameObject>();
        foreach (Transform child in _transform)
        {
            objToRemove.Add(child.gameObject);
        }

        // Create children
        var pos = Vector3.zero;
        var rot = Quaternion.identity;
        var scale = Vector3.one;
        for (int i = 0; i < _count; i++)
        {
            var obj = Instantiate(_prefab, pos, rot, _transform);
            obj.localScale = scale;

            pos += _translate + Vector3.Scale(Random.insideUnitSphere, _randomizeTranslateFactor);
            rot = rot * Quaternion.Euler(_rotation + Vector3.Scale(Random.rotation.eulerAngles, _randomizeRotationFactor));
            scale = Vector3.Scale(scale, _scale) + Vector3.Scale(Random.insideUnitSphere, _randomizeScaleFactor);
        }

        // Remove old children
        foreach (var obj in objToRemove)
        {
            DestroyImmediate(obj);
        }
    }
}