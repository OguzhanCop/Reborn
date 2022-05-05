using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameratakip : MonoBehaviour
{
    Vector3 mesafe;
    public GameObject caracter;
    void Start()
    {
        mesafe = transform.position - caracter.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = caracter.transform.position + mesafe;
    }
}
