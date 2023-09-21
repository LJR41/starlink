using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] float worldTime;
    public float _WorldTime
    {
        get { return worldTime; }
        set { _WorldTime = value; }

    }

    [SerializeField] float acceleration = 5f;
   

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        worldTime += Time.deltaTime;
        
    }
}
