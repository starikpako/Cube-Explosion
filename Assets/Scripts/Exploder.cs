using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _force = 500;
    [SerializeField] private float _radius = 10;

    public void Explode(List<Cube> cubes, Vector3 center)
    {
        foreach (Cube cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_force, center, _radius);
        }
    }
}
