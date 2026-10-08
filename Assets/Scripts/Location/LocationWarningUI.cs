using TMPro;
using UnityEngine;

public class LocationWarningUI : MonoBehaviour
{
    [SerializeField] private LocationBoundary _locationBoundary;
    [SerializeField] private GameObject _warningPanel;
    [SerializeField] private TMP_Text _warningText;
    [SerializeField] private TMP_Text _countdownText;

    private void Awake()
    {
        HideWarning();
    }

    private void OnEnable()
    {
        _locationBoundary.OnWarningStarted += ShowWarning;
        _locationBoundary.OnCountdownChanged += UpdateCountdown;
        _locationBoundary.OnReturnedToLocation += HideWarning;
        _locationBoundary.OnLocationExit += HideWarning;
    }

    private void OnDisable()
    {
        _locationBoundary.OnWarningStarted -= ShowWarning;
        _locationBoundary.OnCountdownChanged -= UpdateCountdown;
        _locationBoundary.OnReturnedToLocation -= HideWarning;
        _locationBoundary.OnLocationExit -= HideWarning;
    }

    private void ShowWarning()
    {
        _warningPanel.SetActive(true);

        _warningText.text = "Вы покидаете игровую область";
    }

    private void UpdateCountdown(int seconds)
    {
        _countdownText.text = seconds.ToString();
    }

    private void HideWarning()
    {
        _warningPanel.SetActive(false);
    }
}