using System;
using UnityEngine;

public class PushOBJ : MonoBehaviour{
    [SerializeField] private float forceMagnitude;
    private Vector3 currentPosition;

    private void Start(){
        forceMagnitude *= 0.1f;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit){
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null){
            currentPosition = transform.position;
            Vector3 forceDirection = hit.gameObject.transform.position - currentPosition;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection * forceMagnitude, currentPosition, ForceMode.Impulse);
        }
    }
}