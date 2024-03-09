using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSpriteToCam : MonoBehaviour
{
    // Start is called before the first frame update
    //find camera
    public Camera cam;
    void Start()
    {
        //find main camera
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //every frame, turn the sprite to face the camera
        transform.LookAt(cam.transform);
    }
}
