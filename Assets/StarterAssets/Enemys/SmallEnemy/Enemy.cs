using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{   
    [SerializeField] float health;

    public Transform player;


    public Transform patrolRoute;
    public List<Transform> locations;


    private int locationIndex = 0;
    private NavMeshAgent agent;


    private void Awake()
    {
        InitializePatrolRoute();
        player = GameObject.Find("Player").transform;
        if (patrolRoute == null) patrolRoute = patrolRoute.transform.Find("PatrolRoute");
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPatrolLocation();
    }

     void Start()
    {
        
        
       
    }


     void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending) MoveToNextPatrolLocation();
        
    }



    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0) return;

        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;

    }

    void InitializePatrolRoute()
    {
        foreach ( Transform child in patrolRoute)
        {
            locations.Add(child);

        }

    }


    public void TakeDamage(float damage)
    {
        if(health > 0)
        {
            health -= damage;
        if(health<=0)
        {
            EnemyDeath();
        };
        UnityEngine.Debug.Log("Hit");
        }
        
    }
    // Start is called before the first frame update

    void EnemyDeath()
    {
        UnityEngine.Debug.Log("Death");
    }

    public void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.name == "Player")
        {
            agent.destination = player.position;
            print("Player Found Attacking!");
        }

        
    }
}
