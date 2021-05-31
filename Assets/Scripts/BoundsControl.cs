using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundsControl : MonoBehaviour
{
    public GameObject exitLever;
    public GameObject menu;
    public GameObject menuText;
    public GameObject playerData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trolley")
        {
            if (!exitLever.activeSelf)
            {
                Text pt = playerData.GetComponent<Text>();
                pt.text = "! bounds error !";
                menuText.GetComponent<Text>().text = "�� �������... � �� ����, ��� ������ �� �������, �� �����-�� ������� �� ������� �����������. ����������, ������ ��� �� �������. \r\n�� ���� ����������� �������, ������� �� �������. ����� ��������� � ������� ����, ����������� ����� � ��� �� ������.";
                exitLever.SetActive(true);
                menu.SetActive(true);
            }
        }
    }
}
