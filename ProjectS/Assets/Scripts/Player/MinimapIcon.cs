using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class MinimapIcon : MonoBehaviour
{
    public Image playImage;
    public Camera playerCamera;
    public int IDKVALUE;
    void Update()
    {
        //update the icon rotation with the player cameras rotation and add 45 degrees to the z axis
        playImage.rectTransform.transform.eulerAngles = new Vector3(0, 0, -playerCamera.transform.eulerAngles.y + 135);
        
    }
}

