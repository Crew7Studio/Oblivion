using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{

    public int enemyHealth;
    int maxHealth;
    public int pointsToGive;

    void Start()
    {
        maxHealth = enemyHealth;   
    }

    void Update()
    {
        if (enemyHealth <= 0) {
            ScoreManager.AddPoints(pointsToGive);
            Destroy(gameObject);
            
        }
    }

    public void GiveDamage(int damageToGive) {
        enemyHealth -= damageToGive;
    }

    public void ResetEnemyHealth() {
        enemyHealth = maxHealth;
    }

}
