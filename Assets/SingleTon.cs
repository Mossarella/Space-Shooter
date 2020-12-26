using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        SetUpSingleton();
    }
    void SetUpSingleton()
    {
        if(FindObjectsOfType(GetType()).Length>1)
        {
            Destroy(gameObject);
            Debug.Log("NO");
        }
        else
        {
            DontDestroyOnLoad(gameObject);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
