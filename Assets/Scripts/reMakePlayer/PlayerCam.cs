using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    private float sensX;
    private float sensY;
    public static float sens = 150f; 

    public Transform orientation;
    float xRotation;
    float yRotation;

    private void Update() {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens;

        yRotation += mouseX;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
