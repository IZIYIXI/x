using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTrigger : MonoBehaviour
{
    public GameObject exitLever;
    public GameObject menu;
    public GameObject menuText;
    public GameObject playerData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trolley")
        {
            Text pt = playerData.GetComponent<Text>();
            if (pt.text == "turn")
            {
                menuText.GetComponent<Text>().text = "�� ������� ����� ��������� � ������ ���� ������, ����������� �����. �� ������ �� ��� ����? \r\n�� ���� ����������� �������, ������� �� �������. ����� ��������� � ������� ����, ����������� ����� � ��� �� ������.";
            }
            else if (pt.text == "not turn")
            {
                menuText.GetComponent<Text>().text = "�� ������� ����� �� ����������� � ����� ������ � ������ ������� ��-���� �������. �� ��� �� ��� �� ��������, ���� ���? \r\n�� ���� ����������� �������, ������� �� �������. ����� ��������� � ������� ����, ����������� ����� � ��� �� ������.";
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
