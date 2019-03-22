using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{ 
    public enum eDirection
    { 
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public eDirection direction;

    public int speed = 2;

    private Vector2[] directions = {  new Vector2(0,  1)
                                    , new Vector2(0, -1)
                                    , new Vector2(-1, 0)
                                    , new Vector2(1,  0)}; 

    private int[] facing = { 180, 0, 270, 90 };


    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    { 
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        FacingUpdate();
        Move();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<NinjaController>() == true)
        {
            return;
        }

        Destroy(this.gameObject);
    }

    private void Move()
    {
        _rigidbody2D.velocity = directions[(int)direction] * speed;
    }

    private void FacingUpdate()
    {
        if (transform.rotation.z != facing[(int)direction])
        {
            transform.eulerAngles = new Vector3(0, 0, facing[(int)direction]);
        }
    }

}
