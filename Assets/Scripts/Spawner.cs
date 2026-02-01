using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private int _minClones = 2;
    [SerializeField] private int _maxClones = 6;
    [SerializeField] private float _scaleFactor = 0.5f;
    [SerializeField] private float _chanceFactor = 0.5f;

    public List<Cube> SpawnClones(Cube parentCube)
    {
        List<Cube> newCubes = new List<Cube>();
        int count = Random.Range(_minClones, _maxClones + 1);

        for (int i = 0; i < count; i++)
        {
 
            Cube newCube = Instantiate(parentCube, parentCube.transform.position, Quaternion.identity);

            newCube.Initialize(
                parentCube.SplitChance * _chanceFactor,
                parentCube.transform.localScale * _scaleFactor
            );

            newCubes.Add(newCube);
        }

        return newCubes;
    }
}