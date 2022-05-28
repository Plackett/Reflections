using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PMovement : MonoBehaviour
{
    public GameObject plr;
    public turn turn;
    public turn turn2;
    public GameObject spawn;
    public bool atlas;
    public bool atlas2;
    public deathcounter d;
    public GameObject E;
    public bool elightloop;
    Scene scene;
    int bid;
    string LevelProg;
    public Sprite on;
    public Sprite off;
    [SerializeField] private AudioClip deathsound;
    [SerializeField] private soundeffects sf;
    [SerializeField] private Image ins1;
    [SerializeField] private Image ins2;
    [SerializeField] private Sprite idle;
    [SerializeField] private Sprite move;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -1F, 0);
        plr.GetComponent<Rigidbody>().mass = 5;
        plr.GetComponent<Rigidbody>().drag = 0;
        plr.GetComponent<Rigidbody>().useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(elightloop == false && SceneManager.GetActiveScene().buildIndex == 1)
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
        if (atlas == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                turn.enabled = true;
                plr.GetComponent<Rigidbody>().isKinematic = true;
                this.enabled = false;
            }
        }
        if (atlas2 == true && turn2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                turn2.enabled = true;
                plr.GetComponent<Rigidbody>().isKinematic = true;
                this.enabled = false;
            }
        }
    }

    public void FixedUpdate()
    {
        plr = this.gameObject;
        if (Input.GetAxis("Horizontal") > 0)
        {
            plr.transform.position = new Vector3(plr.transform.position.x + 0.06f, plr.transform.position.y, 0);
            plr.GetComponent<SpriteRenderer>().sprite = move;
            plr.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            plr.transform.position = new Vector3(plr.transform.position.x - 0.05f, plr.transform.position.y, 0);
            plr.GetComponent<SpriteRenderer>().sprite = move;
            plr.GetComponent<SpriteRenderer>().flipX = true;
        } else if (Input.GetAxis("Horizontal") == 0)
        {
            plr.GetComponent<SpriteRenderer>().flipX = false;
            plr.GetComponent<SpriteRenderer>().sprite = idle;
        }
        if (plr.transform.position.z != 0)
        {
            plr.transform.position = new Vector3(plr.transform.position.x, plr.transform.position.y, 0);
        }
        if (plr.transform.rotation.eulerAngles.x != 0 || plr.transform.rotation.eulerAngles.y != 0 || plr.transform.rotation.eulerAngles.z != 0)
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
*/      if(collision.gameObject.tag == "left")
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 15, 0), ForceMode.Impulse);
        }
        if(collision.gameObject.tag == "exit")
        {
            scene = SceneManager.GetActiveScene();
            bid = scene.buildIndex;
            if (PlayerPrefs.HasKey("Level"))
            {
                if(bid != 6 && bid != 4)
                {
                    LevelProg = PlayerPrefs.GetString("Level");
                    LevelProg = LevelProg.Remove((bid - 1), 1);
                    LevelProg = LevelProg.Insert((bid - 1), "2");
                    if ((LevelProg[bid] + string.Empty) == "0")
                    {
                        LevelProg = LevelProg.Remove(bid, 1);
                        LevelProg = LevelProg.Insert(bid, "1");
                    }
                } else
                {
                    if(bid == 4)
                    {
                        LevelProg = PlayerPrefs.GetString("Level");
                        if (LevelProg[4] + string.Empty == "0" && LevelProg[4] + string.Empty == "0")
                        {
                            LevelProg = LevelProg.Remove(3, 3);
                            LevelProg = LevelProg.Insert(3, "211");
                        } else
                        {
                            LevelProg = LevelProg.Remove(3, 1);
                            LevelProg = LevelProg.Insert(3, "2");
                        }
                    } 
                    if(bid == 6)
                    {
                        if(LevelProg[4] + string.Empty == "0")
                        {
                            LevelProg = LevelProg.Remove(4, 2);
                            LevelProg.Insert(4, "21");
                        } else
                        {
                            LevelProg = LevelProg.Remove(4, 1);
                            LevelProg.Insert(4, "2");
                        }
                    }
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
            } else if(scene.buildIndex == 4)
            {
                SceneManager.LoadScene(6);
            } else if(scene.buildIndex == 6)
            {
                SceneManager.LoadScene(5);
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
                LeanTween.moveY(E.GetComponent<RectTransform>(), -224f, 0.7f);
                if(ins1.enabled == true)
                {
                    ins1.enabled = false;
                    ins2.enabled = true;
                }
            }
        }
        if (collision.gameObject.tag == "atlas2")
        {
            atlas2 = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "atlas")
        {
            atlas = false;
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                LeanTween.moveY(E.GetComponent<RectTransform>(), -625f, 0.7f);
            }
        }
        if(collision.gameObject.tag == "atlas2")
        {
            atlas2 = false;
        }
    }

    public void Death()
    {
        sf.PlayAudio(deathsound);
        d.Death();
        atlas = false;
        atlas2 = false;
        plr.name = "oldplr";
        plr.GetComponent<Rigidbody>().isKinematic = false;
        GameObject newplr = Instantiate(plr, spawn.transform.position, Quaternion.identity);
        newplr.name = "plr";
        turn.reset();
        if(turn2)
        {
            turn2.reset();
        }
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
