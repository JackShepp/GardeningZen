using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation around the plane
    public Vector3 rotationAxis = Vector3.up; // Axis of rotation (up for vertical rotation)

    void Update()
    {
        // Rotate the object around the parent (teleportation plane)
        transform.RotateAround(transform.parent.position, rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
