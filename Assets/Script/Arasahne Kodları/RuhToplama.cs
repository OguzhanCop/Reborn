using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RuhToplama : MonoBehaviour
{       public GameObject Angel;
        public GameObject Soul;
        public Scrollbar RuhSayac�;
        public TextMeshProUGUI barsay�s�text;
        public TextMeshProUGUI Bilgilendirme;
        public TextMeshProUGUI RuhSay�s�;
        int barsay�s�=0;
        bool kontrol = true;
    GameObject ses;


    // Start is called before the first frame update
    void Start()
    {
        
        Soul.SetActive(false);
        RuhSayac�.size = PlayerPrefs.GetInt("ToplamRuhSay�s�")*0.04f;
        RuhSay�s�.text = "Toplam Ruh Say�s�: "+PlayerPrefs.GetInt("RuhSay�s�");
         ses = GameObject.FindGameObjectWithTag("ses");
        ses.GetComponent<AudioSource>().mute = true;


    }

    // Update is called once per frame
    void Update()
    {
      



        if (PlayerPrefs.GetInt("barsay�s�") == 6)
        {
            ses.GetComponent<AudioSource>().mute = false;
            SceneManager.LoadScene(4);
          
        }

       
    
           
        if(RuhSayac�.size==1&&kontrol)
        {
            kontrol = false;
            PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level")+1);
            PlayerPrefs.SetInt("barsay�s�", PlayerPrefs.GetInt("barsay�s�")+1);
            barsay�s� = PlayerPrefs.GetInt("barsay�s�");
            barsay�s�text.text = barsay�s� + "";
            PlayerPrefs.SetInt("ToplamRuhSay�s�",0);
            RuhSayac�.size = 0;
        }
        
    }

    IEnumerator aktar()
    {
        while (!(Soul.transform.position == Angel.transform.position))
        {

            Soul.transform.position = Vector3.MoveTowards(Soul.transform.position, Angel.transform.position, 0.01f);
            yield return new WaitForSeconds(4);
        }
        yield return new WaitForSeconds(4);
    }
    private void OnTriggerStay(Collider other)
    {
        Soul.transform.position = transform.position+new Vector3(0,3f,0);
        if(PlayerPrefs.GetInt("RuhSay�s�") != 0) { 
        Bilgilendirme.text = "FOR TRANSFORM THE SOULS PRESS THE BUTTON T";
        }
        else { 
            Bilgilendirme.text = "GO BACK TO THE PORTAL TO FIGHT";
            }
        if (Input.GetKey(KeyCode.T))

        {
            

            if (PlayerPrefs.GetInt("RuhSay�s�") != 0)
            {
               
                PlayerPrefs.SetInt("RuhSay�s�", PlayerPrefs.GetInt("RuhSay�s�") - 1);
                RuhSay�s�.text = "Toplam Ruh Say�s�: " + PlayerPrefs.GetInt("RuhSay�s�");
                PlayerPrefs.SetInt("ToplamRuhSay�s�", PlayerPrefs.GetInt("ToplamRuhSay�s�") + 1);
                RuhSayac�.size = 0.04f + RuhSayac�.size;
                for (int i = 0; i < 10; i++)
                {
                    while (!(Soul.transform.position == Angel.transform.position))
                    {
                        Soul.SetActive(true);
                        Soul.transform.position = Vector3.MoveTowards(Soul.transform.position, Angel.transform.position, 0.01f);
                    }
                    Soul.transform.position = transform.position + new Vector3(0, 3f, 0);
                    while (!(Soul.transform.position == Angel.transform.position))
                    {
                        Soul.SetActive(true);
                        Soul.transform.position = Vector3.MoveTowards(Soul.transform.position, Angel.transform.position, 0.01f);
                    }
                    if (PlayerPrefs.GetInt("RuhSay�s�") == 0)
                    {
                        Soul.SetActive(false);
                        Bilgilendirme.text = "GO BACK TO THE PORTAL TO FIGHT";
                    }
                    Soul.transform.position = transform.position + new Vector3(0, 3f, 0);
                }

            }
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Bilgilendirme.text = " ";
    }
}
