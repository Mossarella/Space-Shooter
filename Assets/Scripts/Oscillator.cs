using UnityEngine;
using System.Collections;

public class Oscillator : MonoBehaviour
{

    public float speedMult = 1.0f;
    public float rangeMult = 1.0f;
    // Use this for initialization
    
    
    float basex = 0.0f;
    
    // Update is called once per frame
    void Start()
    {
        basex = transform.position.x;
    }
    void Update()
    {
        Vector3 position = transform.position;
        float interval = Mathf.Sin(Time.time * (speedMult / rangeMult)) * rangeMult;
        

       

        position.x = basex + interval;

        transform.position = position;
        
    }
}     