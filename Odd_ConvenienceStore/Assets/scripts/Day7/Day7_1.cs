using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Day7_1 : MonoBehaviour
{
    [SerializeField] private Text txt_name;// 이름 담는 객체 
    [SerializeField] private Text txt_dialogue; //대화내용 담는 객체
    public static bool isDialogue = false;
    public static int count = 0;
    private List<Dictionary<string, object>> data;
    public FadeInOut fade;
    public AudioClip touchclip;
    public AudioClip bell;
    public GameObject HealthControlScript;
    public AudioClip minus;

    public void Showdialogue()// 처음시작할때 다 초기화하고 대화내용을 보여주는 함수
    {
        txt_dialogue.gameObject.SetActive(true);
        txt_name.gameObject.SetActive(true);
        //count = 0;
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
        TextColorChange();
        txt_dialogue.text = data[count]["Script"].ToString();
        if (count > 0)
        {
            SoundManager.instance.SFXPlay("Touch", touchclip);
        }
        if(count == 0)
        {
            SoundManager.instance.SFXPlay("Bell", bell);
        }
        if (count == 8)
        {
            SoundManager.instance.SFXPlay("Bell", bell);
        }
        if (count == 53)
        {
            SoundManager.instance.SFXPlay("Bell", bell);
        }
        count++;

    }
    public void TextColorChange()
    {
        data[count]["Script"] = data[count]["Script"].ToString().Replace("ⓑ", "<color=#2782cc>");//파란색 "중요한부분"
        data[count]["Script"] = data[count]["Script"].ToString().Replace("ⓡ", "<color=#a83a22>");//빨간색 (생명력 -)
        data[count]["Script"] = data[count]["Script"].ToString().Replace("ⓖ", "<color=#13c216>");//초록색 (생명력 +) 
        data[count]["Script"] = data[count]["Script"].ToString().Replace("ⓔ", "</color>");// 바꿀 색깔이 끝났을때 쓰는 기호
        data[count]["Script"] = data[count]["Script"].ToString().Replace("ⓐ", "<color=#a8a3a2>");//주인공 독백 
    }


    private void Hidedialogue()//대화가 끝났으면 대화내용 숨기는 함수
    {
        txt_name.gameObject.SetActive(false);
        txt_dialogue.gameObject.SetActive(false);
        isDialogue = false;
    }
    private void day7_1_HC()
    {
        if (count == 28)
        {
            SoundManager.instance.SFXPlay("Minus", minus);
            SaveData.JSName = " JS8";
            HealthControlScript.GetComponent<HealthControlScript>().health_decrease();
        }
        if (count == 71)
        {
            SoundManager.instance.SFXPlay("Minus", minus);
            SaveData.JSName = " JS2";
            HealthControlScript.GetComponent<HealthControlScript>().health_decrease();
        }
        if (count == 93)
        {
            SoundManager.instance.SFXPlay("Minus", minus);  
            SaveData.JSName = " JS2";
            HealthControlScript.GetComponent<HealthControlScript>().health_decrease();
        }
       

    }
    public void Awake()
    {
        SaveData.DoLoadData = true;
        SaveData.TempScene = "Day7-1";
        count = SaveData.TempCount;
        SaveData.Saves();
    }

    private void Start()
    {
        data = CSVReader.Read("Day7-1");
        HealthControlScript.GetComponent<HealthControlScript>().Show_Health();
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
                {
                    if (count < data.Count)
                    {
                        Nextdialogue();
                        if (count == 18)
                        {
                            count += 3;
                        }
                        if (count == 40)
                        {
                            count += 13;
                        }
                        if (count == 74)
                        {
                            count += 4;
                        }
                        if (count == 89)
                        {
                            count += 13;
                        }
                    }
                    else
                    {
                        fade.Fade();
                        Hidedialogue();
                    }
                    day7_1_HC();
                    SaveData.TempCount = count - 1;
                    SaveData.Saves();
                }
            }
        }
        else
            Hidedialogue();
    }
}
