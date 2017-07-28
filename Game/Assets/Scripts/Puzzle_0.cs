using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Puzzle_0 : MonoBehaviour
{

    public float panel1 = 0;
    public float panel2 = 0;
    public float panel3 = 0;

    public int panel1resp;
    public int panel2resp;
    public int panel3resp;


    public float cdcheck;

    public bool panelbool1;
    public bool panelbool2;
    public bool panelbool3;

    public bool complete = false;

    //botones para el puzzle
    public Button panelbutton1;
    public Button panelbutton2;
    public Button panelbutton3;

    public Image panel1img;
    public Image panel2img;
    public Image panel3img;

    public Image panel1respimg;
    public Image panel2respimg;
    public Image panel3respimg;
    public Image Letrero;
    public Sprite completeSprite;


    //lucesitas

    public Image luz1;
    public Image luz2;
    public Image luz3;









    // Use this for initialization
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {
        if (cdcheck > 0)
        {
            cdcheck--;
        }

        ///panel 1
        if (panel1 == 1 && panelbool1 == false)
        {
            panel1img.GetComponent<Image>().color = panel1respimg.GetComponent<Image>().color;
            panelbool1 = true;




        }
        else if (panel1 == 2 && panelbool2 == false)
        {
            panel1img.GetComponent<Image>().color = panel2respimg.GetComponent<Image>().color;
            panelbool1 = false;
            panelbool2 = true;

        }
        else if (panel1 == 3 && panelbool3 == false)
        {
            panel1img.GetComponent<Image>().color = panel3respimg.GetComponent<Image>().color;
            panelbool1 = false;
            panelbool2 = false;
            panelbool3 = true;

        }
        else if (panel1 >= 4)
        {
            panel1 = 0;
            panel1img.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            panelbool3 = false;
        }

        ///panel 2
        if (panel2 == 1 && panelbool1 == false)
        {
            panel2img.GetComponent<Image>().color = panel1respimg.GetComponent<Image>().color;
            panelbool1 = true;




        }
        else if (panel2 == 2 && panelbool2 == false)
        {
            panel2img.GetComponent<Image>().color = panel2respimg.GetComponent<Image>().color;
            panelbool1 = false;
            panelbool2 = true;

        }
        else if (panel2 == 3 && panelbool3 == false)
        {
            panel2img.GetComponent<Image>().color = panel3respimg.GetComponent<Image>().color;
            panelbool1 = false;
            panelbool2 = false;
            panelbool3 = true;
        }
        else if (panel2 >= 4)
        {
            panel2 = 0;
            panel2img.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            panelbool3 = false;
        }


        ///panel 3
        if (panel3 == 1 && panelbool1 == false)
        {
            panel3img.GetComponent<Image>().color = panel1respimg.GetComponent<Image>().color;
            panelbool1 = true;



        }
        else if (panel3 == 2 && panelbool2 == false)
        {
            panel3img.GetComponent<Image>().color = panel2respimg.GetComponent<Image>().color;
            panelbool1 = false;
            panelbool2 = true;
        }
        else if (panel3 == 3 && panelbool3 == false)
        {
            panel3img.GetComponent<Image>().color = panel3respimg.GetComponent<Image>().color;
            panelbool2 = false;
            panelbool3 = true;
        }
        else if (panel3 >= 4)
        {
            panelbool3 = false;
            panel3 = 0;
            panel3img.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        }



    }
    public void change()
    {

        panel1++;


    }
    public void change2()
    {

        panel2++;





    }
    public void change3()
    {

        panel3++;


    }
    public void check()
    {

        if (panel1 == panel1resp)
        {


            luz1.GetComponent<Image>().color = new Color32(0, 255, 255, 255);

        }
        else
        {
            luz1.GetComponent<Image>().color = new Color32(255, 0, 0, 255);

        }
        if (panel2 == panel2resp)
        {


            luz2.GetComponent<Image>().color = new Color32(0, 255, 255, 255);

        }
        else
        {
            luz2.GetComponent<Image>().color = new Color32(255, 0, 0, 255);

        }
        if (panel3 == panel3resp)
        {


            luz3.GetComponent<Image>().color = new Color32(0, 255, 255, 255);

        }
        else
        {
            luz3.GetComponent<Image>().color = new Color32(255, 0, 0, 255);

        }





        if (panel1 == panel1resp && panel2 == panel2resp && panel3 == panel3resp)
        {


            complete = true;
            Letrero.sprite = completeSprite;
            StartCoroutine(Example());
        }


    }



    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }

}