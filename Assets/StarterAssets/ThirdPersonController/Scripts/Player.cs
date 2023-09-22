using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{

   

    [SerializeField] int maxHealth = 100;

    public int currentHealth;

    [SerializeField] bool dead;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Awake()
    {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        dead = true;

        KillPlayer();

        
    }

    private void KillPlayer()
    {
        if (dead == true)
            Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        print(currentHealth);
        healthBar.SetHealth(currentHealth);
    }

     

   
}
