using UnityEngine;


public class Inventory : MonoBehaviour
{
  public bool[] isFull;
  public GameObject[] slots;
  public GameObject[] inventory;
  private bool inventoryOn;

  private void Start()
  {
    inventoryOn = false;
  }

  public void Chest()
  {
    if (inventoryOn == false)
    {
      inventoryOn = true;
      
    }
    else if (inventoryOn == true)
    {
      inventoryOn = false;
      
    }
  }
  
}