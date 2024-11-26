using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f; 
    [SerializeField] private float _jumpForce = 5f;
    private bool _groundCheck;
    private Vector3 _playerMovementState;
    private SpriteRenderer _sprite;
    public int _jump; 
    private Rigidbody2D _rb2D;
    [SerializeField] private LayerMask _mask;
    Ray _ray;
    [SerializeField] private float _groundCheckRadius = 0.1f;
    
   public static Player Instance;

   private void Awake()
   {
       Instance = this;
   }
   
   private void Start()
   { 
       _sprite = GetComponentInChildren<SpriteRenderer>();
       _rb2D = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
       CheckGround();
   }

   internal void Move(float horizontalInput)
   {
      _rb2D.linearVelocity = new Vector2(horizontalInput * _speed, _rb2D.linearVelocity.y);
      
      _sprite.flipX = horizontalInput < 0.0f;
   }
    

   internal void Jump()
   {
       _groundCheck = false;
       _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, _jumpForce);
      
   }

   public bool CheckGround()
   {
       var hit = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckRadius, _mask);
      Debug.DrawRay(transform.position, Vector2.down * _groundCheckRadius, Color.red); 
       return hit.collider != null;
   }
}
 