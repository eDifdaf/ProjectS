using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    #region Changable values

    [Header("Maximal Geschwindigkeiten")] 
    [SerializeField] private float maxDrivingForce = 1000f;

    [Header("Maximal Bremsstärke")] 
    [SerializeField] private float maxBreakingForce = 40000f;
    
    [Header("Kurven Winkel")]
    [SerializeField] private float maxHorizontalAngle = 45f;
    
    [Header("Hinterrad Rotation = WheelColliderSpeed / diesen Value")]
    [SerializeField] private float backWheelRotationDividend = 30f;
    #endregion

    #region Inputs
    [SerializeField] public float breakInput, driveInput, steerInput;
    #endregion

    #region Static Variables
    [SerializeField] private WheelCollider frontWheelCollider, backWheelCollider;
    [SerializeField] private Transform backWheelTransform;
    #endregion
    
    #region Upgrades
    [SerializeField] private ESpeedUpgrades currentUpgrade = ESpeedUpgrades.BaseUpgrade;
    public enum ESpeedUpgrades
    {
        BaseUpgrade,
        FirstUpgrade,
        SecondUpgrade,
        LastUpgrade
    }
 
    public float GetItemRarityPercentage(ESpeedUpgrades rarity)
    {
        switch (rarity)
        {
            case ESpeedUpgrades.BaseUpgrade :
                return 1;
            case ESpeedUpgrades.FirstUpgrade :
                return (float)1.5;
            case ESpeedUpgrades.SecondUpgrade :
                return (float)1.75;
            case ESpeedUpgrades.LastUpgrade :
                return 2;
        }

        return 0;
    }
    #endregion


    
    private void FixedUpdate()
    {
        
        Drive();
        Break();
        KeepUpright();
        Steer();
        WheelRotationUpdate();
    }


    #region Driving
    
    public void Drive()
    {
        backWheelCollider.motorTorque = maxDrivingForce * driveInput * GetItemRarityPercentage(currentUpgrade);
    }
    public void Break()
    {
        backWheelCollider.brakeTorque = maxBreakingForce * breakInput * GetItemRarityPercentage(currentUpgrade);
    }
    
    #endregion

    #region Steering
    
    public void Steer()
    {
        frontWheelCollider.steerAngle = maxHorizontalAngle * steerInput;
    }
    
    #endregion
    
    

    #region WheelRotationUpdate

    private void WheelRotationUpdate()
    {
        //Set the X-Rotation of the backWheelTransform to the X-Rotation of the backWheelCollider divided by the backWheelRotationDividend
        backWheelTransform.Rotate(new Vector3(0, 0, -backWheelCollider.rotationSpeed/backWheelRotationDividend));
    }
    
    #endregion

    #region FixingBikeRotation
    
    private void KeepUpright()
    {
        //Set the rotation to keep the bike upright while Driving and Steering
        Quaternion currentRotation = transform.rotation;
        Vector3 currentEulerAngles = currentRotation.eulerAngles;
        currentEulerAngles.z = 0; //Set the Z rotation to zero
        transform.rotation = Quaternion.Euler(currentEulerAngles);
    }
    
    #endregion
}