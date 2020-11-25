using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : MonoBehaviour
{
    public float Cooldown = 1000;

    private float NextAction;
    private bool IsShooting;

    private BciController _bciInput;

    // Start is called before the first frame update
    void Start()
    {
        NextAction = Time.time + (Cooldown / 1000);
        IsShooting = false;

        _bciInput = gameObject.GetComponent<BciController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            IsShooting = true;
        } else
        {
            IsShooting = false;
        }


        if (_bciInput != null && _bciInput.State == BciController.BciControllerState.Connected)
        {
            if (_bciInput.Input.Neutral > 50)
            {
                IsShooting = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (IsShooting && (Time.time >= NextAction))
        {
            Debug.Log("Shoot.");
            NextAction = Time.time + (Cooldown /1000);
        }

    }
}
