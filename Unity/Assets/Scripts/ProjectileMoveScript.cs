﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveScript : MonoBehaviour
{
    public float Speed;
    public GameObject Impactprefab;
    public List<GameObject> Trails;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        if(Speed != 0 && rb != null)
        {
            rb.position += transform.forward * (Speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision) 
    {
        Speed = 0;

        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if(Impactprefab != null)
        {
            var impactVFX = Instantiate(Impactprefab, pos, rot) as GameObject;
            Destroy (impactVFX, 5);
        }

        if(Trails.Count > 0)    //faccio durare la scia di fumo dopo che il lapillo ha colpito il terreno
        {
            for(int i = 0; i<Trails.Count; i++)
            {
                Trails[i].transform.parent = null;
                var ps = Trails[i].GetComponent<ParticleSystem>();
                if(ps!=null)
                {
                    ps.Stop();
                    Destroy (ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
                }
            }
        }

        Destroy (gameObject);
    }
}
