using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Atacklight2 : MonoBehaviour
{
    int L2;
    public TextMeshProUGUI skor;
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.tag == "enemy")
        {
            GameObject bar = other.transform.GetChild(1).GetChild(1).gameObject;
            bar.GetComponent<Image>().fillAmount -= 0.2f;
            L2 = PlayerPrefs.GetInt("RuhSayýsý");
            if (bar.GetComponent<Image>().fillAmount <= 0)
            {
                Destroy(other.gameObject);
                L2++;
                PlayerPrefs.SetInt("RuhSayýsý", L2);
                skor.text = L2 + "/25";
            }
        }
    }
}
