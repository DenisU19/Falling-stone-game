using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStone : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Big stone"||other.tag == "Small stone")
        {
            Destroy(other.gameObject);
        }
    }
}
