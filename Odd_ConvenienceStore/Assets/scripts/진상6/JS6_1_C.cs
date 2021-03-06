using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class JinSang6Choice1
{
    [TextArea]
    public string _choice;
    public string _choice2;
}

public class JS6_1_C : MonoBehaviour
{
    [SerializeField] private Button choicebtn1;
    [SerializeField] private Button choicebtn2;
    [SerializeField] private Text txt_choice1;
    [SerializeField] private Text txt_choice2;
    public static bool isChoice = false;
    public static int count = 0;
    [SerializeField] private JinSang6Choice1[] choice;
    public void ShowChoice()
    {
        ChoiceOn();
        txt_choice1.text = choice[count]._choice;
        txt_choice2.text = choice[count]._choice2;

        SaveData.Loads();
        SaveData.reGame = JinSang6_1.count;
        SaveData.reGameStart = "JinSang6_1";
        SaveData.reGameChoice = count;
        SaveData.Saves();
    }
    public void NextChoice1()
    {
        count++;
        if (JinSang6_1.count == 7)
        {
            JinSang6_1.count++;
        }

        if (JinSang6_1.count == 15)
        {
            SaveData.JinSang6Day1 = 2;
            SaveData.Saves();
            JinSang6_1.count++;
        }
        ChoiceOff();
    }
    public void NextChoice2()
    {
        count++;
        if (JinSang6_1.count == 7)
        {
            SaveData.JinSang6Day1 = 1;
            SaveData.Saves();
            JinSang6_1.count += 24 - 7;
        }

        if (JinSang6_1.count == 15)
        {
            SaveData.JinSang6Day1 = 1;
            SaveData.Saves();
            JinSang6_1.count += 22 - 15;
        }
        ChoiceOff();
    }
    public void ChoiceOn()
    {
        JinSang6_1.isDialogue = false;
        choicebtn1.gameObject.SetActive(true);
        choicebtn2.gameObject.SetActive(true);
        txt_choice1.gameObject.SetActive(true);
        txt_choice2.gameObject.SetActive(true);
    }
    public void ChoiceOff()
    {
        JinSang6_1.isDialogue = true;
        choicebtn1.gameObject.SetActive(false);
        choicebtn2.gameObject.SetActive(false);
        txt_choice1.gameObject.SetActive(false);
        txt_choice2.gameObject.SetActive(false);
    }
    public void CallChoice()
    {
        if (JinSang6_1.count == 7)
        {
            ShowChoice();
        }
        if (JinSang6_1.count == 15)
        {
            ShowChoice();
        }
    }

    private void Start()
    {
        SaveData.Loads();
        ChoiceOff();
    }
    private void Update()
    {
        CallChoice();
    }
}