using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Atackfire2 : MonoBehaviour
{
    int f2;
    public TextMeshProUGUI skor;
    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.tag == "enemy")
        {
            GameObject bar = other.transform.GetChild(1).GetChild(1).gameObject;
            bar.GetComponent<Image>().fillAmount -= 0.2f;
            f2 = PlayerPrefs.GetInt("RuhSayýsý");

            if (bar.GetComponent<Image>().fillAmount <= 0)
                {

                Destroy(other.gameObject);
                f2++;
                PlayerPrefs.SetInt("RuhSayýsý", f2);
                skor.text = f2 + "/25";
            }
        }
    }
}
