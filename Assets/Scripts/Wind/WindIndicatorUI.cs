using UnityEngine;
using TMPro;

public class WindIndicatorUI : MonoBehaviour
{
    [SerializeField] private WindController _windController;
    [SerializeField] private WindRelativeAngle _windRelativeAngle;

    [SerializeField] private RectTransform _windArrow;
    [SerializeField] private RectTransform _shipArrow;

    [SerializeField] private TMP_Text _directionText;
    [SerializeField] private TMP_Text _strengthText;
    [SerializeField] private TMP_Text _relativeAngleText;

    private void Update()
    {
        UpdateIndicator();
        UpdateTexts();
    }

    private void UpdateIndicator()
    {
        _windArrow.localRotation =
            Quaternion.Euler(
                0f,
                0f,
                -_windController.Direction);

        _shipArrow.localRotation =
            Quaternion.Euler(
                0f,
                0f,
                -_windRelativeAngle.ShipDirection);
    }

    private void UpdateTexts()
    {
        _directionText.text =
            $"Wind: {_windController.Direction:0}°";

        _strengthText.text =
            $"Strength: {_windController.Strength:0.00}";

        _relativeAngleText.text =
            $"Relative: {_windRelativeAngle.RelativeAngle:+0;-0;0}°";
    }
}