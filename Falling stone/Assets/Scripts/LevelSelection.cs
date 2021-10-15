using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Transform levelsContainer;
    public  int countUnlockedLevel = 1;
    public Text levelComingSoon;
    void Start()
    {
        countUnlockedLevel = PlayerPrefs.GetInt("CountUnlockedLevel");
        for (int i = 1; i < levelsContainer.childCount; i++)
        {
            if(i<countUnlockedLevel)
            {
                levelsContainer.GetChild(i).GetComponent<Image>().color = Color.white;
                levelsContainer.GetChild(i).GetComponent<Button>().interactable = true;
            }
            else
            {
                levelsContainer.GetChild(i).GetComponent<Image>().color = Color.grey;
                levelsContainer.GetChild(i).GetComponent<Button>().interactable = false;
            }
        }
    }
    public void LoadTo(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ResetLevels()
    {
        PlayerPrefs.DeleteKey("CountUnlockedLevel");
        countUnlockedLevel = PlayerPrefs.GetInt("CountUnlockedLevel");
        for (int i = 1; i < levelsContainer.childCount; i++)
        {
            if (i < countUnlockedLevel)
            {
                levelsContainer.GetChild(i).GetComponent<Image>().color = Color.white;
                levelsContainer.GetChild(i).GetComponent<Button>().interactable = true;
            }
            else
            {
                levelsContainer.GetChild(i).GetComponent<Image>().color = Color.grey;
                levelsContainer.GetChild(i).GetComponent<Button>().interactable = false;
            }
        }
    }
    public void ComingSoon()
    {
        StartCoroutine("LevelComingSoon");
    }
    private  IEnumerator LevelComingSoon()
    {
        levelComingSoon.gameObject.SetActive(true);
        levelComingSoon.gameObject.transform.position = Input.mousePosition;
        yield return new WaitForSeconds(0.2f);
        levelComingSoon.gameObject.SetActive(false);
    }
}
