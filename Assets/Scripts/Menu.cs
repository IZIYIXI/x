using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class Menu : MonoBehaviour
{
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject buttonsChoose;
    public GameObject intro;

    private string nickname;
    private string playerDataPath;
    private string playerDataFileName;

    void Start()
    {
        playerDataPath = Application.dataPath + "/Results/";
        playerDataFileName = "results.kgtp";
    }

    public void BackInMenu()
    {
        buttonsMenu.SetActive(true);
        buttonsExit.SetActive(false);
        buttonsChoose.SetActive(false);
        intro.SetActive(false);
    }

    public void ShowExitButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(true);
        buttonsChoose.SetActive(false);
        intro.SetActive(false);
    }

    public void ChooseName()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(false);
        buttonsChoose.SetActive(true);
        intro.SetActive(false);
    }

    public void ShowIntro()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(false);
        buttonsChoose.SetActive(false);
        intro.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadGameScene()
    {
        Application.LoadLevel("SampleScene");
    }

    public void NicknameChosen()
    {
        //Debug.Log(this.name);
        nickname = GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponentInChildren<Text>().text;
        Debug.Log(nickname);

        try
        {
            if (!File.Exists(playerDataPath))
            {
                Debug.Log("!File.Exists");
                Directory.CreateDirectory(playerDataPath);
                File.Create(playerDataPath + playerDataFileName);
                using (StreamWriter sw = new StreamWriter(playerDataPath + playerDataFileName, false, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                Debug.Log("else");
                using (StreamWriter sw = new StreamWriter(playerDataPath + playerDataFileName, true, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.GetType().ToString());
            Debug.Log(e.Message);
        }

        ShowIntro();
    }
}
