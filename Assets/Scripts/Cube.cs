using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; }
    public Renderer Renderer { get; private set; }

    public float SplitChance { get; private set; } = 1f;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Renderer = GetComponent<Renderer>();
    }

    public void Initialize(float splitChance, Vector3 scale)
    {
        SplitChance = splitChance;
        transform.localScale = scale;
    }
}