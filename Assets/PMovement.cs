using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PMovement : MonoBehaviour
{
    public GameObject plr;
    public turn turn;
    public GameObject spawn;
    public bool atlas;
    public deathcounter d;
    string LevelProg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        plr = GameObject.Find("plr");
        if(Input.GetAxis("Horizontal") > 0)
        {
            plr.transform.position = new Vector3(plr.transform.position.x + 0.03f, plr.transform.position.y, 0);
        } 
        else if (Input.GetAxis("Horizontal") < 0)
        {
            plr.transform.position = new Vector3(plr.transform.position.x - 0.03f, plr.transform.position.y, 0);
        }
        if(atlas == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                turn.enabled = true;
                plr.GetComponent<Rigidbody>().isKinematic = true;
                this.enabled = false;
            }
        }
/*        if(plr.transform.position.z != 0)
        {
            plr.transform.position = new Vector3(plr.transform.position.x, plr.transform.position.y, 0);
        }
        if(plr.transform.rotation.eulerAngles.x != 0 || plr.transform.rotation.eulerAngles.y != 0 || plr.transform.rotation.eulerAngles.z != 0)
        {
            transform.rotation = Quaternion.identity;
        }
        if(plr.transform.position.y != -3.644f)
        {
            plr.transform.position = new Vector3(plr.transform.position.x, -3.644f, 0);
        }
*/  }

    public void setTurn(turn t)
    {
        turn = t;
    }

    public void SetSpawn(GameObject spawnnew)
    {
        spawn = spawnnew;
    }

    private void OnCollisionEnter(Collision collision)
    {
 /*       if(collision.gameObject.tag == "left")
        {
            plr.transform.position = new Vector3(0.2f + plr.transform.position.x, plr.transform.position.y, 0);
        }
        else if (collision.gameObject.tag == "right")
        {
            plr.transform.position = new Vector3(-0.2f + plr.transform.position.x, plr.transform.position.y, 0);} 
*/      if(collision.gameObject.tag == "exit")
        {
            if (PlayerPrefs.HasKey("Level"))
            {
                LevelProg = PlayerPrefs.GetString("Level");
                LevelProg = LevelProg.Remove(0, 1);
                LevelProg = LevelProg.Insert(0, "2");
                if ((LevelProg[1] + string.Empty) == "0")
                {
                    LevelProg = LevelProg.Remove(1, 2);
                    LevelProg = LevelProg.Insert(1, "1");
                }
            }
            else
            {
                LevelProg = "210000";
            }
            PlayerPrefs.SetString("Level", LevelProg);
            PlayerPrefs.Save();
            Debug.Log("Game data saved!");
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "atlas")
        {
            atlas = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "atlas")
        {
            atlas = false;
        }
    }

    public void Death()
    {
        d.Death();
        atlas = false;
        plr.name = "oldplr";
        plr.GetComponent<Rigidbody>().isKinematic = false;
        GameObject newplr = Instantiate(plr, spawn.transform.position, Quaternion.identity);
        newplr.name = "plr";
        turn.reset();
        Destroy(plr);
    }
}
