using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour
{

    public GameObject portal;
    
    void Start()
    {
        portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("RuhSayýsý") >= 25)
        {
            if (portal.activeSelf == false)
            {
                portal.transform.position = transform.position + new Vector3(20f, 0f, 20f);
                portal.SetActive(true);
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "portal")
            SceneManager.LoadScene(3);
    }
}
