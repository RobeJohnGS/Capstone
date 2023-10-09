using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DM_Movement : MonoBehaviour
{
    [SerializeField] private float flySpeed;
    [SerializeField] private DM_InputAction dmInputAction;
    [SerializeField] private Rigidbody rb;
    private InputAction move;
    private InputAction mouseMove;

    [SerializeField] private Vector3 moveDir = Vector3.zero;
    [SerializeField] private Vector2 mouseDir = Vector2.zero;

    private void Awake()
    {
        dmInputAction = new DM_InputAction();
    }

    private void OnEnable()
    {
        //World Movement
        move = dmInputAction.Builder.Movement;
        move.Enable();

        //Screen Movement
        mouseMove = dmInputAction.Builder.CameraMove;
        mouseMove.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        mouseMove.Disable();
    }

    void Update()
    {
        moveDir = move.ReadValue<Vector3>();
        mouseDir = move.ReadValue<Vector2>();
        Debug.Log(mouseDir);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDir.x * flySpeed, moveDir.z * flySpeed, moveDir.y * flySpeed);
    }
}
