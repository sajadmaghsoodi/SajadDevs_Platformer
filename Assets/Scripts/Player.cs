using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _visual;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;

    private bool _playerFacedRight;



    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        Movement(horizontal);
        Animation(horizontal);

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 rotation = new Vector3(0, 0, 0);
            if(!_playerFacedRight)
                 rotation = new Vector3(0, 0, 180);
            
            Instantiate(_bulletPrefab, _bulletSpawnPoint.position , Quaternion.Euler(rotation));
        }
    }


    public void Movement(float horizontal)
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
          _rigidbody.AddForce(Vector2.up * _jumpForce);  
        }
        
         transform.position += new Vector3(_movementSpeed, 0, 0) * horizontal * Time.deltaTime;
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.3f,_whatIsGround);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            return true;
        }

        return false;
    }
    
    public void Animation(float horizontal)
    {
        _animator.SetFloat("MovementSpeed", Mathf.Abs(horizontal));
        if (horizontal > 0)
        {
            _visual.transform.localScale = new Vector3(1, 1, 1);
            _playerFacedRight = true;
        }
        else if (horizontal < 0)
        {
            _visual.transform.localScale = new Vector3(-1, 1, 1);
            _playerFacedRight = false;
        }
    }
    
}
