using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneForce : MonoBehaviour
{
    public float forcePower;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.right * forcePower, ForceMode.Impulse);
    }
    void FixedUpdate()
    {
    }
}
