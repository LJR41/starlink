using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{   
    [Header("------------------Health Variables-------------------")]
    [SerializeField] float health = 50f;
    public float _Health
    {
        get { return health; }
        set { _Health = value;}
    }

    

    [SerializeField] int damgeOutput = 2;
    [SerializeField] float attackCooldown = 4f;
    [SerializeField] float _lastAttackTime;

    [Header("------------------State Bools-------------------")]

    [SerializeField] bool attackState;
    public bool _attackState
    {
        get { return attackState;}
        set { attackState = value;}
    }
    [SerializeField] bool chasingState;
    [SerializeField] bool patrolState;
    [SerializeField] bool idelState;


    [Header("------------------------------------")]
    public Transform playerTransform;
    GameObject playerObject;
    public Player _player;


    public float raycastDistance = 1.0f;
    

    public Transform patrolRoute;
    
    public List<Transform> locations;


  

    private int locationIndex = 0;
    private NavMeshAgent agent;

    public void Awake()
    {

        FindPlayer();
        FindSetPatrolRoute();

        InitializePatrolRoute();

        playerTransform = GameObject.Find("Player").transform;
        
        agent = GetComponent<NavMeshAgent>();

        MoveToNextPatrolLocation();

    }

     void Start()
     {
        patrolState = true;
        ;
        
       
     }

  



    private void FixedUpdate()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {

            if (Time.time - _lastAttackTime < attackCooldown) return;

            if (hit.collider.CompareTag("Player"))
            {
                _player.TakeDamage(damgeOutput);
                UnityEngine.Debug.Log("Enemy touched the player!");
                _lastAttackTime = Time.time;
            }

                UnityEngine.Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);



        }


    }

    void LateUpdate()
    {
    }

    public void Update()
     {

        UpDateState();
       
        
     }



    public virtual void UpDateState()
    {
        
       
        if (patrolRoute != null)
        {

            if (patrolState == true)
            {
                //print("PatrolState Active");

                if (agent.remainingDistance < 0.2f && !agent.pathPending)
                    MoveToNextPatrolLocation();
            }

            if (attackState == true)
            {

                //print("AttackState Active");
                agent.destination = playerTransform.position;
            }
        }
       
    

    }

    public virtual void FindSetPatrolRoute()
    {
        
        if (patrolRoute == null)
        {
            patrolRoute = patrolRoute.Find("PatrolRoute").transform;
        }
        else
        {
            UnityEngine.Debug.LogError("PatrolRoute not found!");
            
        }

       
       



        }

        public void FindPlayer()
        {
            playerTransform = GameObject.Find("Player").transform;
            if (playerTransform == null)
            {
                 UnityEngine.Debug.LogError("Player not found!");
            }
            else
            {
                playerObject = playerTransform.gameObject;
                _player = playerObject.GetComponent<Player>();
                if (_player == null)
                {
                    UnityEngine.Debug.LogError("Player component not found on Player object!");
                }
            }
        }




    public virtual void MoveToNextPatrolLocation()
    {
        patrolState = true;
        if (locations.Count == 0) return;

        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;

    }

   public virtual void InitializePatrolRoute()
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

    public virtual void EnemyDeath()
    {
        UnityEngine.Debug.Log("Death");
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter(Collider otherCollider)
    {
        if(otherCollider.name == "Player" 
        || otherCollider.name == "Bullet")
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
