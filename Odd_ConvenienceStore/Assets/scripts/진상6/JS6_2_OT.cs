using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS6_2_OT : MonoBehaviour
{
    public GameObject option_page,js6_2;

    public void OptionOn()
    {
        Time.timeScale = 0;
        option_page.SetActive(true);
        JinSang6_2.isDialogue = false;
    }
    public void OptionOff()
    {
        Time.timeScale = 1;
        option_page.SetActive(false);
        if (JS6_2_C.isChoice == true)
        {
            JinSang6_2.isDialogue = false;
        }
        else
        {
            js6_2.GetComponent<JinSang6_2>().Showdialogue();
        }
    }
}
