using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public float health;
    public bool isAlive=true;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
       
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
      
        
            if (health <= 0)
            {

               
                Die();
                isAlive = false;
            }
          
        
    }
    public void TakeDamage(float enemyDamage)
    {
        health -= enemyDamage;
        healthBar.SetHealth(health);
       


    }
    public void Die()
    {
      

        Destroy(this.gameObject);

        
    }
}
