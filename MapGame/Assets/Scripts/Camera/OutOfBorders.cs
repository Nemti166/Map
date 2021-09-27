using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Helper;

namespace Game.GameCamera
{
    public class OutOfBorders : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            StayInGameArea();
        }

        private void StayInGameArea()
        {
            var camHalfHeight = _camera.orthographicSize;
            var camHalfWidth = camHalfHeight * _camera.aspect;

            var topBorder = Borders.GameBorders.Top - camHalfHeight;
            var bottomBorder = Borders.GameBorders.Bottom + camHalfHeight;            

            var leftBorder = Borders.GameBorders.Left + camHalfWidth;
            var rightBorder = Borders.GameBorders.Right - camHalfWidth;

            transform.position = new Vector2(
                Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
                Mathf.Clamp(transform.position.y, bottomBorder, topBorder));
        }
    }
}
