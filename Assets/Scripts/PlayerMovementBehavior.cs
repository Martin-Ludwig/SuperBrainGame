using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovementBehavior : MonoBehaviour
{

    public float Speed = 5;
    public bool SimpleMovement = true;

    protected Vector2 Direction;

    private BciController _bciInput;

    // Start is called before the first frame update
    void Start()
    {
        Direction = Vector2.zero;
        _bciInput = gameObject.GetComponent<BciController>();
    }

    // Update is called once per frame
    void Update()
    {
        Direction.x = Input.GetAxisRaw("Horizontal");

        // Up-down movement is deactivated in simple movement mode
        if (!SimpleMovement)
        {
            Direction.y = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);

        if (_bciInput != null && _bciInput.State == BciController.BciControllerState.Connected)
        {
            BciMentalInput input = _bciInput.Input;

            transform.Translate(input.ToDirection() * Speed * Time.deltaTime);
        }
    }

}
