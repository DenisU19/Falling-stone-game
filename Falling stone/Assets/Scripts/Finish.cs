using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour
{
    public GameObject levelCompleteImage;
    public GameObject GaveOverImage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelCompleteImage.SetActive(true);
            Time.timeScale = 0;
            PlayerPrefs.SetInt("CountUnlockedLevel", SceneManager.GetActiveScene().buildIndex + 1);
      
        }
        else if(other.tag == "Bot")
        {
            GaveOverImage.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
}
