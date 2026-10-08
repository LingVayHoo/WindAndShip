using UnityEngine;

public class WindRelativeAngle : MonoBehaviour
{
    [SerializeField] private WindController _windController;
    [SerializeField] private Transform _ship;

    public float ShipDirection => _ship.eulerAngles.y;

    public float RelativeAngle =>
        Mathf.DeltaAngle(
            ShipDirection,
            _windController.Direction);
}