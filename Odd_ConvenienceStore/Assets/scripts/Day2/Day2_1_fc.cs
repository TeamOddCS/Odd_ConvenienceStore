using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day2_1_fc : MonoBehaviour
{
    public Sprite[] js4_face;
    public GameObject js4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Day2_1.facenum == 1)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[0];
        }
        else if (Day2_1.facenum == 2)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[1];
        }
        else if (Day2_1.facenum == 3)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[2];
        }
        else if (Day2_1.facenum == 4)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[3];
        }
        else if (Day2_1.facenum == 5)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[4];
        }
        else if (Day2_1.facenum == 6)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[5];
        }
        else if (Day2_1.facenum == 7)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[6];
        }
        else if (Day2_1.facenum == 8)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[7];
        }
        else if (Day2_1.facenum == 9)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[8];
        }

        else if (Day2_1.facenum == 10)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[9];
        }
        else if (Day2_1.facenum == 11)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[10];
        }
        else if (Day2_1.facenum == 12)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[11];
        }
        else if (Day2_1.facenum == 13)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[12];
        }
        else if (Day2_1.facenum == 14)
        {
            js4.GetComponent<SpriteRenderer>().sprite = js4_face[13];
        }


    }
}
