using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Atackligfht1 : MonoBehaviour
{
    int L1;
    public TextMeshProUGUI skor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            GameObject bar = other.transform.GetChild(1).GetChild(1).gameObject;
            bar.GetComponent<Image>().fillAmount -= 0.5f;
            L1 = PlayerPrefs.GetInt("RuhSayýsý");
            gameObject.SetActive(false);
            if (bar.GetComponent<Image>().fillAmount <= 0)
            {

                Destroy(other.gameObject);
                L1++;
                PlayerPrefs.SetInt("RuhSayýsý", L1);
                skor.text =L1 + "/25";
            }
        }
    }
}
