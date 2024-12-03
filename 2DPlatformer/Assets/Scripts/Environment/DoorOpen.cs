using UnityEngine;
using System;
public class DoorOpen : MonoBehaviour
{
    private void OnEnable()
    {
        KeyLevel.OnDoorOpen += IsDoorOpen;
    }

    private void OnDisable()
    {
        KeyLevel.OnDoorOpen -= IsDoorOpen;
    }

    private void IsDoorOpen()
    {
        gameObject.SetActive(false);
    }
}
