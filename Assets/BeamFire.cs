using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable
public class BeamFire : MonoBehaviour
{
    public Material material;
    public GameObject host;
    public bool updownleftright;
    public float fact;
    [SerializeField] private GameObject exit;
    [SerializeField] private List<GameObject> btns;
    [SerializeField] private soundeffects sf;
    [SerializeField] private AudioClip winsound;
    [SerializeField] private Image ins2;
    [SerializeField] private Image ins3;
    //  public Prefab lbeam;
    Beam beam;

    // Update is called once per frame
    void Start()
    {
        GameObject hostt = Instantiate(host);
        beam = hostt.AddComponent<Beam>();
        beam.mat = material;
        beam.exit = exit;
        beam.btns = btns;
        beam.sf = sf;
        beam.winsound = winsound;
        beam.ins2 = ins2;
        beam.ins3 = ins3;
        hostt.tag = "light";
        if (updownleftright == false)
        {
            beam.MakeBeam(gameObject.transform.position, (gameObject.transform.right * fact), material);
        } else
        {
            beam.MakeBeam(gameObject.transform.position, (gameObject.transform.up * fact), material);
        }
    }
}
