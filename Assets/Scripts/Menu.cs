using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;
using UnityEngine.SceneManagement;

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
        playerDataPath = Application.persistentDataPath + "/Results/";
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
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void NicknameChosen()
    {
        nickname = GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponentInChildren<Text>().text;

        if (!File.Exists(Path.Combine(playerDataPath, playerDataFileName)))
        {
            Directory.CreateDirectory(playerDataPath);
            FileStream fs = File.Create(Path.Combine(playerDataPath, playerDataFileName));
            fs.Close();
        }

        //try
        //{
            using (StreamWriter sw = new StreamWriter(Path.Combine(playerDataPath, playerDataFileName), true, System.Text.Encoding.Default))
            {
                sw.Write("\r\n" + nickname + "&");
                sw.Flush();
                sw.Close();
            }
        //}
        //catch (Exception e)
        //{
        //    Debug.Log(e.GetType().ToString());
        //    Debug.Log(e.Message);
        //}

        ShowIntro();
    }
}
