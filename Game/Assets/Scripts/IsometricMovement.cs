using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsometricMovement : MonoBehaviour {

    [SerializeField]
    
    float moveSpeed = 4f;

    Vector3 forward, right;
    public GameObject primerdialogo;

    public bool CanMove;

    public Image lifebar;
    public Image specialbar;


    public Image sis0img;
    public Image sis1img;

    public SpriteRenderer sis1Sprite;
    public SpriteRenderer sis0Sprite;

    public GameObject bullet;
    public GameObject bullet0;



    public Animator anim;


    public GameObject sis0Obj;
    public GameObject sis1Obj;

    //vida de las hermanas

    public float sis0Life = 0.0f;
    public float sis1Life = 0.0f;
    public float special = 0.0f;


    public bool sis0 = false;
    public bool sis1 = false;


    public Transform cam;
    public Camera came;
    public float BulletSpeed;

    // Use this for initialization
    void Start () {

        
        

        sis0 = true;

        sis0Life = 100;
        sis1Life = 100;

        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        anim = GetComponent<Animator>();

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        sis1Sprite.GetComponent<SpriteRenderer>();
        sis0Sprite.GetComponent<SpriteRenderer>();


        //sis0img2.GetComponent<SpriteRenderer>();
        //sis1Obj.GetComponent<SpriteRenderer>();

        StartCoroutine(Example());
    }

    // Update is called once per frame
    void Update () {

        if(!CanMove)
        {
            return;
        }

        if(sis0Life<=0)
        {
            sis1 = true;
                
            sis0 = false;


            



        }
        else if (sis1Life<=0)
        {
            sis0 = true;
            

            sis1 = false;
           

        }

        //sis1Obj.transform.LookAt(cam);

        anim = GetComponentInChildren<Animator>();
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

        Debug.Log(anim.GetFloat("MoveX"));
        Debug.Log(anim.GetFloat("MoveY"));

        if(sis0==true && Input.GetAxisRaw("Horizontal")< 0)
         {

            Debug.Log("izquierda");
            sis0Sprite.flipX = true;


        }
        else if(sis0 == true && Input.GetAxisRaw("Horizontal") > 0)
        {
            Debug.Log("Derecha");

            sis0Sprite.flipX = false;

        }
        if (sis1 == true && Input.GetAxisRaw("Horizontal") < 0)
        {

            Debug.Log("izquierda");

            sis1Sprite.flipX = true;

        }
        else if (sis1 == true && Input.GetAxisRaw("Horizontal") > 0)
        {
            Debug.Log("Derecha");
            sis1Sprite.flipX = false;
        }

        if (Input.GetKey(KeyCode.E))
        {
            special --;

        }

        
        if(special <=0)
        { special = 0; }
        else if (special >=100)
        {
            special = 100;
        }

        specialbar.fillAmount = special / 100;


        //cam.transform.position = Vector3.Lerp(transform.position,)


       /* Ray mouseraye = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Input.GetMouseButtonDown(0))
        {
            transform.LookAt(mouseraye.direction);

            Instantiate(bullet);
        }*/

        if (Input.GetButtonDown("Fire1") && sis1 ==true)
        {
            anim.SetTrigger("Shoot");
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray))
                 Instantiate(bullet, transform.position, transform.rotation);
            moveSpeed = 0;
            //transform.LookAt(Input.mousePosition);
            // BallThrow();
        }
        else { moveSpeed = 100; }
        if(Input.GetButtonDown("Fire1") && sis0 == true)
        { moveSpeed = 200;
            anim.SetTrigger("Shoot");
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray))
                Instantiate(bullet0, transform.position, transform.rotation);
            moveSpeed = 0;
        }
        //float midPount = (transform.position = Camera.main.transform.position).magnitude * 0.5f;

        //transform.LookAt(mouseraye.origin + mouseraye.direction * midPount);




        if (Input.anyKey)
        {
            Move();
         }







            if (sis0 == false)
        {
            sis0Obj.SetActive(false);


            lifebar.fillAmount = sis1Life / 100;




            //boxcol2D.size = new Vector2(1.6f, 8.11f);
            //boxcol2D.offset = new Vector2(-0.072f, 1.30f);

            //sis0img.sprite = sis1img.sprite;






        }
        else
        {
            lifebar.fillAmount = sis0Life / 100;


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

        if (sis0Life >= 0 || sis1Life >= 0)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {


                ChangeHud();
                //usar bilboard para ver las imagenes a la camara siempre al frente 



            }
        }


    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;

    }
    void ChangeHud()
    {
        sis0 = !sis0;
        sis1 = !sis1;

        Sprite tmp = sis0img.sprite;
        sis0img.sprite = sis1img.sprite;
        sis1img.sprite = tmp;
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {

            if(sis1==true)
            {
                sis1Life-=10;
            }
            else if(sis0==true)
            {
                sis0Life-=10;
            }

        }
    }

    void BallThrow()
    {

        Vector3 myPos = transform.position;
        float dist = Camera.main.transform.position.y - myPos.y;
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        Vector3 dir = Camera.main.ScreenToWorldPoint(new Vector3(x, y, dist)) - myPos;
        GameObject projectile = (GameObject)Instantiate(bullet);

        Rigidbody rigidbody = projectile.GetComponent<Rigidbody>();
        rigidbody.velocity = dir.normalized * 5.0f;

        Vector3.RotateTowards(projectile.transform.forward, dir, 5.0f * Time.deltaTime, 0.0f);
    }

    IEnumerator Example()
    {
        
        yield return new WaitForSeconds(3);
        primerdialogo.SetActive(false);
    }
}
