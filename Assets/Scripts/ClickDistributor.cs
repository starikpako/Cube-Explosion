using UnityEngine;

public class ClickDistributor : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable() => _inputReader.Clicked += OnClicked;
    private void OnDisable() => _inputReader.Clicked -= OnClicked;

    private void OnClicked(Vector2 screenPosition)
    {
        Cube hitCube = _raycaster.RaycastForCube(screenPosition);

        if (hitCube != null)
        {
            if (Random.value <= hitCube.SplitChance)
            {
                var clones = _spawner.SpawnClones(hitCube);

                _exploder.ExplodeClones(clones, hitCube.transform.position);
            }
            else
            {
                _exploder.ExplodeSurroundings(hitCube.transform.position, hitCube.transform.localScale.x);
            }

            _spawner.Despawn(hitCube);
        }
    }
}