using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Vector2 VisiblePosition;
    public Vector2 HiddenPosition;


    private bool IsHittable = true;
    private Vector2 movingDestination = Vector2.zero;
    private float hidingTime;

    private EnemyStatus Status;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Status = EnemyStatus.Hidden;
        gameObject.transform.position = HiddenPosition;

        Incoming();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, movingDestination, 0.05f);
        CheckReachedMovingDestination();
        CheckHidingTime();
    }

    public bool TryHit()
    {
        if (IsHittable)
        {
            Hit();
            return true;
        }
        return false;
    }

    private void Hit()
    {
        Status = EnemyStatus.Hit;
        PlayAnimation(EnemyAnimation.Hit);

        Hiding();
    }

    void Hiding()
    {
        Status = EnemyStatus.Hiding;
        movingDestination = HiddenPosition;
        IsHittable = false;
    }

    void Incoming()
    {
        PlayAnimation(EnemyAnimation.Incoming);

        movingDestination = VisiblePosition;
        Status = EnemyStatus.Incoming;
    }

    void Hidden()
    {
        float rand = Random.Range(2, 5);
        hidingTime = Time.time + rand;

        PlayAnimation(EnemyAnimation.Idle);
        Status = EnemyStatus.Hidden;
    }

    void Visible()
    {
        Status = EnemyStatus.Visible;
        PlayAnimation(EnemyAnimation.Idle);
        IsHittable = true;
    }

    void CheckReachedMovingDestination()
    {
        Vector2 curPos = (Vector2)transform.position;
        if (curPos == HiddenPosition)
        {
            if (Status == EnemyStatus.Hiding)
            {
                Status = EnemyStatus.Hidden;
                Hidden();
            }
        }
        else if (curPos == VisiblePosition)
        {
            if (Status == EnemyStatus.Incoming)
            {
                Status = EnemyStatus.Visible;
                Visible();
            }
        }
    }

    void CheckHidingTime()
    {
        if (Status == EnemyStatus.Hidden && Time.time > hidingTime)
        {
            Incoming();
        }
    }

    void PlayAnimation(EnemyAnimation anim)
    {
        if (animator != null)
        {
            switch (anim)
            {
                case EnemyAnimation.Incoming:
                    animator.Play("Enemy_Incoming");
                    break;
                case EnemyAnimation.Idle:
                    animator.Play("Enemy_Idle");
                    break;
                case EnemyAnimation.Hit:
                    animator.Play("Enemy_Hit");
                    break;
                case EnemyAnimation.Hiding:
                    animator.Play("Enemy_Hiding");
                    break;
                default:
                    break;
            }
            
        }
    }

    enum EnemyStatus
    {
        Hiding,
        Hidden,
        Incoming,
        Visible,
        Hit
    }

    enum EnemyAnimation
    {
        Incoming,
        Idle,
        Hit,
        Hiding
    }

}
