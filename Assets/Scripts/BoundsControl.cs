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
                menuText.GetComponent<Text>().text = "Вы сделали... Я не знаю, что именно вы сделали, но каким-то образом вы сломали эксперимент. Пожалуйста, больше так не делайте. \r\nНа этом эксперимент окончен, спасибо за участие. Чтобы вернуться в главное меню, переключите рычаг у вас за спиной.";
                exitLever.SetActive(true);
                menu.SetActive(true);
            }
        }
    }
}
