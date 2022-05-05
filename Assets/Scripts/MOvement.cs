using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  

public class MOvement : MonoBehaviour
{
    public Transform hero;
    NavMeshAgent nMesh;
    void Start()
    {
         nMesh = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        nMesh.destination = hero.position;
    }
}
