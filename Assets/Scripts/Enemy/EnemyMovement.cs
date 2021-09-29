using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    public float _lastetDirectionChangeTime;
    public float _directionChangeTime = 1;
    public float _characterVelocity = 3f;
    public Vector2 _movementDirection;
    public Vector2 _movementPerSecond;


    private void Start()
    {
        _lastetDirectionChangeTime = 0f;
        calculateNewMovementVector();
    }

    void calculateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        _movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        _movementPerSecond = _movementDirection * _characterVelocity;
    }
    
    private void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - _lastetDirectionChangeTime > _directionChangeTime)
        {
            _lastetDirectionChangeTime = Time.time;
            calculateNewMovementVector();
        }
        //move enemy
        transform.position = new Vector2(transform.position.x + (_movementPerSecond.x * Time.deltaTime), 
            transform.position.y + (_movementPerSecond.y * Time.deltaTime));
    }
    
    //Changes the directions that the enemy moves when colliding with walls
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Wall"))
        {
            calculateNewMovementVector();
        }
        if (other.transform.CompareTag("Pit"))
        {
            calculateNewMovementVector();
        }
    }
}