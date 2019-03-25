using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class NinjaController : MonoBehaviour, IAnimationCompleted
{
    public GameObject fireBall;
    public float speed = 5.0f;
    public float movementThreshold = 0.5f;

    [HideInInspector]
    public Vector2 inputDirection;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    [SerializeField] private bool attack = false;

    private float dragDistance;
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        dragDistance = Screen.height * 15 / 100;
    }

    public void AnimationCompleted(int shortHashName)
    {
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && attack == false)
        {
            attack = true;
            _animator.SetTrigger("Attack");
            _rigidbody2D.velocity = new Vector2();
        }
        else if (attack == false)
        {

            //inputDirection.x = Input.GetAxis("Horizontal");
            //inputDirection.y = Input.GetAxis("Vertical");

            if (inputDirection.magnitude > movementThreshold)
            {
                _rigidbody2D.velocity = new Vector2(inputDirection.x * speed, inputDirection.y * speed);

                // Set the input values on the animator
                _animator.SetFloat("inputX", inputDirection.x);
                _animator.SetFloat("inputY", inputDirection.y);
                _animator.SetBool("isWalking", true);
            }
            else
            {
                _rigidbody2D.velocity = new Vector2();
                _animator.SetBool("isWalking", false);
            }
        }

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lp = touch.position;

                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                    SwipeAttack();
                }
            }
        }
    }

    public void SwipeAttack()
    {
        GameObject gObj = Instantiate(fireBall, transform.position, Quaternion.identity);
        FireBall fb = gObj.GetComponent<FireBall>();

        if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
        {
            if (lp.x > fp.x)
            {
                // Swiped Right
                fb.direction = FireBall.eDirection.RIGHT;
            }
            else
            {
                // Swiped Left
                fb.direction = FireBall.eDirection.LEFT;
            }
        }
        else
        {
            if (lp.y > fp.y)
            {
                // Swiped Up
                fb.direction = FireBall.eDirection.UP;
            }
            else
            {
                // Swiped Down
                fb.direction = FireBall.eDirection.DOWN;
            }
        }
    }
}
