using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStone : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stone")
        {
            Destroy(other.gameObject);
        }
    }
}
