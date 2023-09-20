using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] int maxHealth = 100;

    public int currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       //if(Input.GetKeyDown(KeyCode.Space))
       //{
       //     TakeDamage(10);
       //} 
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        print(currentHealth);
        healthBar.SetHealth(currentHealth);
    }
}
