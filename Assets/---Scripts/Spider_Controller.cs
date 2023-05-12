using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Spider_Controller : MonoBehaviour
{
    public float _speed = 1f;

    private Rigidbody _rigidbody;
    bool _isJumping=false;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float multiplier = 1f;
        if (Input.GetKey(KeyCode.LeftShift))
            multiplier = 2f;

        if (_rigidbody.velocity.magnitude < _speed * multiplier)
        {

            float value = Input.GetAxis("Vertical");
            if (value != 0 && !_isJumping)
                _rigidbody.AddForce(transform.forward * value*Time.fixedDeltaTime*1000f);
                //_rigidbody.AddForce(0, 0, value * Time.fixedDeltaTime * 1000f);
           // value = Input.GetAxis("Horizontal");
           // if (value != 0)
             //   _rigidbody.AddForce(value * Time.fixedDeltaTime * 1000f, 0f, 0f);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
            jump();
        }

    }
    [Header("jump")]
    [SerializeField] float _jumpForce;
    [SerializeField] float _jumpTime;
    void jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        StartCoroutine(grounded());
    }
    IEnumerator grounded()
    {
        yield return new WaitForSeconds(_jumpTime);
        _isJumping = false;
    }
    
}
