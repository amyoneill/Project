using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // The player vehicle to follow
    public Vector3 offset = new Vector3(0f, 5f, -10f);  // Offset position from the player
    public float followSpeed = 5f;      // Speed at which the camera follows the player
    public float rotateSpeed = 5f;      // Speed at which the camera rotates to follow the player

    void LateUpdate()
    {
        if (target == null) return;

        // Smoothly follow the target position with offset
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Smoothly rotate the camera to face the target
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
}
