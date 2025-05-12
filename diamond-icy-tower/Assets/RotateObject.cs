using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Rotation speed for each axis
    //public float rotationSpeedX = 130f;
    public float rotationSpeedY = 150f;
    //public float rotationSpeedZ = 120f;

    void Update()
    {
        // Rotate the object around the X, Y, and Z axes
        transform.Rotate(Vector3.up * rotationSpeedY * Time.deltaTime);
    }
}
