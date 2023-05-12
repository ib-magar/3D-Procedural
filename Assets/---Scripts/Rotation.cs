
using UnityEngine;

public class Rotation : MonoBehaviour
{
    
    
    public float rotationSpeed = 10f;
    public float minVerticalAngle = -60f;
    public float maxVerticalAngle = 60f;

    private float xRotation = 0f;

    void Update()
    {
        // Get the horizontal and vertical mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calculate the amount of rotation based on mouse movement and time
        float horizontalRotationAmount = mouseX * rotationSpeed * Time.deltaTime;
        float verticalRotationAmount = mouseY * rotationSpeed * Time.deltaTime;

        // Rotate the object around its Y-axis
        
        transform.Rotate(Vector3.up, horizontalRotationAmount);
        
// Calculate the new X rotation based on vertical mouse movement

        xRotation -= verticalRotationAmount;
        xRotation = Mathf.Clamp(xRotation, minVerticalAngle, maxVerticalAngle);

        
// Rotate the object around its X-axis

        //transform.localRotation = Quaternion.Euler(xRotation, transform.localRotation.eulerAngles.y, transform.localRotation.eulerAngles.z);
    }
}
