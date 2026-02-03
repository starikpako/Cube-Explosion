using UnityEngine;

public class ClickDistributor : MonoBehaviour
{
    [Header("Services")]
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _inputReader.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _inputReader.Clicked -= OnClicked;
    }

    private void OnClicked(Vector2 screenPosition)
    {
        Cube hitCube = _raycaster.RaycastForCube(screenPosition);

        if (hitCube != null)
        {
            ProcessCube(hitCube);
        }
    }

    private void ProcessCube(Cube cube)
    {
        if (Random.value <= cube.SplitChance)
        {
            var clones = _spawner.SpawnClones(cube);
            _exploder.Explode(clones, cube.transform.position);
        }

        _spawner.Despawn(cube);
    }
}