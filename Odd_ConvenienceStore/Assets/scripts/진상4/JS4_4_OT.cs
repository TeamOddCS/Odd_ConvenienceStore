using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS4_4_OT : MonoBehaviour
{
    public GameObject option_page,js4_4;

    public void OptionOn()
    {
        Time.timeScale = 0;
        option_page.SetActive(true);
        JinSang4_4.isDialogue = false;
    }
    public void OptionOff()
    {
        Time.timeScale = 1;
        option_page.SetActive(false);
        if (JS4_C.isChoice == true)
        {
            JinSang4_4.isDialogue = false;
        }
        else
        {
            js4_4.GetComponent<JinSang4_4>().Showdialogue();
        }
    }
}
