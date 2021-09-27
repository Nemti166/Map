using UnityEngine;

namespace Game.GameCamera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private int _step;

        private Vector3 _startMousePosition;
        private bool _move;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            if (_move == true)
            {
                transform.Translate(ShiftPosition() * _step * Time.deltaTime);
            }

            ControllCamera();
        }

        private Vector3 ShiftPosition()
        {
            float X = _camera.ScreenToViewportPoint(Input.mousePosition).x - _startMousePosition.x;
            float Y = _camera.ScreenToViewportPoint(Input.mousePosition).y - _startMousePosition.y;

            _startMousePosition = _camera.ScreenToViewportPoint(Input.mousePosition);

            Vector3 shift = new Vector3(-X, -Y).normalized;

            return shift;
        }

        private void ControllCamera()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _startMousePosition = _camera.ScreenToViewportPoint(Input.mousePosition);
                _move = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _move = false;
            }
        }
    }
}
