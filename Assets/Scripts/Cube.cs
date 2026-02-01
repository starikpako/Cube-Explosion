using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1.0f;

    private Rigidbody _rigidbody;
    private Renderer _renderer;

    public float SplitChance => _splitChance;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    public void Initialize(float chance, Vector3 scale)
    {
        _splitChance = chance;
        transform.localScale = scale;

        _renderer.material.color = Random.ColorHSV();
    }
}