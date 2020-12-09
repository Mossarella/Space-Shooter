using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int[] foo = { 3, 6, 42, 33, 1, 10 };
    void Start()
    {

        Debug.Log(Mathf.Max(foo));
    }
}
