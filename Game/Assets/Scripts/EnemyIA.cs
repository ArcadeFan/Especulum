using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {


    public int hp;
    public Transform[] points;
    public int destPoint = 0;
    public UnityEngine.AI.NavMeshAgent agent;

    public Transform destination;

    public bool chase = false;
    public bool patrol = true;
    public GameObject ebullet;
    public float projectileSpeed;

    public float cd;

    //private NavMeshAgent agent;

    void Start()
    {
        //agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        //agent.autoBraking = false;

        GotoNextPoint();
        hp = 25;

    }


    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(hp);

        float distance = Vector3.Distance(transform.position, destination.position);

        Debug.Log(cd);

        if (chase == true && patrol == false)
        {
            agent.SetDestination(destination.position);

            if (distance <= 30.0f)
            {

                Debug.Log("rango de ataque");


            }
        }
        

        if(patrol==true && chase == false)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }

        }

        if (chase==true)
        {

            Shoot();

            

        }
      
         

    }

    IEnumerator Example()
    {
        
        yield return new WaitForSeconds(3);
        chase = false;
        patrol = true;
        CancelInvoke("Shoot");

        
    }
    






    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            chase = true;
            patrol = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            StartCoroutine(Example());
        }

        if(other.tag=="PBullet")
        {
            hp--;
        }
        if (other.tag == "PHBullet")
        {
            hp-=10;
        }
    }

    void Shoot()
    {
        cd -= Time.deltaTime;
        if(cd<=0)
        {
            Instantiate(ebullet, transform.position, transform.rotation);
            cd = 1f;
        }


    }
}


 


   





    

