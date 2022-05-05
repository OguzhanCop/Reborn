 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelahtBar : MonoBehaviour
{
    public int maxHealth;
    public HPbars healthBar;

    private int curHealth;
    void Start()
    {
        curHealth = maxHealth;
    }

   public void TakeDamage(int damage)
    {
        curHealth -= damage;
        healthBar.UpdateHealth((float)curHealth / (float)maxHealth);
    }
}
