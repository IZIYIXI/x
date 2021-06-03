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
        playerDataPath = Application.dataPath + "/Results/";
        playerDataFileName = "results.kgtp";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trolley")
        {
            string line = "", lastLine = "";

            Text pt = playerData.GetComponent<Text>();

            if (pt.text == "turn")
            {
                menuText.GetComponent<Text>().text = "�� ������� ����� ��������� � ������ ���� ������, ����������� �����. �� ������ �� ��� ����? \r\n�� ���� ����������� �������, ������� �� �������. ����� ��������� � ������� ����, ����������� ����� � ��� �� ������.";

                using (StreamReader sr = new StreamReader(playerDataPath + playerDataFileName, System.Text.Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        lastLine = line;
                    }
                }

                if ((lastLine != "") && (lastLine[lastLine.Length-1] == '&'))
                {
                    using (StreamWriter sw = new StreamWriter(playerDataPath + playerDataFileName, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("turn");
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            else if (pt.text == "not turn")
            {
                menuText.GetComponent<Text>().text = "�� ������� ����� �� ����������� � ����� ������ � ������ ������� ��-���� �������. �� ��� �� ��� �� ��������, ���� ���? \r\n�� ���� ����������� �������, ������� �� �������. ����� ��������� � ������� ����, ����������� ����� � ��� �� ������.";

                using (StreamReader sr = new StreamReader(playerDataPath + playerDataFileName, System.Text.Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        lastLine = line;
                    }
                }

                if ((lastLine != "") && (lastLine[lastLine.Length - 1] == '&'))
                {
                    using (StreamWriter sw = new StreamWriter(playerDataPath + playerDataFileName, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("not turn");
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            else
            {
                menuText.GetComponent<Text>().text = "�� �������... � �� ����, ��� ������ �� �������, �� �����-�� ������� �� ������� �����������. ����������, ������ ��� �� �������. \r\n�� ���� ����������� �������, ������� �� �������. ����� ��������� � ������� ����, ����������� ����� � ��� �� ������.";
            }

            exitLever.SetActive(true);
            menu.SetActive(true);
        }
    }
}
