using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public event Action<Cube> OnCubeClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    private void HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                OnCubeClicked?.Invoke(cube);
            }
        }
    }
}