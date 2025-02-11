using UnityEngine;

public class Gutter : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
        if (!col.CompareTag("Ball")) return;

        Rigidbody ballRigidBody = col.GetComponent<Rigidbody>();

        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
    }
}
