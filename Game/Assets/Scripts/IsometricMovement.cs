using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsometricMovement : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 4f;

    Vector3 forward, right;



    public Image sis0img;
    public Image sis1img;




    public GameObject sis0Obj;
    public GameObject sis1Obj;

    public int sis0Life = 0;
    public int sis1Life = 0;


    public bool sis0 = false;
    public bool sis1 = false;


    public Transform cam;

    // Use this for initialization
    void Start () {

        

        sis0 = true;

        sis0Life = 100;
        sis1Life = 100;

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
		
	}
	
	// Update is called once per frame
	void Update () {

        //sis0Obj.transform.LookAt(cam);
        //sis1Obj.transform.LookAt(cam);


        

        if (Input.anyKey)
            Move();
        if(Input.GetAxis("VerticalKey") >0)
        {
            print("arriba");
        }

        if (sis0 == false)
        {
            sis0Obj.SetActive(false);

           




            //boxcol2D.size = new Vector2(1.6f, 8.11f);
            //boxcol2D.offset = new Vector2(-0.072f, 1.30f);

            //sis0img.sprite = sis1img.sprite;






        }
        else
        {
            sis0Obj.SetActive(true);
            //boxcol2D.size = new Vector2(1.2f, 5.9f);
            //boxcol2D.offset = new Vector2(-0.072f, -0.02f);

            //sis1img.sprite = sis0img.sprite;


        }

        if (sis1 == false)
        {
            sis1Obj.SetActive(false);

        }
        else
        {
            sis1Obj.SetActive(true);

            
            
        }

        if (sis0Life >= 0 && sis1Life >= 0)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                sis0 = !sis0;
                sis1 = !sis1;

                Sprite tmp = sis0img.sprite;
                sis0img.sprite = sis1img.sprite;
                sis1img.sprite = tmp;


                //usar bilboard para ver las imagenes a la camara siempre al frente 



            }
        }


    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;

    }
}
