using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSmallEnemy : Enemy
{
    private GameObject routeGameObject;



    // Start is called before the first frame update
    void Awake()
    {
        FindSetPatrolRoute();
        
    }

    public override void FindSetPatrolRoute()
    {
        base.FindSetPatrolRoute();
        patrolRoute = GameObject.Find("First S Enemy1_PatrolRoute").transform;
        if (patrolRoute == null)
        {
            UnityEngine.Debug.LogError("PatrolRoute not found!");
        }
        else
        {

            routeGameObject = patrolRoute.gameObject;


        }
    }

}
