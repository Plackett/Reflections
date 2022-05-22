using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PMovement : MonoBehaviour
{
    public GameObject plr;
    public turn turn;
    public GameObject spawn;
    public bool atlas;
    public deathcounter d;
    public GameObject E;
    public bool elightloop;
    Scene scene;
    int bid;
    string LevelProg;
    public Sprite on;
    public Sprite off;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -4F, 0);
        plr.GetComponent<Rigidbody>().mass = 5;
        plr.GetComponent<Rigidbody>().drag = 0;
        plr.GetComponent<Rigidbody>().useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(elightloop == false)
        {
            StartCoroutine(LightPattern());
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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
        if(plr.transform.position.z != 0)
        {
            plr.transform.position = new Vector3(plr.transform.position.x, plr.transform.position.y, 0);
        }
        if(plr.transform.rotation.eulerAngles.x != 0 || plr.transform.rotation.eulerAngles.y != 0 || plr.transform.rotation.eulerAngles.z != 0)
        {
            transform.rotation = Quaternion.identity;
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
            scene = SceneManager.GetActiveScene();
            bid = scene.buildIndex;
            if (PlayerPrefs.HasKey("Level"))
            {
                LevelProg = PlayerPrefs.GetString("Level");
                LevelProg = LevelProg.Remove((bid - 1), 1);
                LevelProg = LevelProg.Insert((bid-1), "2");
                if ((LevelProg[bid] + string.Empty) == "0" && bid != 6)
                {
                    LevelProg = LevelProg.Remove(bid, 1);
                    LevelProg = LevelProg.Insert(bid, "1");
                }
            }
            else
            {
                LevelProg = "000000";
                LevelProg = LevelProg.Remove((bid - 1), 2);
                LevelProg = LevelProg.Insert((bid - 1), "21");
            }
            PlayerPrefs.SetString("Level", LevelProg);
            PlayerPrefs.Save();
            if(scene.name == "SampleScene")
            {
                SceneManager.LoadScene("2");
            } else
            {
                SceneManager.LoadScene(bid+1);
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "atlas")
        {
            atlas = true;
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                LeanTween.moveY(E.GetComponent<RectTransform>(), -224f, 0.5f);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "atlas")
        {
            atlas = false;
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                LeanTween.moveY(E.GetComponent<RectTransform>(), -625f, 0.5f);
            }
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
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            LeanTween.moveY(E.GetComponent<RectTransform>(), -625f, 0.5f);
        }
        Destroy(plr);
    }

    IEnumerator LightPattern()
    {
        elightloop = true;
        Image img = E.GetComponent<Image>();
        img.sprite = on;
        yield return new WaitForSeconds(0.2f);
        img.sprite = off;
        yield return new WaitForSeconds(0.1f);
        img.sprite = on;
        yield return new WaitForSeconds(0.2f);
        img.sprite = off;
        yield return new WaitForSeconds(0.1f);
        img.sprite = on;
        yield return new WaitForSeconds(0.2f);
        img.sprite = off;
        yield return new WaitForSeconds(0.1f);
        img.sprite = on;
        yield return new WaitForSeconds(1);
        img.sprite = off;
        yield return new WaitForSeconds(0.2f);
        img.sprite = on;
        yield return new WaitForSeconds(1);
        img.sprite = off;
        yield return new WaitForSeconds(0.2f);
        img.sprite = on;
        yield return new WaitForSeconds(1);
        img.sprite = off;
        yield return new WaitForSeconds(0.2f);
        img.sprite = on;
        yield return new WaitForSeconds(0.2f);
        img.sprite = off;
        yield return new WaitForSeconds(0.1f);
        img.sprite = on;
        yield return new WaitForSeconds(0.2f);
        img.sprite = off;
        yield return new WaitForSeconds(0.1f);
        img.sprite = on;
        yield return new WaitForSeconds(0.2f);
        img.sprite = off;
        yield return new WaitForSeconds(3);
        elightloop = false;
    }
}
