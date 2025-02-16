using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;

    private Rigidbody rb;

    void Start() {
        inputManager.OnMove.AddListener(MovePlayer);
        rb = GetComponent<Rigidbody>();
    }

    private void MovePlayer(Vector2 dir) {
        //rb.AddForce(speed * dir); I prefer immediate acceleration with no speed build-up
        rb.linearVelocity = speed * dir;
    }
}
