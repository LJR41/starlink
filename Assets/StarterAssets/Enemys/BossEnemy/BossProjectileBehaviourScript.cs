using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileBehaviourScript : MonoBehaviour
{

    public Transform playerTransform;
    GameObject playerObject;
    public Player _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        FindPlayer();

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


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            int damgeOutput = 60;
            _player.TakeDamage(damgeOutput);
            UnityEngine.Debug.Log("Projectile touched the player!");
            Destroy(this.gameObject);
            
        }
        
    }
}
