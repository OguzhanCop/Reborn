using UnityEngine;
using System.Collections;

public class csParticleMove : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject Explode;
    public GameObject mouse;
	void Update () {
        transform.Translate(Vector3.forward * speed);
	}
    private void OnCollisionEnter(Collision collision)
    {
       
        gameObject.transform.rotation = Quaternion.Euler(90, 90, 90);
        Explode.SetActive(true);
        Explode.transform.position = gameObject.transform.position;
        gameObject.SetActive(false);
    }
}
