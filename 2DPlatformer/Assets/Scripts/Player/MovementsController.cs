using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour
{
   [SerializeField] private float _speed;
   [SerializeField] private float _jumpForce;
   
   private Vector3 _playerMovementState;

   private SpriteRenderer _sprite;
   private Rigidbody2D _rb2D;

     private void Start()
    { 
     _sprite = GetComponentInChildren<SpriteRenderer>();
     _rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();

        if(Input.GetButtonDown(KeyCode.Space))
        {
            RigidbodyJump();
        }
    }
  
  
    private void Move()
   { 
      _playerMovementState = Vector3.right * Input.GetAxisRaw("Horizontal");
 transform.position = Vector3.MoveTowards(transform.position, _playerMovementState + transform.position, _speed * Time.deltaTime);

     if ( _playerMovementState.x < 0)
     { 
       _sprite.flipX = true;
     }
     else if ( _playerMovementState.x > 0)
     {
         _sprite.flipX = false;
     }

   }

    void RigidbodyJump()
    { 
        _rb2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse); 
    } 
}
