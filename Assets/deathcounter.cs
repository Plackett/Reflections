using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class deathcounter : MonoBehaviour
{
    public int dcount;
    public TextMeshProUGUI dcounter;
    [SerializeField] private List<GameObject> remove;
    [SerializeField] private List<GameObject> add;

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
            if(i <= (remove.Count - 1))
            {
                if (remove[i])
                {
                    remove[i].GetComponent<doormove>().Move();
                }
            }
        }
        for (int i = 0; i < dcount; i++)
        {
            if(i <= (add.Count - 1))
            {
                if (add[i])
                {
                    foreach(Transform child in add[i].transform)
                        {
                        if(child.gameObject.name == "collide")
                        {
                            child.gameObject.GetComponent<Collider>().enabled = true;
                        } else if(child.gameObject.name == "unfill")
                        {
                            child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        } else if (child.gameObject.name == "fill")
                        {
                            child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                        }
                    }
                }
            }
        }
        if(dcount >= 1 && SceneManager.GetActiveScene().buildIndex == 5)
        {
            dcounter.color = Color.red;
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("light"))
            {
                Destroy(obj);
            }
        }
    }
}
