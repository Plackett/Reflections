using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Play : MonoBehaviour
{
    public Canvas one;
    public Canvas two;
    public string LevelProg;
    [SerializeField] private soundeffects sf;
    [SerializeField] private AudioClip select;
    public List<Button> btnList = new List<Button>();
    
    public void Quit()
    {
        Application.Quit();
    }

    public void UpdateProgButtons()
    {
        int loc = 0;
        foreach(char current in LevelProg)
        {
            if ((current + string.Empty) == "0")
            {
                btnList[loc].interactable = false;
                btnList[loc].gameObject.GetComponent<Image>().color = Color.gray;
            }
            if ((current + string.Empty) == "1")
            {
                btnList[loc].interactable = true;
                btnList[loc].gameObject.GetComponent<Image>().color = Color.white;
            }
            if ((current + string.Empty) == "2")
            {
                btnList[loc].interactable = true;
                btnList[loc].gameObject.GetComponent<Image>().color = Color.green;
            }
            loc++;
        }
    }

    public void Press()
    {
        sf.player.pitch = 2;
        sf.PlayAudio(select);
        LoadGame();
        // checks for empty save data
        if(LevelProg == "000000")
        {
            SceneManager.LoadScene("SampleScene");
        } else
        {
            one.enabled = false;
            UpdateProgButtons();
            two.enabled = true;
        }
    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            LevelProg = PlayerPrefs.GetString("Level");
        }
        else
        {
            LevelProg = "000000";
        }
    }

    void SaveGame(string data)
    {
        PlayerPrefs.SetString("Level", data);
        PlayerPrefs.Save();
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        LevelProg = "000000";
        SaveGame(LevelProg);
        UpdateProgButtons();
        Pressback();
    }

    public void Pressback()
    {
        sf.player.pitch = 1;
        sf.PlayAudio(select);
        two.enabled = false;
        one.enabled = true;
    }

    public void LevelSelect()
    {
        sf.player.pitch = 2;
        sf.PlayAudio(select);
        if (EventSystem.current.currentSelectedGameObject.name != btnList[0].name)
        {
            SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name);
        } else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
