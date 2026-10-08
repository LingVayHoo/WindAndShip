using UnityEngine;

public class WindController : MonoBehaviour
{
    [Header("Wind Settings")]
    [Range(0f, 360f)]
    [SerializeField] private float _direction;

    [Range(0f, 1f)]
    [SerializeField] private float _strength;

    public float Direction => _direction;
    public float Strength => _strength;

    public void SetDirection(float direction)
    {
        _direction = Mathf.Repeat(direction, 360f);
    }

    public void SetStrength(float strength)
    {
        _strength = Mathf.Clamp01(strength);
    }
}