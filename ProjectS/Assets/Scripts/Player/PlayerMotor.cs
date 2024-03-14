using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;
    private Vector3 curentVelocity;
    public float speed = 5f;
    [SerializeField] private float gravity = 9.81f;



    public void Moving(Vector2 input)
    {
        Vector3 moveInDirection = Vector3.zero;
        moveInDirection.x = input.x;
        moveInDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveInDirection * speed) * Time.deltaTime);
    }

    public void RotatingLeft()
    {
        transform.RotateAround(left.transform.position, Vector3.up, -20 * Time.deltaTime);
    }
    public void RotatingRight()
    {
        transform.RotateAround(right.transform.position, Vector3.up, 20 * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        controller.Move(Vector3.down * (gravity * Time.deltaTime));
        
    }
}
