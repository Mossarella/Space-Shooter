using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int health;
    public AudioSource audioSource;
    public GameObject boomVfx;
    public AudioClip enemyDeadSound;
    [Range(0, 1)] public float soundVolume;

    [SerializeField] int scorePerOne=1000;
    

    //public SoundsManager soundsManager;
    // Start is called before the first frame update
    void Start()
    {
        
        //soundsManager = FindObjectOfType<SoundsManager>();
        health = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        print("damaged");

        

    }
    
    public void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(boomVfx, transform.position, Quaternion.identity);
        Destroy(explosion, 1f);
        AudioSource.PlayClipAtPoint(enemyDeadSound, Camera.main.transform.position, soundVolume);

        ScoreCount scoreCount = FindObjectOfType<ScoreCount>();
        scoreCount.AddToScore(scorePerOne);
        

        //AudioSource.PlayClipAtPoint
        //audioSource.play
        //audioSource.PlayOneShot

    }
    
}
