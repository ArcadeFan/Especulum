using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endline;

    public TextBoxManager thetextbox;

    public bool destroyWhenActivated;

	// Use this for initialization
	void Start ()
    {

        thetextbox = FindObjectOfType<TextBoxManager>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {


		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {


            thetextbox.ReloadScript(theText);
            thetextbox.currentLine = startLine;
            thetextbox.endAtLine = endline;
            thetextbox.isActive = true;

            if(destroyWhenActivated)
            {

                Destroy(gameObject);

            }
        }
    }
}
