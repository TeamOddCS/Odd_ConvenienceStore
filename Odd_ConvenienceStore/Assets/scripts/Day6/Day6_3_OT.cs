using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day6_3_OT : MonoBehaviour
{
    public GameObject option_page;

    public void OptionOn()
    {
        Time.timeScale = 0;
        option_page.SetActive(true);
        Day6_3.isDialogue = false;
    }
    public void OptionOff()
    {
        Time.timeScale = 1;
        option_page.SetActive(false);
        if (Day6_3_C.isChoice == true)
        {
            Day6_3.isDialogue = false;
        }
        else
        {
            Day6_3.isDialogue = true;
        }
    }
}
