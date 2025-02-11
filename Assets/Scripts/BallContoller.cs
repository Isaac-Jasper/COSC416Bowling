using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Rigidbody rb;

    private bool isBallLaunched;

    void Start() {
        if (rb == null) rb = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    private void LaunchBall() {
        if (isBallLaunched) return;
        isBallLaunched = true;
        
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
