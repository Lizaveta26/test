using UnityEngine;


[System.Serializable]
public class Boundary
{
   public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
   private Rigidbody _rigidbody;
   
   [SerializeField] private float _speed = 5.0f;
   [SerializeField] private float _tiltAngle = 4.0f;
   [SerializeField] private Boundary _boundary;
   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
   }
   private void FixedUpdate()
   {
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
      
      Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
      _rigidbody.linearVelocity = movement * _speed;

      _rigidbody.position = new Vector3
      (
         Mathf.Clamp(_rigidbody.position.x, _boundary.xMin, _boundary.xMax),
         Mathf.Clamp(_rigidbody.position.y, _boundary.yMin, _boundary.yMax),
         0.0f
      );

      _rigidbody.rotation = Quaternion.Euler(-90.0f, 0.0f, _rigidbody.linearVelocity.x * -_tiltAngle);
   }
}
