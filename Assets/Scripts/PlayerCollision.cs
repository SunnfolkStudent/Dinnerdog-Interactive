using Managers;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public string whatIsPit;
    public string whoIsEnemy;
    private PlayerInput _input;
    private PlayerMovement _movement;

    private SceneController sceneControl;
    private HealthManager healthManager;

    private void Start()
    {
        sceneControl = GetComponent<SceneController>();
        healthManager = GetComponent<HealthManager>();
        _input = GetComponent<PlayerInput>();
        _movement = GetComponent<PlayerMovement>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pit") && !_movement.isDashing)
        { 
            print("Die");
            healthManager.ReduceLives();
            sceneControl.ResetScene();
        }
        
        if (other.CompareTag("Enemy"))
        {
            healthManager.ReduceLives();
        }
    }
}