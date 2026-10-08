using UnityEngine;

public class LocationExitHandler : MonoBehaviour
{
    [SerializeField] private LocationBoundary _locationBoundary;

    private void Start()
    {
        _locationBoundary.OnLocationExit += HandleLocationExit;
    }

    private void OnDestroy()
    {
        _locationBoundary.OnLocationExit -= HandleLocationExit;
    }

    private void HandleLocationExit()
    {
        Debug.Log("Location exited");
    }
}
