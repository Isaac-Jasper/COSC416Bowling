using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent OnSpacePressed = new UnityEvent();
    public UnityEvent OnResetPressed = new UnityEvent();

    [SerializeField]
    private float moveTolerance = 0.1f;

    void Update() {
        Vector3 moveDir = Input.GetAxis("Horizontal")*Vector3.right;

        OnMove?.Invoke(moveDir);

        if (Input.GetButtonDown("Bowl")) {
            OnSpacePressed?.Invoke();
        }

        if (Input.GetButtonDown("Reset")) {
            OnResetPressed?.Invoke();
        }
    }
}
