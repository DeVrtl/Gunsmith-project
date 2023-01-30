using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _itemToSpawn;

    private void Awake()
    {
        Instantiate(_itemToSpawn);
    }
}
