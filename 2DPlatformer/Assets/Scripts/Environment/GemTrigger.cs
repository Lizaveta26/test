using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GemTrigger : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.transform.tag == "Player")
      {
         Player.lastCheckPointPos = transform.position;
         GetComponent<SpriteRenderer>().color = Color.white;
      }
   }
}
