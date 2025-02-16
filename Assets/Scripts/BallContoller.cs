using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform launchIndicator;
    [SerializeField] private Rigidbody rb;

    private bool isBallLaunched;

    void Start() {
        Init();
    }

    private void Init() {
        if (rb == null) rb = GetComponent<Rigidbody>();
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        ResetBall();
    }

    private void LaunchBall() {
        if (isBallLaunched) return;
        isBallLaunched = true;
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }

    public void ResetBall() {
        launchIndicator.gameObject.SetActive(true);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        rb.isKinematic = true;
        isBallLaunched = false;
    }
}
