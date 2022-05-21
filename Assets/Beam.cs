using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    Vector3 pos, dir;
    GameObject beampointer;
    LineRenderer beam;
    PMovement plr;
    List<Vector3> beampoints = new List<Vector3>();
    public Material gold;

    public Beam(Vector3 pos, Vector3 dir, Material material)
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

        CastRay(pos, dir, beam);
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer beam)
    {
        beampoints.Add(pos);
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit, 30, 1))
        {
            hitCheck(hit, dir, beam);
        } else
        {
            beampoints.Add(ray.GetPoint(30));
            UpdateBeam();
        }
    }

    void UpdateBeam()
    {
        int count = 0;
        beam.positionCount = beampoints.Count;

        for(var a = 0; a < beampoints.Count; a++)
        {
            beam.SetPosition(count, beampoints[a]);
            count++;
        }
    }

    void hitCheck(RaycastHit hinfo, Vector3 direction, LineRenderer beam)
    {
        if(hinfo.collider.gameObject.tag == "M")
        {
            Vector3 pos = hinfo.point;
            Vector3 dir = Vector3.Reflect(direction, hinfo.normal);

            CastRay(pos, dir, beam);
        } else if(hinfo.collider.gameObject.tag == "Goal") 
        {
            beampoints.Add(hinfo.point);
            hinfo.collider.gameObject.GetComponent<Renderer>().material = gold;
            UpdateBeam();
        } else if(hinfo.collider.gameObject.tag == "Player")
        {
            GameObject.Find("plr").GetComponent<PMovement>().Death();
            UpdateBeam();
        }
        else
        {
            beampoints.Add(hinfo.point);
            UpdateBeam();
        }
    }
}
