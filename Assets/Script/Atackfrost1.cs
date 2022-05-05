using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Atackfrost1 : MonoBehaviour
{
    int i1;
    public TextMeshProUGUI skor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            GameObject bar = other.transform.GetChild(1).GetChild(1).gameObject;
            bar.GetComponent<Image>().fillAmount -= 0.5f;
            i1 = PlayerPrefs.GetInt("RuhSayýsý");
            gameObject.SetActive(false);
            if (bar.GetComponent<Image>().fillAmount <= 0) 
            { 

                Destroy(other.gameObject);
            i1++;
            PlayerPrefs.SetInt("RuhSayýsý", i1);
            skor.text = i1 + "/25";
        }
    }
    }
}
