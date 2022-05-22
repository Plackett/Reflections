using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class turn : MonoBehaviour
{

    public GameObject target;
    PMovement plrm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            target.transform.Rotate(0f, 0f, (Input.GetAxis("Horizontal")));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("plr").GetComponent<PMovement>().enabled = true;
            GameObject.Find("plr").GetComponent<Rigidbody>().isKinematic = false;
            this.enabled = false;
        }
        GameObject plr = GameObject.Find("plr");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void reset()
    {
        transform.rotation = Quaternion.identity;
    }
}
