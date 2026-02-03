using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private int _mouseButtonIndex = 0;

    public event Action<Vector2> Clicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButtonIndex))
        {
            Clicked?.Invoke(Input.mousePosition);
        }
    }
}