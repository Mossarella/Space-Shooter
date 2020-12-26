using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenContact : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
            PlayerInfo playerInfo = other.GetComponent<PlayerInfo>();
            if (playerInfo != null)
            {
                playerInfo.TakeDamage(damage);
                Destroy(this.gameObject);
            }
        
    }
}
