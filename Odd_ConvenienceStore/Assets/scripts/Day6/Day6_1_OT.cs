using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day6_1_OT : MonoBehaviour
{
    public GameObject option_page,day6_1;

    public void OptionOn()
    {
        Time.timeScale = 0;
        option_page.SetActive(true);
        Day6_1.isDialogue = false;
    }
    public void OptionOff()
    {
        Time.timeScale = 1;
        option_page.SetActive(false);
        if (Day6_1_C.isChoice == true)
        {
            Day6_1.isDialogue = false;
        }
        else
        {
            day6_1.GetComponent<Day6_1>().Showdialogue();
        }
    }
}
