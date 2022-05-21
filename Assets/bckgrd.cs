using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bckgrd : MonoBehaviour
{
    public GameObject bg;
    // Start is called before the first frame update
    void Start()
    {
        mkbgrd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void mkbgrd()
    {
        for(var i = 0; i < 18; i++)
        {
            for(var v = 0; v < 8; v++)
            {
                Instantiate(bg, new Vector3((-8.889f + (i*1.27f*2)), (4.999f + (v*-1.279f*2)), 0), Quaternion.identity);
            }
        }
    }
}