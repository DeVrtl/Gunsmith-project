using UnityEngine;

public class ShopExitTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _winCard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Customer customer))
        {
            _winCard.gameObject.SetActive(true);
            Destroy(customer.gameObject);
        }
    }
}
