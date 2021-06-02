using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Menu : MonoBehaviour
{
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject buttonsChoose;
    public GameObject pannel;

    public GameObject Zenaza;
    public GameObject Qiana;
    public GameObject Disoni;
    public GameObject Powan;
    public GameObject Qiaoaa;
    public GameObject Nubina;
    public GameObject Colma;
    public GameObject Ignar;
    public GameObject Darrill;
    public GameObject Jordell;

    private string nickname;

    private string playerDataPath = Application.streamingAssetsPath + "/Results/" + "result" + ".db";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowExitButtons()
    {
        buttonsMenu.SetActive (false);
        buttonsExit.SetActive (true);
        buttonsChoose.SetActive(false);
        pannel.SetActive(true);
    }

    public void BackInMenu()
    {
        buttonsMenu.SetActive(true);
        buttonsExit.SetActive(false);
        buttonsChoose.SetActive(false);
        pannel.SetActive(true);
    }

    public void ChooseName()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(false);
        buttonsChoose.SetActive(true);
        pannel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NewGameLoadSceneSimpleSxene()
    {
        Application.LoadLevel("SampleScene");
    }

    public void NewGameZenaza()
    {
        nickname = Zenaza.GetComponent<Text>().text;
        try
        {
            if (!File.Exists(playerDataPath))
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, false, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, true, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        Application.LoadLevel("SampleScene");
    }

    public void NewGameQiana()
    {
        nickname = Qiana.GetComponent<Text>().text;
        try
        {
            if (!File.Exists(playerDataPath))
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, false, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, true, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        Application.LoadLevel("SampleScene");
    }

    public void NewGameDisoni()
    {
        nickname = Disoni.GetComponent<Text>().text;
        try
        {
            if (!File.Exists(playerDataPath))
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, false, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, true, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        Application.LoadLevel("SampleScene");
    }

    public void NewGamePowan()
    {
        nickname = Powan.GetComponent<Text>().text;
        try
        {
            if (!File.Exists(playerDataPath))
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, false, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, true, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        Application.LoadLevel("SampleScene");
    }

    public void NewGameQiaoaa()
    {
        nickname = Qiaoaa.GetComponent<Text>().text;
        try
        {
            if (!File.Exists(playerDataPath))
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, false, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, true, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        Application.LoadLevel("SampleScene");
    }

    public void NewGameNubina()
    {
        nickname = Nubina.GetComponent<Text>().text;
        try
        {
            if (!File.Exists(playerDataPath))
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, false, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, true, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        Application.LoadLevel("SampleScene");
    }

    public void NewGameColma()
    {
        nickname = Colma.GetComponent<Text>().text;
        try
        {
            if (!File.Exists(playerDataPath))
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, false, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, true, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        Application.LoadLevel("SampleScene");
    }

    public void NewGameIgnar()
    {
        nickname = Ignar.GetComponent<Text>().text;
        try
        {
            if (!File.Exists(playerDataPath))
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, false, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, true, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        Application.LoadLevel("SampleScene");
    }

    public void NewGameDarrill()
    {
        nickname = Darrill.GetComponent<Text>().text;
        try
        {
            if (!File.Exists(playerDataPath))
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, false, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, true, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        Application.LoadLevel("SampleScene");
    }

    public void NewGameJordell()
    {
        nickname = Jordell.GetComponent<Text>().text;
        try
        {
            if (!File.Exists(playerDataPath))
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, false, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(playerDataPath, true, System.Text.Encoding.Default))
                {
                    sw.Write(nickname + "&");
                    sw.Flush();
                    sw.Close();
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

        Application.LoadLevel("SampleScene");
    }
}
