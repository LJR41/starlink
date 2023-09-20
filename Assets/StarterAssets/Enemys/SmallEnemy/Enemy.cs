using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{   
    [SerializeField] float health = 50f;
    public float _Health
    {
        get { return health; }
        set { _Health = value;}
    }

    [SerializeField] int damgeOutput = 15;
    [SerializeField] bool attackState;
    [SerializeField] bool chasingState;
    [SerializeField] bool patrolState;
    [SerializeField] bool idelState;

    public Transform playerTransform;
    GameObject playerObject;
    public Player _player;


    public float raycastDistance = 1.0f;
    //public LayerMask enemyLayer;

    public Transform patrolRoute;
    public List<Transform> locations;


    private int locationIndex = 0;
    private NavMeshAgent agent;

    private void Awake()
    {
        if (_player == null) _player = playerObject.GetComponent<Player>();
        InitializePatrolRoute();
        playerTransform = GameObject.Find("Player").transform;
        if (patrolRoute == null) patrolRoute = patrolRoute.transform.Find("PatrolRoute");
        agent = GetComponent<NavMeshAgent>();

        MoveToNextPatrolLocation();

    }

     void Start()
     {
        patrolState = true;
        
        
       
     }





    private void FixedUpdate()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {

            if (hit.collider.CompareTag("Player"))
            {
                _player.TakeDamage(damgeOutput);
                UnityEngine.Debug.Log("Enemy touched the player!");

            }

                UnityEngine.Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

        }




    }
    void Update()
     {

        
       
        if (patrolState == true)
        {
            //print("PatrolState Active");

            if (agent.remainingDistance < 0.2f && !agent.pathPending) 
                MoveToNextPatrolLocation();
        }

        if(attackState == true)
        {

            //print("AttackState Active");
            agent.destination = playerTransform.position;
        }
        
     }



    void MoveToNextPatrolLocation()
    {
        patrolState = true;
        if (locations.Count == 0) return;

        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;

    }

    void InitializePatrolRoute()
    {
        patrolState = true;
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
            patrolState = false;

            chasingState = true;
            attackState = true;


            agent.destination = playerTransform.position;

            
            
            print("Player Found Attacking!");
        }

        
    }

    public void OnTriggerExit(Collider otherCollider)
    {

        attackState = false;
        chasingState = false;
        patrolState = true;
        
    }
}
