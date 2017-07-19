using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextBoxManager : MonoBehaviour {


    public GameObject textBox;

    public Text theText;

    public TextAsset textfile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;

    public IsometricMovement player;

    public bool isActive;

    public bool stopPlayerMovement;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typespeed;


	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<IsometricMovement>();

        if (textfile != null)
        {
            textLines = (textfile.text.Split('\n'));
        }

        if(endAtLine ==0)
        {
            endAtLine = textLines.Length - 1;
        }

    }

  



    // Update is called once per frame
    void Update ()
    {
        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }

        if (!isActive)
        {
            return; 
        }

      

        theText.text = textLines[currentLine];
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (!isTyping)
            {



                currentLine += 1;
                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }

            }
            else if(isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
       
		
	}

    private IEnumerator TextScroll (string lineOfText)
    {

        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while(isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {

            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typespeed);

        }
        //theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;

    }

    void EnableTextBox()
    {

        textBox.SetActive(true);

        if(stopPlayerMovement)
        {
            player.CanMove = false;
        }

        StartCoroutine(TextScroll(textLines[currentLine]));



    }
    void DisableTextBox()
    {
        
        textBox.SetActive(false);
        player.CanMove = true;



    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (textfile.text.Split('\n'));
        }


    }
  

}
