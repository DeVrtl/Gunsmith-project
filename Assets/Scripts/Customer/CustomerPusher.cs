using UnityEngine;

public class CustomerPusher : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    public void Enable()
    {
        enabled = true;
    }
}
