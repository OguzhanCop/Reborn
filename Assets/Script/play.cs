using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    public AudioSource m�zik; 
    void Start()
    {
        PlayerPrefs.SetInt("can", 3);
        PlayerPrefs.SetInt("ToplamRuhSay�s�", 0);
        PlayerPrefs.SetInt("RuhSay�s�", 0);
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("barsay�s�", 0);

        DontDestroyOnLoad(m�zik);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playge�()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
