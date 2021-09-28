using Managers;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsPit;
    [SerializeField] private LayerMask whoIsEnemy;

    private SceneController sceneControl;
    private HealthManager healthManager;

    private void Start()
    {
        sceneControl = GetComponent<SceneController>();
        healthManager = GetComponent<HealthManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pit"))
        {
            healthManager.ReduceLives();
            sceneControl.ResetScene();
        }

        if (other.CompareTag("Enemy"))
        {
            healthManager.ReduceLives();
        }
    }
}