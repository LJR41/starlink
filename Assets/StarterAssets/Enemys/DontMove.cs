using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontMove : MonoBehaviour
{


    new Rigidbody rigidbody;
    public Vector3 position, velocity, angularVelocity;
    public bool isColliding;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!isColliding)
        {
            position = rigidbody.position;
            velocity = rigidbody.velocity;
            angularVelocity = rigidbody.angularVelocity;
        }
    }

    void LateUpdate()
    {
        if (isColliding)
        {
            rigidbody.position = position;
            rigidbody.velocity = velocity;
            rigidbody.angularVelocity = angularVelocity;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
            isColliding = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
            isColliding = false;
    }
}
