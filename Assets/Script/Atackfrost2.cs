using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Atackfrost2 : MonoBehaviour
{
    int i2;
    public TextMeshProUGUI skor;
    private void OnTriggerEnter(Collider other)
 
   {
        if (other.gameObject.tag == "enemy")
        {
            GameObject bar = other.transform.GetChild(1).GetChild(1).gameObject;
            bar.GetComponent<Image>().fillAmount -= 0.2f;
           i2 = PlayerPrefs.GetInt("RuhSay�s�");

            if (bar.GetComponent<Image>().fillAmount <= 0)
            {

                Destroy(other.gameObject);
                i2++;
                PlayerPrefs.SetInt("RuhSay�s�", i2);
                skor.text = i2 + "/25";
            }
        }
    }
}