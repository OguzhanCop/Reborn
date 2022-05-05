using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    public GameObject enemy, hero;
    public float xPosition, zPosition, enemyCount;
    public Transform enemyPos;
    float dist;
    int maxenemy;
    int level ;
    int a;


    void Start()
    {
        level = PlayerPrefs.GetInt("Level");
        if (level == 1)
            a = 5;
        if (level == 2)
            a = 7;
        if (level == 3)
            a = 10;
        if (level == 4)
            a = 13;
        if (level == 5)
            a = 14;
        if (level == 6)
            a = 15;

        maxenemy = a;
        StartCoroutine(EnemyDrop());
        
        InvokeRepeating("arttýr", 10F, 10f);
    }
    
    IEnumerator EnemyDrop()
    {
        while (enemyCount < maxenemy)
        {
            
            xPosition = Random.Range(-100, 100);
            zPosition = Random.Range(-100, 100);
            dist = Vector3.Distance(enemyPos.position, hero.transform.position);
            if (dist > 2.0f)
            {
                
                Instantiate(enemy, new Vector3(xPosition, 0.8f, zPosition), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                enemyCount += 1;
            }
            
        }
       
     

    }
    void arttýr()
    {
        maxenemy += a;
        StartCoroutine(EnemyDrop());
    }
}