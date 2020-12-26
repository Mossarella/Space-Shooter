using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public int myDamage;



    void Start()
    {
        
    }
    private void Update()
    {

        transform.position = new Vector2( transform.position.x,transform.position.y + (speed * Time.deltaTime));
        //GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(myDamage);
            Debug.Log("we got him");
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
            
        }


    }
    // Update is called once per frame

}
