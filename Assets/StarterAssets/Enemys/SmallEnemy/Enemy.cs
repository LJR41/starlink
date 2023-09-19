using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField] float health;


    public void Awake()
    {
        
    }

    public void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        if(health > 0)
        {
            health -= damage;
        if(health<=0)
        {
            EnemyDeath();
        };
        UnityEngine.Debug.Log("Hit");
        }
        
    }
    // Start is called before the first frame update

    void EnemyDeath()
    {
        UnityEngine.Debug.Log("Death");
    }
}
