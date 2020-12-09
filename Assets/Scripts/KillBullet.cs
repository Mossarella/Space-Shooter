using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBullet : MonoBehaviour
{
    [HideInInspector] public Vector2 boundXMin;
    [HideInInspector] public Vector2 boundXMax;
    [HideInInspector] public Vector2 boundYMin;
    [HideInInspector] public Vector2 boundYMax;

    [HideInInspector] public Vector2 point1, point2, point3, point4;

    public PolygonCollider2D polygonCollider2D;

    

    // Start is called before the first frame update
    void Start()
    {
        
        polygonCollider2D = GetComponent<PolygonCollider2D>();

        Camera gameCamera= Camera.main;

        boundXMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        boundXMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0));
        boundYMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0));
        boundYMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));



        point1 = boundXMin;
        point2 = boundXMax;
        point4 = boundYMin;
        point3 = boundYMax;
        
        polygonCollider2D.points = new[] { point1, point2, point3, point4 };
        //AdaptCollider();

        //polygonCollider2D.enabled = true;
    }
    

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log(polygonCollider2D.points[0]);
        Debug.Log(polygonCollider2D.points[1]);
        Debug.Log(polygonCollider2D.points[2]);
        Debug.Log(polygonCollider2D.points[3]);*/
        //AdaptCollider();

    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
