using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [SerializeField] float followSpeed;
    [SerializeField] float distance;

    public Vector3 offset = new Vector3(0, 0, 0);

    private Vector3 targetPosition;

    private void LateUpdate()
    {
        targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed);
        transform.LookAt(target);
    }
}
