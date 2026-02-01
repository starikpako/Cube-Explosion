using UnityEngine;
using System.Collections.Generic;

public class CubeExploder : MonoBehaviour
{
    [Header("Настройки генерации")]
    public float splitChance = 1.0f;

    [Header("Настройки взрыва")]
    public float explosionForce = 500;
    public float explosionRadius = 10;

    private void OnMouseDown()
    {
        Debug.Log("1. Клик по кубу зафиксирован!");

        if (Random.value <= splitChance)
        {
            Debug.Log("2. Шанс выпал удачно, начинаю взрыв.");
            Explode();
        }
        else
        {
            Debug.Log("2. Шанс не выпал, куб просто удаляется.");
        }

        Destroy(gameObject);
    }

    private void Explode()
    {
        int cubesToSpawn = Random.Range(2, 7);
        Debug.Log("3. Создаю количество кубов: " + cubesToSpawn);

        List<Rigidbody> newCubesRb = new List<Rigidbody>();

        for (int i = 0; i < cubesToSpawn; i++)
        {
            GameObject newCube = Instantiate(gameObject, transform.position, transform.rotation);
            newCube.name = "SmallCube";

            newCube.transform.localScale = transform.localScale / 2;

            Renderer cubeRenderer = newCube.GetComponent<Renderer>();
            if (cubeRenderer != null)
            {
                cubeRenderer.material.color = Random.ColorHSV();
            }

            CubeExploder script = newCube.GetComponent<CubeExploder>();
            if (script != null)
            {
                script.splitChance = splitChance / 2;
            }

            Rigidbody rb = newCube.GetComponent<Rigidbody>();
            if (rb != null)
            {
                newCubesRb.Add(rb);
            }
        }
        Debug.Log("4. Применяю силу взрыва к " + newCubesRb.Count + " объектам.");
        foreach (Rigidbody rb in newCubesRb)
        {
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }
}