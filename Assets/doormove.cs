using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doormove : MonoBehaviour
{
    [SerializeField] private bool updownleftright;
    [SerializeField] private int dist;
    [SerializeField] private GameObject doorparent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move()
    {
        var seq = LeanTween.sequence();
        if (updownleftright == false)
        {
            seq.append(LeanTween.moveY(doorparent, (float)dist, 0.5f));
        }
        else
        {
            seq.append(LeanTween.moveX(doorparent, (float)dist, 0.5f));
        }
        seq.append(() =>
        {
            Destroy(doorparent);
        });
    }
}
