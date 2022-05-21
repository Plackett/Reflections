using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    public GameObject plr;
    public turn turn;
    public GameObject spawn;
    public bool atlas;
    public deathcounter d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            plr.transform.position = new Vector3(plr.transform.position.x + 0.1f, plr.transform.position.y, 0);
        } 
        else if (Input.GetAxis("Horizontal") < 0)
        {
            plr.transform.position = new Vector3(plr.transform.position.x - 0.1f, plr.transform.position.y, 0);
        }
        if(atlas == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                turn.enabled = true;
                this.enabled = false;
            }
        }
    }

    public void setTurn(turn t)
    {
        turn = t;
    }

    public void SetSpawn(GameObject spawnnew)
    {
        spawn = spawnnew;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided!");
        if(collision.gameObject.tag == "left")
        {
            plr.transform.position = new Vector3(1 + plr.transform.position.x, plr.transform.position.y, 0);
        }
        else if (collision.gameObject.tag == "right")
        {
            plr.transform.position = new Vector3(-1 + plr.transform.position.x, plr.transform.position.y, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "atlas")
        {
            atlas = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "atlas")
        {
            atlas = false;
        }
    }

    public void Death()
    {
        d.Death();
        plr.name = "oldplr";
        GameObject newplr = Instantiate(plr, spawn.transform.position, Quaternion.identity);
        newplr.name = "plr";
        turn.reset();
        Destroy(plr);
    }
}
