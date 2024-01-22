using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 7f;

    Transform target;
    Rigidbody2D rb;
    
    float flip = 1f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        var dir = Mathf.Sign(target.position.x - transform.position.x);
        
        //transform.position = Vector2.MoveTowards(transform.position, target.position, dir * speed * Time.deltaTime);
        rb.velocity = new Vector2(dir * flip * speed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Mapa"))
        {
            Debug.Log("Zed");
            if (rb.velocity.y == 0)
            {
                rb.velocity = new Vector2(0, jumpForce);
            }
        }
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player");
            flip *= -1;
        }
    }
}
