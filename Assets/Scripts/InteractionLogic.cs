using UnityEngine;

public class InteractionLogic : MonoBehaviour
{
    [Header("Services")]
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _inputReader.OnInteract += HandleInteraction;
    }

    private void OnDisable()
    {
        _inputReader.OnInteract -= HandleInteraction;
    }

    private void HandleInteraction()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                ProcessCube(cube);
            }
        }
    }

    private void ProcessCube(Cube cube)
    {
        if (Random.value <= cube.SplitChance)
        {
            var newCubes = _spawner.SpawnClones(cube);
            _exploder.Explode(newCubes, cube.transform.position);
        }

        _spawner.Despawn(cube);
    }
}