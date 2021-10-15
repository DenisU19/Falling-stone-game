using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDeath : MonoBehaviour
{
    public GameObject gameOverImage;
    private GameObject heroRagdoll;
    public GameObject heroRagdollPrefab;
    
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Big stone")|| other.gameObject.CompareTag("Small stone"))
            {
            gameObject.SetActive(false);
            heroRagdoll = Instantiate(heroRagdollPrefab, transform.position, transform.rotation);
            Invoke("GameOver", 2f);
            }
        }
    private void GameOver()
    {
        gameOverImage.SetActive(true);
        Time.timeScale = 0;
    }
}
