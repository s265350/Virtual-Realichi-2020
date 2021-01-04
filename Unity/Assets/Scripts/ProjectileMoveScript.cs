using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveScript : MonoBehaviour
{
    public float Speed;
    public GameObject Impactprefab;
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

        Destroy (gameObject);
    }
}
