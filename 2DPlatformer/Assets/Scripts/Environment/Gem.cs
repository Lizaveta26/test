using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player.numberOfGems++;
            PlayerPrefs.SetInt("NumberOfGems", Player.numberOfGems);
            Destroy(gameObject);
        }
    }
}
