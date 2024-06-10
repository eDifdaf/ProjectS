using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    [SerializeField] private PlayerMotor playerMotor;
    public bool canMove;
    public NPC npc;
    public Sender sender;
    
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        
        //Acceleration
        playerInputActions.OnBike.Drive.performed += ctx => playerMotor.driveInput = ctx.ReadValue<Vector2>().y;
        playerInputActions.OnBike.Drive.canceled += ctx => playerMotor.driveInput = ctx.ReadValue<Vector2>().y;

        playerInputActions.OnBike.Break.performed += ctx => playerMotor.breakInput = ctx.ReadValue<float>();
        playerInputActions.OnBike.Break.canceled += ctx => playerMotor.breakInput = ctx.ReadValue<float>();

        
        //Steering
        playerInputActions.OnBike.Steer.performed += ctx => playerMotor.steerInput = ctx.ReadValue<Vector2>().x;
        playerInputActions.OnBike.Steer.canceled += ctx => playerMotor.steerInput = ctx.ReadValue<Vector2>().x;
        
        
        //Interactions
        playerInputActions.OnBike.Interact.performed += ctx => npc.PlayerInteract();
        playerInputActions.OnBike.Interact.performed += ctx => sender.PlayerInteract();
    }



    #region EnableAndDisable
    private void OnEnable()
    {
        playerInputActions.Enable();
        playerInputActions.OnBike.Interact.Enable();
    }
    
    private void OnDisable()
    {
        playerInputActions.Disable();
        playerInputActions.OnBike.Interact.Disable();
    }

    #endregion
}