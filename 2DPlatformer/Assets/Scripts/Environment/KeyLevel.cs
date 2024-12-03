using UnityEngine;
using System;
public class KeyLevel : MonoBehaviour
{
    public static Action OnDoorOpen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            OnDoorOpen?.Invoke();
        }
    }
}
