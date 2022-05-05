using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class csDestroyEffect : MonoBehaviour {

    public AudioSource teleport;
    public AudioSource gerilim;
    GameObject ses;

    
    private void Start()
    {
        ses = GameObject.FindGameObjectWithTag("ses");
    }
    void Update()
    {

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = new Vector3(-303.97f, -216.52f, 236.978f);

        teleport.Play();
        gerilim.Stop();

        ses.GetComponent<AudioSource>().mute = false;
       
        SceneManager.LoadScene(2);

    }

     
}
