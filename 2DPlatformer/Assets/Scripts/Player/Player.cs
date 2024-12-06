
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f; 
    [SerializeField] private float _jumpForce = 5f;
    private bool _groundCheck;
    private Vector3 _playerMovementState;
    private SpriteRenderer _sprite;
    public int _jumps;
    private int _jumpsCount; 
    private bool _isFalling;
    private Rigidbody2D _rb2D;
    [SerializeField] private LayerMask _mask;
    private Ray _ray;
    [SerializeField] private float _groundCheckRadius = 0.1f;
    private Animator _animator;
    
    public int health = 3;
   
    public Image[] hearts;
    public Sprite[] fullHeart;
    public Sprite[] emptyHeart;
    
   public static Player Instance;

   private void Awake()
   {
       Instance = this;
   }
   
   private void Start()
   { 
       _sprite = GetComponentInChildren<SpriteRenderer>();
       _rb2D = GetComponent<Rigidbody2D>();
       _jumpsCount = _jumps;
       _animator = GetComponent<Animator>();
   }

   private void Update()
   {
       if (_groundCheck == true)
       {
           _jumpsCount = _jumps; 
       }

       DrawGismos();
       VerticalSpeed();
   }

   void FixedUpdate()
   {
       _groundCheck= Physics2D.Raycast(transform.position, Vector2.down, _groundCheckRadius, _mask);
       if (_groundCheck != null)
       {
           _isFalling = false;
       }
   }

   internal void Move(float horizontalInput)
   {
      _rb2D.linearVelocity = new Vector2(horizontalInput * _speed, _rb2D.linearVelocity.y);
      
      _sprite.flipX = horizontalInput < 0.0f;
      _animator.SetBool("IsRun", _rb2D.linearVelocity.x != 0);
   }
    

   internal void Jump()
   {
       _animator.SetTrigger("IsJump"); 
       _jumpsCount--;
       if (_jumpsCount > 0)
       {
           _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, _jumpForce);
       }
       else if (_jumpsCount == 0 && _groundCheck)
       {
           _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, _jumpForce); 
       }
   }

   private void VerticalSpeed()
   {
       _animator.SetBool("IsFall", _isFalling);
       if (_rb2D.linearVelocity.y < 0)
       {
           _isFalling = true;
       }
   }

   private void DrawGismos()
   {
       Debug.DrawRay(transform.position, Vector2.down * _groundCheckRadius, Color.red);  
   }
}
 