using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{

    public float Speed = 5;

    protected Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        Direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Direction.y = Input.GetAxisRaw("Vertical");
        Direction.x = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);
    }
}
