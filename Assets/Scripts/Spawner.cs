using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _minClones = 2;
    [SerializeField] private int _maxClones = 6;
    [SerializeField] private float _scaleFactor = 0.5f;
    [SerializeField] private float _chanceFactor = 0.5f;

    public List<Cube> SpawnClones(Cube parent)
    {
        List<Cube> clones = new List<Cube>();
        int count = Random.Range(_minClones, _maxClones + 1);

        for (int i = 0; i < count; i++)
        {
            Cube clone = Instantiate(parent, parent.transform.position, Quaternion.identity);

            clone.Initialize(
                parent.SplitChance * _chanceFactor,
                parent.transform.localScale * _scaleFactor
            );

            clone.Renderer.material.color = Random.ColorHSV();

            clones.Add(clone);
        }

        return clones;
    }

    public void Despawn(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
