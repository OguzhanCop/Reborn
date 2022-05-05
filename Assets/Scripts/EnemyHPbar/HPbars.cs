using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class HPbars : MonoBehaviour
{
    public Image healhtBar;

    public void UpdateHealth(float fraction)
    {
        healhtBar.fillAmount = fraction;
    }

}
