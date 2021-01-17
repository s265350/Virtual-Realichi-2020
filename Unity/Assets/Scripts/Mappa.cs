using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mappa : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private bool flashingIn = true;

    private void OnEnable()
    {
       StartCoroutine(flashingObject());
    }

    private IEnumerator flashingObject()
    {
        while (true)
        {
            yield return null;
        }
        
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
