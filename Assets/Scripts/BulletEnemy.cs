using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{

    [SerializeField] public int speed;
    public int enemyDamage;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerInfo playerInfo = hitInfo.GetComponent<PlayerInfo>();
        if (playerInfo != null)
        {
            playerInfo.TakeDamage(enemyDamage);
            Destroy(this.gameObject);
        }
        
        

    }
}
