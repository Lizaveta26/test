using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.transform.tag == "Enemy")
      {
         HealthManager.health--;
         if (HealthManager.health <= 0)
         {
            Player.isGameOver = true;
            gameObject.SetActive(false);
         }
         else
         {
            StartCoroutine(GetHurt());
         }
      }

      IEnumerator GetHurt()
      {
         Physics2D.IgnoreLayerCollision(6, 7);
         GetComponent<Animator>().SetLayerWeight(1,1);
         yield return new WaitForSeconds(3);
         GetComponent<Animator>().SetLayerWeight(1,0);
         Physics2D.IgnoreLayerCollision(6, 7, false);
      }
   }
}
