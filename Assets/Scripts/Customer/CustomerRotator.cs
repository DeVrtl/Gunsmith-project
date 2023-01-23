using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerRotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _target;

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(0, _target, 0, 0), Time.deltaTime * _speed);
    }
}
