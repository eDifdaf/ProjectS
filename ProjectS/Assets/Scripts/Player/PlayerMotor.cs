using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
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

    private void FixedUpdate()
    {
        controller.Move(Vector3.down * (gravity * Time.deltaTime));
    }
}
