using UnityEngine;

public class CameraBoundaryObject : MonoBehaviour
{
    private BoxCollider2D _itsCollider;
    private CameraMovementControl _mainCameraController;

    private void Start()
    {
        _itsCollider = GetComponent<BoxCollider2D>();
        _mainCameraController = Camera.main.GetComponent<CameraMovementControl>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (_itsCollider.offset.x >= 0)
            {
                _mainCameraController.SetNewLimit(float.NegativeInfinity, transform.position.x);
            }
            else
            {
                _mainCameraController.SetNewLimit(transform.position.x, float.PositiveInfinity);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _mainCameraController.SetNewLimit(float.NegativeInfinity, float.PositiveInfinity);
        }
    }
}
