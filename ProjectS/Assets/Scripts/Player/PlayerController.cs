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
        playerInputActions.OnBike.Accelerate.performed += ctx => playerMotor.forcePower = ctx.ReadValue<Vector2>().y;
        playerInputActions.OnBike.Accelerate.canceled += ctx => playerMotor.forcePower = ctx.ReadValue<Vector2>().y;
        //playerInputActions.OnBike.Accelerate.canceled += ctx => playerMotor.bikeRb.velocity = UnityEngine.Vector3.zero;
        
        //Steering
        playerInputActions.OnBike.Steer.performed += ctx => playerMotor.currentAngle = ctx.ReadValue<Vector2>().x;
        playerInputActions.OnBike.Steer.canceled += ctx => playerMotor.currentAngle = ctx.ReadValue<Vector2>().x;
        
        
        //Interactions
        playerInputActions.OnBike.Interact.performed += ctx => npc.PlayerInteract();
        playerInputActions.OnBike.Interact.performed += ctx => sender.PlayerInteract();
    }


<<<<<<< Updated upstream
    
=======
    private void FixedUpdate()
    {
        //Movement
        playerMotor.Moving(drive.ReadValue<Vector2>());


    }

>>>>>>> Stashed changes
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