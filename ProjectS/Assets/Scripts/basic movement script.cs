using UnityEngine;

public class basicmovementscript : MonoBehaviour
{
    public float speed = 5.0f;
    
void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * (speed * horizontalInput * Time.deltaTime));
        transform.Translate(Vector3.forward * (speed * verticalInput * Time.deltaTime));
    }
}
