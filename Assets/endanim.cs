using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endanim : MonoBehaviour
{
    [SerializeField] private List<GameObject> lights;
    [SerializeField] private GameObject door;
    [SerializeField] private bool updownleftright;
    [SerializeField] private int dist;
    private int numnext;

    public void endanimation()
    {
        var seq = LeanTween.sequence();
        if (updownleftright == false)
        {
            seq.append(LeanTween.moveY(door, (float)dist, 1f));
        }
        else
        {
            seq.append(LeanTween.moveX(door, (float)dist, 1f));
        }
        seq.append(() =>
        {
            Destroy(door);
        });
    }

    public void activatelight()
    {
        foreach(GameObject obj in lights)
        {
            if(obj.GetComponent<SpriteRenderer>().enabled == true)
            {
                numnext++;
            }
        }
        if(numnext <= (lights.Count + 1) && lights.Count != 0)
        {
            lights[numnext].GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
