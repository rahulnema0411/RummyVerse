using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private IState _currentState;
    
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float jumpForce;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private int health = 2;

    public static event EventHandler<int> HitEvent;

    public Rigidbody2D Body { get => body; set => body = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public float RunSpeed { get => runSpeed; set => runSpeed = value; }
    public int Health { get => health; set => health = value; }

    private void Awake()
    {
        _currentState = new IdleState(this);
    }

    private void Update()
    {
        //run
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if(!(_currentState is RunState))
            {  
                TransitionToState(new RunState(this, RunSpeed));
            }
        }
        else
        {
            if (_currentState is RunState)
            {
                TransitionToState(new IdleState(this));
            }
        }

        //jump
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!(_currentState is JumpState))
            {
                TransitionToState(new JumpState(this, jumpForce));
            }
        }

        _currentState.Update();
    }

    public void Hurt()
    {
        if(health > 0)
        {
            health--;
            HitEvent?.Invoke(this, health);
        }
        else
        {
            LevelManager.instance.ShowGameOverScreen();
            Destroy(gameObject);
        }
    }


    public void TransitionToState(IState state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

}
