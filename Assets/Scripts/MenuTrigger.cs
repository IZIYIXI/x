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
                menuText.GetComponent<Text>().text = "Вы сделали выбор вмешаться и спасти пять жизней, пожертвовав одной. Но стоило ли оно того? \r\nНа этом эксперимент окончен, спасибо за участие. Чтобы вернуться в главное меню, переключите рычаг у вас за спиной.";

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
                menuText.GetComponent<Text>().text = "Вы сделали выбор не вмешиваться в чужие судьбы и пятеро человек всё-таки погибли. Но это же вас не касается, ведь так? \r\nНа этом эксперимент окончен, спасибо за участие. Чтобы вернуться в главное меню, переключите рычаг у вас за спиной.";

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
                menuText.GetComponent<Text>().text = "Вы сделали... Я не знаю, что именно вы сделали, но каким-то образом вы сломали эксперимент. Пожалуйста, больше так не делайте. \r\nНа этом эксперимент окончен, спасибо за участие. Чтобы вернуться в главное меню, переключите рычаг у вас за спиной.";
            }

            exitLever.SetActive(true);
            menu.SetActive(true);
        }
    }
}
