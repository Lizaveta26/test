using UnityEngine;


public class InputController : MonoBehaviour
{
    private float _horizontalInput;
    
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.Instance.Jump();
        }

    }

    private void FixedUpdate()
    {
        Player.Instance.Move(_horizontalInput);
    }
    
}
  
   