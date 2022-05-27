using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#pragma warning disable
public class Beam : MonoBehaviour
{
    public Vector3 pos, dir;
    GameObject beampointer;
    LineRenderer beam;
    PMovement plr;
    public Material mat;
    List<Vector3> beampoints = new List<Vector3>();
    public Material gold;
    public GameObject exit;
    public List<GameObject> btns;
    private bool used;
    [SerializeField] public soundeffects sf;
    [SerializeField] public AudioClip winsound;
    [SerializeField] public Image ins2;
    [SerializeField] public Image ins3;

    public void MakeBeam(Vector3 pos, Vector3 dir, Material material)
    {
        this.beam = new LineRenderer();
        this.beampointer = new GameObject();
        this.beampointer.name = "Light Beam";
        this.pos = pos;
        this.dir = dir;

        this.beam = this.beampointer.AddComponent(typeof(LineRenderer)) as LineRenderer;
        this.beam.startWidth = 0.1f;
        this.beam.endWidth = 0.1f;
        this.beam.material = material;
        this.beam.startColor = Color.white;
        this.beam.endColor = Color.white;
        this.beampointer.tag = "light";

        CastRay(pos, dir, beam);
    }

    void Update()
    {
        if(used == false)
        {
            this.beam.positionCount = 0;
            beampoints.Clear();
            CastRay(pos, dir, beam);
        }
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer beam)
    {
        beampoints.Add(pos);
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 30, 1))
        {
            hitCheck(hit, dir, beam);
        }
        else
        {
            beampoints.Add(ray.GetPoint(30));
            UpdateBeam();
        }
    }

    void UpdateBeam()
    {
        int count = 0;
        beam.positionCount = beampoints.Count;

        for (var a = 0; a < beampoints.Count; a++)
        {
            beam.SetPosition(count, beampoints[a]);
            count++;
        }
    }

    void hitCheck(RaycastHit hinfo, Vector3 direction, LineRenderer beam)
    {
        if (hinfo.collider.gameObject.tag == "M")
        {
            Vector3 pos = hinfo.point;
            Vector3 dir = Vector3.Reflect(direction, hinfo.normal);

            CastRay(pos, dir, beam);
        }
        else if (hinfo.collider.gameObject.tag == "Goal")
        {
            sf.PlayAudio(winsound);
            beampoints.Add(hinfo.point);
            hinfo.collider.gameObject.GetComponent<Renderer>().material = gold;
            hinfo.collider.gameObject.GetComponent<WinCondition>().Activate();
            exit.GetComponent<endanim>().activatelight();
            beam.material = gold;
            hinfo.collider.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            used = true;
            UpdateBeam();
            checkWin();
        }
        else if (hinfo.collider.gameObject.tag == "Player")
        {
            if(hinfo.collider.gameObject.GetComponent<PMovement>().enabled == true)
            {
                hinfo.collider.gameObject.GetComponent<PMovement>().Death();
                UpdateBeam();
            } else
            {
                beampoints.Add(hinfo.point);
                UpdateBeam();
            }
        }
        else
        {
            beampoints.Add(hinfo.point);
            UpdateBeam();
        }
    }

    public void checkWin()
    {
        int btndowns = 0;
        int total = 0;
        foreach (GameObject btn in btns)
        {
            if (btn.GetComponent<WinCondition>().activated == true)
            {
                btndowns++;
            }
            total++;
        }
        if (btndowns == total)
        {
            exit.GetComponent<endanim>().endanimation();
            if(SceneManager.GetActiveScene().buildIndex == 1 && ins2.enabled == true)
            {
                ins2.enabled = false;
                ins3.enabled = true;
            }
        }
    }
}
