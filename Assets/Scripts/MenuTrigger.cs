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

    private string line;
    private string lastLine;

    private string playerDataPath = Application.streamingAssetsPath + "/Results/" + "result" + ".db";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trolley")
        {
            Text pt = playerData.GetComponent<Text>();
            if (pt.text == "turn")
            {
                menuText.GetComponent<Text>().text = "�� ������� ����� ��������� � ������ ���� ������, ����������� �����. �� ������ �� ��� ����? \r\n�� ���� ����������� �������, ������� �� �������. ����� ��������� � ������� ����, ����������� ����� � ��� �� ������.";

                using (StreamReader sr = new StreamReader(playerDataPath, System.Text.Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        lastLine = line;
                    }
                }

                if (lastLine[lastLine.Length-1] == '&')
                {
                    using (StreamWriter sw = new StreamWriter(playerDataPath, true, System.Text.Encoding.Default))
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

                using (StreamReader sr = new StreamReader(playerDataPath, System.Text.Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        lastLine = line;
                    }
                }

                if (lastLine[lastLine.Length - 1] == '&')
                {
                    using (StreamWriter sw = new StreamWriter(playerDataPath, true, System.Text.Encoding.Default))
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
