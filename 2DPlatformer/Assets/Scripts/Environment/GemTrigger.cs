using UnityEngine;
using System;

public class GemTrigger : MonoBehaviour
{
   public static Action<bool> OnGemDoubleJump;
   
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.tag == "Player")
      {
         OnGemDoubleJump?.Invoke(true);
         gameObject.SetActive(false);
      }
   }
}
