using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Action<Vector2> OnMoveInput;
    public Action<bool> OnSprintInput;
    public Action OnJumpInput;
    public Action OnClimbInput;
    public Action OnCancelClimb;

    private void Update()
    {
        CheckJumpInput();
        CheckSprintInput();
        CheckCrouchInput();
        CheckChangePOVInput();
        CheckClimbInput();
        CheckCancelInput();
        CheckPunchInput();
        CheckMainMenuInput();
        CheckMovementInput();
    }

    private void CheckMovementInput()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        Vector2 inputAxis = new Vector2(horizontalAxis, verticalAxis);
        if (OnMoveInput != null)
        {
            OnMoveInput(inputAxis);
        }
    }

    private void CheckJumpInput()
    {
        bool isPressJumpInput = Input.GetKeyDown(KeyCode.Space);
        if (isPressJumpInput)
        {
            OnJumpInput();
        }
    }

    private void CheckSprintInput()
    {
        bool isHoldSprintInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        OnSprintInput?.Invoke(isHoldSprintInput);
    }

    private void CheckCrouchInput()
    {
        bool isPressCrouchInput = Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl);
        if (isPressCrouchInput)
        {
            Debug.Log("Crouch");
        }
    }

    private void CheckChangePOVInput()
    {
        bool isPressChangePOVInput = Input.GetKeyDown(KeyCode.Q);
        if (isPressChangePOVInput)
        {
            Debug.Log("Change POV");
        }
    }

    private void CheckClimbInput()
    {
        bool isPressClimbInput = Input.GetKeyDown(KeyCode.E);
        if (isPressClimbInput)
        {
            OnClimbInput();
        }
    }

    private void CheckCancelInput()
    {
        if (Input.GetKeyDown(KeyCode.C))
            if (OnCancelClimb != null)
            {
                OnCancelClimb();
            }
    }

    private void CheckPunchInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Debug.Log("Punch");
    }

    private void CheckMainMenuInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Debug.Log("Back To Main Menu");
    }
}










