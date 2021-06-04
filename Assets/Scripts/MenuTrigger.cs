using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class MenuTrigger : MonoBehaviour
{
    public GameObject exitLever;
    public GameObject menu;
    public GameObject menuText;
    public GameObject playerData;

    private string playerDataPath;
    private string playerDataFileName;

    void Start()
    {
        playerDataPath = Application.persistentDataPath + "/Results/";
        playerDataFileName = "results.kgtp";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trolley")
        {
            string line = "", lastLine = "";
            string pt = playerData.GetComponent<Text>().text;

            if (pt == "turn")
            {
                menuText.GetComponent<Text>().text = "�� ������� ����� ��������� � ������ ���� ������, ����������� �����. �� ������ �� ��� ����?";

                //try
                //{
                    using (StreamReader sr = new StreamReader(Path.Combine(playerDataPath, playerDataFileName), System.Text.Encoding.Default))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            lastLine = line;
                        }
                    }
                //}
                //catch (Exception e)
                //{
                //    Debug.Log(e.GetType().ToString());
                //    Debug.Log(e.Message);
                //}

                if ((lastLine != "") && (lastLine[lastLine.Length - 1] == '&'))
                {
                    //try
                    //{
                        using (StreamWriter sw = new StreamWriter(Path.Combine(playerDataPath, playerDataFileName), true, System.Text.Encoding.Default))
                        {
                            sw.Write("turn");
                            sw.Flush();
                            sw.Close();
                        }
                    //}
                    //catch (Exception e)
                    //{
                    //    Debug.Log(e.GetType().ToString());
                    //    Debug.Log(e.Message);
                    //}
                }
            }
            else if (pt == "not turn")
            {
                menuText.GetComponent<Text>().text = "�� ������� ����� �� ����������� � ����� ������ � ������ ������� ��-���� �������. �� ��� �� ��� �� ��������, ���� ���?";

                if (File.Exists(Path.Combine(playerDataPath, playerDataFileName)))
                {
                    //try
                    //{
                        using (StreamReader sr = new StreamReader(Path.Combine(playerDataPath, playerDataFileName), System.Text.Encoding.Default))
                        {
                            while ((line = sr.ReadLine()) != null)
                            {
                                lastLine = line;
                            }
                        }
                    //}
                    //catch (Exception e)
                    //{
                    //    Debug.Log(e.GetType().ToString());
                    //    Debug.Log(e.Message);
                    //}

                    if ((lastLine != "") && (lastLine[lastLine.Length - 1] == '&'))
                    {
                        //try
                        //{
                            using (StreamWriter sw = new StreamWriter(Path.Combine(playerDataPath, playerDataFileName), true, System.Text.Encoding.Default))
                            {
                                sw.Write("not turn");
                                sw.Flush();
                                sw.Close();
                            }
                        //}
                        //catch (Exception e)
                        //{
                        //    Debug.Log(e.GetType().ToString());
                        //    Debug.Log(e.Message);
                        //}
                    }
                }
            }
            else
            {
                menuText.GetComponent<Text>().text = "�� �������... � �� ����, ��� ������ �� �������, �� �����-�� ������� �� ������� �����������. ����������, ������ ��� �� �������.";
            }

            menuText.GetComponent<Text>().text += "\r\n�� ���� ����������� �������, ������� �� �������. ����� ��������� � ������� ����, ����������� ����� � ��� �� ������.";

            exitLever.SetActive(true);
            menu.SetActive(true);
        }
    }
}
