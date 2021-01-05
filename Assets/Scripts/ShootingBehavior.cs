using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : MonoBehaviour
{
    public float Cooldown = 1000;

    private float NextAction;
    private bool IsShooting;
    private EnemyBehavior Target;

    private BciController _bciInput;

    private GameManagerBehavior _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        NextAction = Time.time + (Cooldown / 1000);
        IsShooting = false;
        Target = null;

        _bciInput = gameObject.GetComponent<BciController>();

        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameController");
        _gameManager = gameManagerObject.GetComponent<GameManagerBehavior>();
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
            if (_bciInput.Input.IsNeutral)
            {
                IsShooting = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (_gameManager == null || _gameManager.IsRunning)
        {
            if (IsShooting && (Time.time >= NextAction))
            {
                Debug.Log("Shoot.");
                Shoot();
                NextAction = Time.time + (Cooldown /1000);
            }
        }
    }

    private void Shoot()
    {
        if (Target != null)
        {
            if (Target.TryHit())
            {
                GameStats stats = gameObject.GetComponent<GameStats>();
                if (stats != null)
                {
                    stats.IncreaseScore();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            EnemyBehavior enemy = collider.GetComponent<EnemyBehavior>();
            
            Target = enemy;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            Target = null;
        }
    }

}
