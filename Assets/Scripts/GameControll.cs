using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _inputHandler.OnCubeClicked += ProcessCubeInteraction;
    }

    private void OnDisable()
    {
        _inputHandler.OnCubeClicked -= ProcessCubeInteraction;
    }

    private void ProcessCubeInteraction(Cube cube)
    {
        if (Random.value <= cube.SplitChance)
        {
            var newCubes = _spawner.SpawnClones(cube);

            _exploder.Explode(newCubes, cube.transform.position);
        }

        Destroy(cube.gameObject);
    }
}