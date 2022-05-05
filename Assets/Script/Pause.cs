using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Image play;
    public Image home;
    private void Start()
    {
        play.gameObject.SetActive(false);
        home.gameObject.SetActive(false);
    }
    public void pause()
    {
        play.gameObject.SetActive(true);
        home.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
    public void play1()
    {
        play.gameObject.SetActive(false);
        home.gameObject.SetActive(false);
        Time.timeScale = 1;

    }
    public void home1()
    {
        SceneManager.LoadScene(0);

    }
}
