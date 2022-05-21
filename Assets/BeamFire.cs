using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable
public class BeamFire : MonoBehaviour
{
    public Material material;
    public GameObject host;
  //  public Prefab lbeam;
    Beam beam;

    // Update is called once per frame
    void Start()
    {
        GameObject hostt = Instantiate(host);
        beam = hostt.AddComponent<Beam>();
        beam.pos = gameObject.transform.position;
        beam.dir = -gameObject.transform.right;
        beam.mat = material;
        beam.MakeBeam(gameObject.transform.position, -gameObject.transform.right, material);
    }
}
