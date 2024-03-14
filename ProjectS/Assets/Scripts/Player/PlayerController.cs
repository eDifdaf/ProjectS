using System;
using UnityEngine;
using UnityEngine.InputSystem;

//[ActionMap].[Action].performed/cancled/hold += [context] => what it should do 
public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction drive;
    [SerializeField] private PlayerMotor playerMotor;
    private bool isTurningLeft, isTurningRight;
    
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        
    }

    private void Start()
    {
        playerInputActions.ByBike.TurnaroundLeftStart.performed += ctx => TurningLeftPressed();//nene Error
        playerInputActions.ByBike.TurnaroundLeftEnd.performed += ctx => TurningLeftReleased();
        
        playerInputActions.ByBike.TurnaroundRightStart.performed += ctx => TurningRightPressed();
        playerInputActions.ByBike.TurnaroundRightEnd.performed += ctx => TurningRightReleased();
    }


    private void FixedUpdate()
    {
        //Movement
        playerMotor.Moving(drive.ReadValue<Vector2>());
        if (isTurningLeft)
        {
            
            Debug.Log("ee");
            playerMotor.RotatingLeft();
        }
        if (isTurningRight)
            playerMotor.RotatingRight();

    }

    #region EnableAndDisable
    private void OnEnable()
    {
        drive = playerInputActions.ByBike.Drive;
        drive.Enable();

        
    }
    

    private void OnDisable()
    {
        drive.Disable();

    }
    #endregion

    private void TurningLeftPressed()
    {
        Debug.Log("Truee");
        isTurningLeft = true;
    }
    private void TurningLeftReleased()
    {
        isTurningLeft = false;
    }
    private void TurningRightPressed()
    {
        isTurningRight = true;
    }
    private void TurningRightReleased()
    {
        isTurningRight = false;
    }

    


}
