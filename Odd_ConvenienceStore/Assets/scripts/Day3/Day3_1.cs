using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Day3_1 : MonoBehaviour
{
    [SerializeField] private Text txt_dialogue; //대화내용 담는 객체
    [SerializeField] private Text txt_name;// 이름 담는 객체 
    public static bool isDialogue = false;
    public static int count = 0;
    private List<Dictionary<string, object>> data;
    public FadeInOut fade;
    public AudioClip touchclip;
    public AudioClip bell;
    public GameObject HealthControlScript;
    public static int facenum = 0;
    public AudioClip minus;
    public GameObject GameController;

    public void Showdialogue()// 처음시작할때 다 초기화하고 대화내용을 보여주는 함수
    {
        txt_dialogue.gameObject.SetActive(true);
        txt_name.gameObject.SetActive(true);
        //count = 0;
        isDialogue = true;
        if(count==0)
            Nextdialogue();
    }
    public void TextColorChange()
    {
        data[count]["Script"] = data[count]["Script"].ToString().Replace("ⓑ", "<color=#2782cc>");//파란색 "중요한부분"
        data[count]["Script"] = data[count]["Script"].ToString().Replace("ⓡ", "<color=#a83a22>");//빨간색 (생명력 -)
        data[count]["Script"] = data[count]["Script"].ToString().Replace("ⓖ", "<color=#13c216>");//초록색 (생명력 +) 
        data[count]["Script"] = data[count]["Script"].ToString().Replace("ⓔ", "</color>");// 바꿀 색깔이 끝났을때 쓰는 기호
        data[count]["Script"] = data[count]["Script"].ToString().Replace("ⓐ", "<color=#a8a3a2>");//주인공 독백 
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
        FaceChange();
        txt_dialogue.text = data[count]["Script"].ToString();
        if (count > 0)
        {
            SoundManager.instance.SFXPlay("Touch", touchclip);
        }
        if(count == 0)
        {
            SoundManager.instance.SFXPlay("Bell", bell);
        }
        if (count == 14)
        {
            SoundManager.instance.SFXPlay("Bell", bell);
        }
        if (count == 119)
        {
            SoundManager.instance.SFXPlay("Bell", bell);
        }

        count++;
    }
    private void FaceChange()
    {
        if (data[count]["Face"].ToString().Equals("3_1_1"))
        {
            facenum = 1;
        }
        if (data[count]["Face"].ToString().Equals("3_1_2"))
        {
            facenum = 2;
        }
        if (data[count]["Face"].ToString().Equals("3_2_1"))
        {
            facenum = 3;
        }
        if (data[count]["Face"].ToString().Equals("3_2_2"))
        {
            facenum = 4;
        }
        if (data[count]["Face"].ToString().Equals("3_3_1"))
        {
            facenum = 5;
        }
        if (data[count]["Face"].ToString().Equals("3_3_2"))
        {
            facenum = 6;
        }
        

    }

    private void Hidedialogue()//대화가 끝났으면 대화내용 숨기는 함수
    {
        txt_name.gameObject.SetActive(false);
        txt_dialogue.gameObject.SetActive(false);
        isDialogue = false;
    }
    public void Awake()
    {
        SaveData.DoLoadData = true;
        SaveData.TempScene = "Day3-1";
        count = SaveData.TempCount;
        SaveData.Saves();
    }

    private void Start()
    {
        data = CSVReader.Read("Day3-1");
        Debug.Log("showhealth");
        HealthControlScript.GetComponent<HealthControlScript>().Show_Health();
        Showdialogue();
    }

    private void day3_1_JD()
    {
        if (count < data.Count)
        {
            Nextdialogue();
            if (count == 29)
            {//형편이 좋지 않은 것 뿐입니다.
                count += 3;
            }
            if (count == 44)
            {//3일째 굶고 있습니다.
                count += 18;
            }
            if (count == 48)
            {//수입이 생기면 바로 갚겠습니다.
                count += 14;
            }
            if (count == 58)
            {//직업이라고 할 순 없지만, 제가 할 수 있는 건 그것밖에 없어요.
                count += 4;
            }
            
            if (count == 71)
            {//언젠간… 갚겠지?
                count += 30;
            }

            if (count == 91)
            {//정리하느라 땀 좀 뺄 것 같다..
                count += 10;
            }
            if (count == 116)
            {//말보루 블랙민트 하나요.
                count += 19;
            }
            if (count == 129)
            {//말보루 블랙민트 하나요.(뭐드릴까요 다음)
                count += 6;
            }
        }
        else
        {
            fade.Fade();
            Hidedialogue();
            count = 1;
            GameController.GetComponent<JSChoice>().D3_JSChoice();
        }
    }

    private void day3_1_HC()
    {
        if (count < data.Count)
        {
          
            if (count == 65)
            { //외상해드릴게요.
                SoundManager.instance.SFXPlay("Minus", minus);
                SaveData.JSName = "JS3";
                HealthControlScript.GetComponent<HealthControlScript>().health_decrease();
            }
            if (count == 70)
            {//진상3은 가벼운 발걸음으로 나간다.
                SoundManager.instance.SFXPlay("Minus", minus);
                SaveData.JSName = "JS3";
                HealthControlScript.GetComponent<HealthControlScript>().health_decrease();

            }

            if (count == 87)
            {//진상 3은 매대에서 껌을 한웅큼 집어 바닥에 흩뿌린다.
                SoundManager.instance.SFXPlay("Minus", minus);
                SaveData.JSName = "JS3";
                HealthControlScript.GetComponent<HealthControlScript>().health_decrease();
            }

            if (count == 134)
            {//좀 못들은 걸로 꼽은..ㅋㅋ ㅆㅂ
                SoundManager.instance.SFXPlay("Minus", minus);
                SaveData.JSName = "JS7";
                HealthControlScript.GetComponent<HealthControlScript>().health_decrease();
            }

            if (count == 158)
            {//몰라. 직원분이 나한테 개지랄하잖어
                SoundManager.instance.SFXPlay("Minus", minus);
                SaveData.JSName = "JS7";
                HealthControlScript.GetComponent<HealthControlScript>().health_decrease();
            }
        }
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
                    day3_1_JD();
                    day3_1_HC();
                    SaveData.TempCount = count - 1;
                    SaveData.Saves();
                }
            } 
        }
        else
            Hidedialogue();
    }
}
