using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class turn : MonoBehaviour
{

    public GameObject target;
    public GameObject targetrotate;
    private Vector3 initrotate;
    private Vector3 initrotate2;
    PMovement plrm;
    // Start is called before the first frame update
    void Start()
    {
        initrotate = target.transform.eulerAngles;
        initrotate2 = targetrotate.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject plr = GameObject.FindGameObjectsWithTag("Player")[0];
        if (Input.GetAxis("Horizontal") != 0)
        {
            target.transform.Rotate(0f, 0f, (Input.GetAxis("Horizontal")));
            targetrotate.transform.Rotate(0f, 0f, (Input.GetAxis("Horizontal")));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            plr.GetComponent<PMovement>().enabled = true;
            plr.GetComponent<Rigidbody>().isKinematic = false;
            this.enabled = false;
        }
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
        target.transform.eulerAngles = initrotate;
        targetrotate.transform.eulerAngles = initrotate2;
    }
}
