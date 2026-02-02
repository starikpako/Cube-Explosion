using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private int _interactionMouseButton = 0;

    public event Action OnInteract;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_interactionMouseButton))
        {
            OnInteract?.Invoke();
        }
    }
}