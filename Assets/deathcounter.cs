using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class deathcounter : MonoBehaviour
{
    public int dcount;
    public TextMeshProUGUI dcounter;

    public void Death()
    {
        dcount++;
        dcounter.SetText("Deaths: " + dcount);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < dcount; i++)
        {
            string name = ("remove" + i.ToString());
            if (GameObject.Find(name))
            {
                Destroy(GameObject.Find(name));
            }
        }
    }
}
