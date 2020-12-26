using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public float health;
    public bool isAlive=true;
    public HealthBar healthBar;
    public AudioClip playerDeadSound;
    [Range(0, 1)] public float soundVolume;
    public GameObject boomVfx;

    // Start is called before the first frame update
    void Start()
    {
       
        health = maxHealth;
        
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        
            if (health <= 0&&isAlive)
            {


            Die();
                isAlive = false;
            }
        
            if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Die();
            
        }
        
    }
    public void TakeDamage(int enemyDamage)
    {
        health -= enemyDamage;
        if(healthBar!=null)
        {
        healthBar.SetHealth(health);
        }
        else
        {
            return;
        }
       


    }
    public void Die()
    {
        AudioSource.PlayClipAtPoint(playerDeadSound, Camera.main.transform.position, soundVolume);
        GameObject explosion = Instantiate(boomVfx, transform.position, Quaternion.identity);
        Destroy(explosion, 1f);
        Controller controller = FindObjectOfType<Controller>();
        controller.spriteRenderer.enabled = false;

        

        //Destroy(this.gameObject);
        StartCoroutine(GameOverScene());
        
    }
    public IEnumerator GameOverScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
