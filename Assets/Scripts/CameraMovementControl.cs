using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementControl : MonoBehaviour
{
    [SerializeField] private Transform _objectFollowed;

    [Range(0, 1)]
    [SerializeField] private float _smoothTime;

    [SerializeField] private Vector3 _cameraOffset = new Vector3(0f, 0f, -10f);

    [SerializeField] private Vector2 _minMoveLimit;
    [SerializeField] private Vector2 _maxMoveLimit;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 target_pos = _objectFollowed.position + _cameraOffset;
        // target_pos = new Vector3(Mathf.Clamp(target_pos.x, _minMoveLimit.x, _maxMoveLimit.x), Mathf.Clamp(target_pos.y, _minMoveLimit.y, _maxMoveLimit.y), target_pos.z);
        transform.position = Vector3.SmoothDamp(transform.position, target_pos, ref velocity, _smoothTime);
    }
}
