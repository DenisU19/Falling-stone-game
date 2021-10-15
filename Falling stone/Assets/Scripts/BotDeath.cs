using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotDeath : MonoBehaviour
{
    private GameObject botRagdoll;
    public GameObject botRagdollPrefab;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Big stone") || other.gameObject.CompareTag("Small stone"))
        {
            Destroy(gameObject);
            botRagdoll = Instantiate(botRagdollPrefab, transform.position, transform.rotation);
        }
    }
}
