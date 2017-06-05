using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {
    
    public Transform[] points;
    public int destPoint = 0;
    public UnityEngine.AI.NavMeshAgent agent;

    public Transform destination;

    public bool chase = false;
    public bool patrol = true;

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

    }


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, destination.position);

        //Debug.Log(distance);

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
}


 


   





    

