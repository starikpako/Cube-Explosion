using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [Header("Main Settings")]
    [SerializeField] private float _explosionForce = 1000;
    [SerializeField] private float _explosionRadius = 5;  

    public void ExplodeClones(List<Cube> cubes, Vector3 center)
    {
        foreach (Cube cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_explosionForce, center, _explosionRadius);
        }
    }

    public void ExplodeSurroundings(Vector3 center, float cubeScale)
    {
        float modifier = 1 / cubeScale;

        float currentRadius = _explosionRadius * modifier;
        float currentForce = _explosionForce * modifier;

        Collider[] hits = Physics.OverlapSphere(center, currentRadius);

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                hit.attachedRigidbody.AddExplosionForce(currentForce, center, currentRadius);
            }
        }

        Debug.Log($"BOOM! Scale: {cubeScale}, Radius: {currentRadius}, Force: {currentForce}");
    }
}