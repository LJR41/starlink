using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    [SerializeField] GameObject _smallEnemyPrefab;

    [SerializeField] bool triggered;

    [SerializeField] float _minSpawnTime;
    [SerializeField] float _maxSpawnTime;

    [SerializeField] float _timeUntillNextSpawn;

    

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered == true) Destroy(this.gameObject);
        
    }


    private void SetTimeUntillNextSpawn()
    {

    }


    private void OnTriggerEnter(Collider otherCollider)
    {
        

        if(otherCollider.tag == "Player")
        {
            triggered = true;

            _smallEnemyPrefab.SetActive(true);
            
            print("Player crossed the trigger");
        }
    }
}
