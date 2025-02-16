using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Rigidbody rb;

    private bool isBallLaunched;

    void Start() {
        Init();
    }

    private void Init() {
        if (rb == null) rb = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        rb.isKinematic = true;
    }

    private void LaunchBall() {
        if (isBallLaunched) return;
        isBallLaunched = true;
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
