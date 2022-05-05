using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    public AudioSource müzik; 
    void Start()
    {
        PlayerPrefs.SetInt("can", 3);
        PlayerPrefs.SetInt("ToplamRuhSayýsý", 0);
        PlayerPrefs.SetInt("RuhSayýsý", 0);
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("barsayýsý", 0);

        DontDestroyOnLoad(müzik);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playgeç()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
