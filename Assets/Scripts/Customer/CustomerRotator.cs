using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerRotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Rotate(float targetY)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0, targetY, 0, 0), Time.deltaTime * _speed);
    }
}
