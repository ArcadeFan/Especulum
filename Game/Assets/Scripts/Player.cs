using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public float jumHeight = 4;
    public float timeToJumpApex = .4f;

    float moveSpeed = 6;
    float gravity = -20;

    float jumpVelocity = 8;

    Vector3 velocity;

    Controller2D controler;
    BoxCollider2D boxcol2D;

    public Image sis0img;
    public Image sis1img;

    public int money = 0;




    public GameObject sis0Obj;
    public GameObject sis1Obj;

    public int sis0Life = 0;
    public int sis1Life = 0;


    public bool sis0 = false;
    public bool sis1 = false;

    


    private void Start()
    {
        


        sis0Life = 100;
        sis1Life = 100;


        controler = GetComponent<Controller2D>();

        boxcol2D = GetComponent<BoxCollider2D>();

        gravity = -(2 * jumHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("gravity :" + gravity + "jum velocity :" + jumpVelocity);



    }


    void Update()
    {

        if(sis0==false)
        {
            sis0Obj.SetActive(false);
            boxcol2D.size = new Vector2(1.6f,8.11f);
            boxcol2D.offset = new Vector2(-0.072f, 1.30f);
                       
                        /*Sprite tmp = UiImagen1.sprite;
            UIimage1.sprite = UIimagen2.sprite;
            UIimage2,sprite = tmp;
            */
            

        }
        else
        {
            sis0Obj.SetActive(true);
            boxcol2D.size = new Vector2(1.2f, 5.9f);
            boxcol2D.offset = new Vector2(-0.072f, -0.02f);
                 
            

        }

        /*  if (sis1 == false)
          {
              sis1Obj.SetActive(false);

              Sprite tmp = sis.sprite;
              UIimage1.sprite = UIimagen2.sprite;
              UIimage2,sprite = tmp;

          }
          else
          {
              sis1Obj.SetActive(true);

              Sprite tmp = UiImagen1.sprite;
              UIimage1.sprite = UIimagen2.sprite;
              UIimage2,sprite = tmp;

          }*/

              


        if (sis0Life >= 0 && sis1Life >= 0)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                sis0 = !sis0;
                sis1 = !sis1;

            

            }
        }


        if (controler.collisions.above || controler.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Input.GetKeyDown(KeyCode.Space)&&controler.collisions.below)
        {
            velocity.y = jumpVelocity;
        }
        velocity.x = input.x * moveSpeed;
        velocity.y += gravity * Time.deltaTime;
        controler.Move(velocity * Time.deltaTime);

    }


 

}
