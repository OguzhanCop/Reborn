using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Atackfire1 : MonoBehaviour
{
    int F1;
    public TextMeshProUGUI skor;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            GameObject bar = other.transform.GetChild(1).GetChild(1).gameObject;
            bar.GetComponent<Image>().fillAmount -= 0.5f;
            F1 = PlayerPrefs.GetInt("RuhSayýsý");
            gameObject.SetActive(false);
            if (bar.GetComponent<Image>().fillAmount <= 0)
            {
                Destroy(other.gameObject);
                F1++;
                PlayerPrefs.SetInt("RuhSayýsý", F1);
           
                skor.text =  F1+"/25";
            }
        }

    }
    
}

