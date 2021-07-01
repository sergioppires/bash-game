using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate() {
        Vector3 newPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
        transform.LookAt(target);
    }


}
