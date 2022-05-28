using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class script : MonoBehaviour
{
    [SerializeField] private TMP_InputField cheatfield;
    [SerializeField] private RectTransform L5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btnchecker()
    {
        string teststring = cheatfield.text.ToLower();
        if(teststring == "secret")
        {
            LeanTween.moveX(L5, 523f, 2f);
        }
    }
}
