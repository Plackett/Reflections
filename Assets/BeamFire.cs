using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamFire : MonoBehaviour
{
    public Material material;
    Beam beam;

    // Update is called once per frame
    void Update()
    {
        Destroy(GameObject.Find("Light Beam"));
        beam = new Beam(gameObject.transform.position, -gameObject.transform.right, material);
    }
}
