using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRotation : MonoBehaviour
{
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    private float _speed = 1f;

    private void OnMouseDrag()
    {
        float xAxisRotation = SetAxis(MouseX);
        float yAxisRotation = SetAxis(MouseY);

        RotateObject(Vector3.down, xAxisRotation);
        RotateObject(Vector3.right, yAxisRotation);
    }

    private float SetAxis(string name)
    {
       return Input.GetAxis(name) * _speed;
    }

    private void RotateObject(Vector3 direction, float axis)
    {
        transform.Rotate(direction, axis);
    }
}
