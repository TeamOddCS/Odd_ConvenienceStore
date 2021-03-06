using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Day7_F : MonoBehaviour
{
    [SerializeField] private Text txt_name;// 이름 담는 객체 
    [SerializeField] private Text txt_dialogue; //대화내용 담는 객체

    private string inputText;
    public static bool isDialogue = false;
    public static int count = 0;
    private List<Dictionary<string, object>> data;
    public FadeInOut fade;
    public AudioClip touchclip;
    public AudioClip ring;

    public void Showdialogue()// 처음시작할때 다 초기화하고 대화내용을 보여주는 함수
    {
        txt_dialogue.gameObject.SetActive(true);
        txt_name.gameObject.SetActive(true);
        count = 0;
        isDialogue = true;
        if(count==0)
            Nextdialogue();
    }
    public void Nextdialogue()//대화내용 넘기는 함수
    {
        Debug.Log(count);
        txt_dialogue.gameObject.SetActive(true);
        txt_name.gameObject.SetActive(true);
        txt_name.text = data[count]["Name"].ToString();
        data[count]["Script"] = data[count]["Script"].ToString().Replace("#", ",");
        data[count]["Script"] = data[count]["Script"].ToString().Replace("  ", "\n");
        //txt_dialogue.text = data[count]["Script"].ToString();
        inputText = data[count]["Script"].ToString();
        StartCoroutine("typingText");
        if (count > 0)
        {
            SoundManager.instance.SFXPlay("Touch", touchclip);
        }
        if(count == 0)
        {
            SoundManager.instance.SFXPlay("Ring", ring);
        }    
        count++;
    }

    private void Hidedialogue()//대화가 끝났으면 대화내용 숨기는 함수
    {
        txt_name.gameObject.SetActive(false);
        txt_dialogue.gameObject.SetActive(false);
        isDialogue = false;
    }
    private void day7_F_JD()//첫번째 선택지를 골랐을 경우 선택지 대화를 다본후 다음 대화로 넘어가는 함수
    {
        if (count < data.Count)
        {
            Nextdialogue();

            if (count == 23)
            {
                count += 32 - 23;
            }
        }
        else
        {
            fade.Fade();
            Hidedialogue();
        }
    }

    IEnumerator typingText()
    {
        char nowChar;
        string showText = " ";
        for (int i = 0; i < inputText.Length; i++)
        {
            nowChar = inputText[i];
            showText = inputText.Substring(0, i);
            txt_dialogue.text = showText + nowChar.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void Start()
    {
        data = CSVReader.Read("Day7-F");
        Showdialogue();
    }
    // Update is called once per frame
    void Update()
    {
        if (isDialogue)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (EventSystem.current.IsPointerOverGameObject() == false)
                    day7_F_JD();
            }
        }
        else
            Hidedialogue();
    }
}
