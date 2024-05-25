using System;
using UnityEngine;
using UnityEngine.InputSystem;

//[ActionMap].[Action].performed/cancled/hold += [context] => what it should do 
public class PlayerController : MonoBehaviour{
    public bool playerCanMove = true;
    private PlayerInputActions playerInputActions;
    private InputAction drive;
    [SerializeField] private PlayerMotor playerMotor;
    [SerializeField] private bool isTurningLeft, isTurningRight;

    private void Awake(){
        playerInputActions = new PlayerInputActions();
        playerInputActions.ByBike.TurnaroundLeftStart.performed += ctx => TurningLeftPressed(); //nene Error
        playerInputActions.ByBike.TurnaroundLeftEnd.performed += ctx => TurningLeftReleased();

        playerInputActions.ByBike.TurnaroundRightStart.performed += ctx => TurningRightPressed();
        playerInputActions.ByBike.TurnaroundRightEnd.performed += ctx => TurningRightReleased();
    }


    private void FixedUpdate(){
        //Movement

        if (playerCanMove){
            playerMotor.Moving(drive.ReadValue<Vector2>());
            if (isTurningLeft)
                playerMotor.RotatingLeft();

            if (isTurningRight)
                playerMotor.RotatingRight();
        }

    }

    #region EnableAndDisable

    private void OnEnable(){
        drive = playerInputActions.ByBike.Drive;
        drive.Enable();
        playerInputActions.ByBike.TurnaroundLeftEnd.Enable();
        playerInputActions.ByBike.TurnaroundLeftStart.Enable();
        playerInputActions.ByBike.TurnaroundRightEnd.Enable();
        playerInputActions.ByBike.TurnaroundRightStart.Enable();
    }


    private void OnDisable(){
        drive.Disable();
        playerInputActions.ByBike.TurnaroundLeftEnd.Disable();
        playerInputActions.ByBike.TurnaroundLeftStart.Disable();
        playerInputActions.ByBike.TurnaroundRightEnd.Disable();
        playerInputActions.ByBike.TurnaroundRightStart.Disable();
    }

    #endregion

    private void TurningLeftPressed(){
        Debug.Log("True left");
        isTurningLeft = true;
    }

    private void TurningLeftReleased(){
        Debug.Log("False left");
        isTurningLeft = false;
    }

    private void TurningRightPressed(){
        Debug.Log("True right");

        isTurningRight = true;
    }

    private void TurningRightReleased(){
        Debug.Log("False right");
        isTurningRight = false;
    }
}