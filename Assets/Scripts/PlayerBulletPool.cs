using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour
{
    public static PlayerBulletPool bulletPoolInstances;
    // Start is called before the first frame update

    [SerializeField] public GameObject pooledBullet;
    public bool notEnoughBulletInPool = true;

    public List<GameObject> bullets;

   

    private void Awake()
    {
        bulletPoolInstances = this;
    }
    void Start()
    {
       
        bullets = new List<GameObject>();
    }
    public GameObject GetBullet()
    {
        if(bullets.Count>0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if(!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }
        if (notEnoughBulletInPool)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
