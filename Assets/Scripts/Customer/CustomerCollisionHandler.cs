using UnityEngine;
using UnityEngine.Events;

public class CustomerCollisionHandler : MonoBehaviour
{
    public event UnityAction Passed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ShopTrigger shop))
        {
            Passed?.Invoke();
            shop.gameObject.SetActive(false);
        }
    }
}
