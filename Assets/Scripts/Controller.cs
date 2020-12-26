using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, YMin, YMax;
}
public class Controller : MonoBehaviour
{
    private float deltaX;
    private float deltaY;
    //private Vector2 movement;

    [SerializeField] float moveSpeed;
    [SerializeField] float tilt;

    public Rigidbody2D rb;
    public Boundary boundary;
    public PlayerInfo playerInfo;

    public Transform firePoint;
    public GameObject playerBullet;
    public float fireRate;
    public float shotCD;

    public SoundsManager soundsManager;
    [HideInInspector]public SpriteRenderer spriteRenderer;
    [HideInInspector]public Sprite playerSprite;
    [HideInInspector] public float spriteBoundLeft, spriteBoundRight, spriteBoundUp, spriteBoundDown;
    // Start is called before the first frame update
    void Start()
    {
        shotCD = fireRate;
        rb = GetComponent<Rigidbody2D>();
        playerInfo = GetComponent<PlayerInfo>();
        Camera gameCamera = Camera.main;
        soundsManager = FindObjectOfType<SoundsManager>();

        boundary.xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        boundary.xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        boundary.YMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        boundary.YMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSprite = spriteRenderer.sprite;
        spriteBoundLeft = playerSprite.bounds.min.x;
        spriteBoundRight = playerSprite.bounds.max.x;
        spriteBoundUp = playerSprite.bounds.min.y;
        spriteBoundDown = playerSprite.bounds.max.y;
    }

    // Update is called once per frame
    void Update()
    {
        

        deltaX = CrossPlatformInputManager.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        deltaY = CrossPlatformInputManager.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;


        var newXPos = Mathf.Clamp(transform.position.x + deltaX, boundary.xMin - spriteBoundLeft, boundary.xMax - spriteBoundRight);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, boundary.YMin + spriteBoundDown, boundary.YMax + spriteBoundUp);

        //Debug.Log(deltaX);
        //movement = new Vector2(deltaX, deltaY);
        //rb.velocity = movement * speed;
        transform.position = new Vector2(newXPos, newYPos);

        //transform.position = new Vector2(Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(transform.position.y, boundary.YMin, boundary.YMax));


        transform.rotation = Quaternion.Euler(0, deltaX/Time.deltaTime * -tilt, 0);

        //Debug.Log(deltaX);
        if(playerInfo.isAlive)
        {
        Fire();
            
        }

        
    }

    public void Fire()
    {
        shotCD = Mathf.Clamp(shotCD, 0, fireRate);

        if (shotCD >= fireRate)
        {

            if (CrossPlatformInputManager.GetButton("Fire1"))
            {
                //Instantiate(playerBullet, firePoint.position, Quaternion.identity);

                GameObject bul = PlayerBulletPool.bulletPoolInstances.GetBullet();
                bul.transform.position = firePoint.transform.position;
                bul.transform.rotation = Quaternion.Euler(0, 0, 0);
                bul.SetActive(true);

                shotCD  -=shotCD;

                soundsManager.PlaySound(4);
            }
        }
        else if (shotCD < fireRate)
        {
            shotCD += Time.deltaTime;

        }
    }
}
