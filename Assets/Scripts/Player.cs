using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _visual;
    [SerializeField] private float _movementSpeed;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        _animator.SetFloat("MovementSpeed", Mathf.Abs(horizontal));
        if (horizontal > 0)
        {
            _visual.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontal < 0)
        {
            _visual.transform.localScale = new Vector3(-1, 1, 1);
        }

        transform.position += new Vector3(_movementSpeed, 0, 0) * horizontal * Time.deltaTime;

    }
}
