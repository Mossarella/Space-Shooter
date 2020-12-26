using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyBullet;
    public float fireRate;
    public float shotCD;
    public AudioClip enemyShootSound;
    [Range(0,1)] public float soundVolume;
    //public SoundsManager soundsManager;
    // Start is called before the first frame update
    void Start()
    {
        //soundsManager = FindObjectOfType<SoundsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shotCD >= fireRate)
        {

            
            
                Instantiate(enemyBullet, firePoint.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(enemyShootSound,Camera.main.transform.position,soundVolume);
            //soundsManager.PlaySound(5);
            shotCD = 0;
            
        }
        else if (shotCD < fireRate)
        {
            shotCD += Time.deltaTime;

        }
    }
}
