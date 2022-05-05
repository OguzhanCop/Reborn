using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RuhToplama : MonoBehaviour
{       public GameObject Angel;
        public GameObject Soul;
        public Scrollbar RuhSayacý;
        public TextMeshProUGUI barsayýsýtext;
        public TextMeshProUGUI Bilgilendirme;
        public TextMeshProUGUI RuhSayýsý;
        int barsayýsý=0;
        bool kontrol = true;
    GameObject ses;


    // Start is called before the first frame update
    void Start()
    {
        
        Soul.SetActive(false);
        RuhSayacý.size = PlayerPrefs.GetInt("ToplamRuhSayýsý")*0.04f;
        RuhSayýsý.text = "Toplam Ruh Sayýsý: "+PlayerPrefs.GetInt("RuhSayýsý");
         ses = GameObject.FindGameObjectWithTag("ses");
        ses.GetComponent<AudioSource>().mute = true;


    }

    // Update is called once per frame
    void Update()
    {
      



        if (PlayerPrefs.GetInt("barsayýsý") == 6)
        {
            ses.GetComponent<AudioSource>().mute = false;
            SceneManager.LoadScene(4);
          
        }

       
    
           
        if(RuhSayacý.size==1&&kontrol)
        {
            kontrol = false;
            PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level")+1);
            PlayerPrefs.SetInt("barsayýsý", PlayerPrefs.GetInt("barsayýsý")+1);
            barsayýsý = PlayerPrefs.GetInt("barsayýsý");
            barsayýsýtext.text = barsayýsý + "";
            PlayerPrefs.SetInt("ToplamRuhSayýsý",0);
            RuhSayacý.size = 0;
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
        if(PlayerPrefs.GetInt("RuhSayýsý") != 0) { 
        Bilgilendirme.text = "FOR TRANSFORM THE SOULS PRESS THE BUTTON T";
        }
        else { 
            Bilgilendirme.text = "GO BACK TO THE PORTAL TO FIGHT";
            }
        if (Input.GetKey(KeyCode.T))

        {
            

            if (PlayerPrefs.GetInt("RuhSayýsý") != 0)
            {
               
                PlayerPrefs.SetInt("RuhSayýsý", PlayerPrefs.GetInt("RuhSayýsý") - 1);
                RuhSayýsý.text = "Toplam Ruh Sayýsý: " + PlayerPrefs.GetInt("RuhSayýsý");
                PlayerPrefs.SetInt("ToplamRuhSayýsý", PlayerPrefs.GetInt("ToplamRuhSayýsý") + 1);
                RuhSayacý.size = 0.04f + RuhSayacý.size;
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
                    if (PlayerPrefs.GetInt("RuhSayýsý") == 0)
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
