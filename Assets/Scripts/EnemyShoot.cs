using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemyBullet;
    public float fireRate;
    public float shotCD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shotCD >= fireRate)
        {

            
            
                Instantiate(enemyBullet, firePoint.position, Quaternion.identity);
                shotCD = 0;
            
        }
        else if (shotCD < fireRate)
        {
            shotCD += Time.deltaTime;

        }
    }
}
