using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoggoBehaviour : MonoBehaviour {

    //Posicion del jugador
    public Transform player;

    //NavMesh para seguir al jugador
    private NavMeshAgent navMesh;

    private float XDistance;
    private float YDistance;

    private Animator anim;
    private SpriteRenderer spr;


    void Start ()
    {
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Emma").transform;

    }

    void Update()
    {
        navMesh.SetDestination(player.position);

        //Holy formulas
        YDistance = Mathf.Abs(player.transform.position.z + player.transform.position.x - navMesh.transform.position.z - navMesh.transform.position.x);
        XDistance = Mathf.Abs(player.transform.position.x - player.transform.position.z - navMesh.transform.position.x + navMesh.transform.position.z);

        Debug.Log("Y: " + YDistance);
        Debug.Log("X: " + XDistance);

        if (player.transform.position.x > this.transform.position.x)
        {
            anim.SetFloat("horizontal", 1);
            spr.flipX = false;

            if(YDistance > XDistance)
            {
                anim.SetFloat("horizontal", 0);
            }

        }
        else
        {
            anim.SetFloat("horizontal", -1);
            spr.flipX = true;

            if (YDistance > XDistance)
            {
                anim.SetFloat("horizontal", 0);
            }
        }

        if(player.transform.position.z > this.transform.position.z)
        {
            anim.SetFloat("vertical", 1);
            if (YDistance < XDistance)
            {
                anim.SetFloat("vertical", 0);
            }
        }
        else
        {
            anim.SetFloat("vertical", -1);
            if (YDistance < XDistance)
            {
                anim.SetFloat("vertical", 0);
            }
        }
 

        if (navMesh.remainingDistance < 0.1)
        {
            anim.SetFloat("horizontal", 0);
            anim.SetFloat("vertical", 0);
        }
    }
}
