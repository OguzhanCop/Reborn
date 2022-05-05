using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomly : MonoBehaviour
{
    public GameObject enemy, hero;
    public float xPosition, zPosition, enemyCount;
    public Transform enemyPos;
    float dist;

    void Start()
    {
        
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount<10)
        {
            xPosition = Random.Range(24, 60);
            zPosition = Random.Range(24, 60);
            dist = Vector3.Distance(enemyPos.position,hero.transform.position);
            if (dist > 2.0f)
            {
                Debug.Log("calistim");
                Instantiate(enemy, new Vector3(xPosition, 0.8f, zPosition), Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                enemyCount += 1;
            }
        }
    }
}
