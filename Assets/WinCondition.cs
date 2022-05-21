using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public bool activated;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    public void Activate()
    {
        activated = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
