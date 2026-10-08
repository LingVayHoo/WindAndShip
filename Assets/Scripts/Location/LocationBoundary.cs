using System;
using System.Collections;
using UnityEngine;

public class LocationBoundary : MonoBehaviour
{
    [SerializeField] private float _warningDelay = 1f;
    [SerializeField] private float _exitCountdown = 5f;

    public event Action OnWarningStarted;
    public event Action OnReturnedToLocation;
    public event Action OnLocationExit;

    public event Action<int> OnCountdownChanged;

    private Coroutine _exitRoutine;

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<Ship>(out _))
            return;

        if (_exitRoutine != null)
            return;

        _exitRoutine = StartCoroutine(ExitRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Ship>(out _))
            return;

        CancelExit();
    }

    private IEnumerator ExitRoutine()
    {
        yield return new WaitForSeconds(_warningDelay);

        OnWarningStarted?.Invoke();

        for (int seconds = Mathf.CeilToInt(_exitCountdown); seconds > 0; seconds--)
        {
            OnCountdownChanged?.Invoke(seconds);

            yield return new WaitForSeconds(1f);
        }

        OnLocationExit?.Invoke();

        _exitRoutine = null;
    }

    private void CancelExit()
    {
        if (_exitRoutine == null)
            return;

        StopCoroutine(_exitRoutine);
        _exitRoutine = null;

        OnReturnedToLocation?.Invoke();
    }
}