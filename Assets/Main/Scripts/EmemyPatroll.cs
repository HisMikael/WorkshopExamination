using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class EmemyPatroll : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform[] movePoints;
    Rigidbody2D rb;
    [SerializeField] int moveIndex;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(movePoints[moveIndex].position, rb.position) < 0.1f)
        {
            moveIndex++;
            moveIndex %= movePoints.Length;
        }
        rb.MovePosition(Vector2.MoveTowards(rb.position, movePoints[moveIndex].position, speed*Time.deltaTime));
    }
}
