using UnityEngine;
using UnityEngine.Events;


public class FallTrigger : MonoBehaviour
{
    public UnityEvent OnPinFall = new();
    public bool isPinFallen = false;

    void OnTriggerEnter(Collider col) {
        if (!col.CompareTag("Floor") || isPinFallen) return;

        isPinFallen = false;
        OnPinFall?.Invoke();
        Debug.Log($"{gameObject.name} is fallen");
    }
}
