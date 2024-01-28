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


        if(_currentState is IdleState)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                TransitionToState(new RunState(this, RunSpeed));
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                TransitionToState(new JumpState(this, jumpForce, runSpeed));
            }
        }

        if(_currentState is RunState)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _currentState.Update();
            }
            else
            {
                TransitionToState(new IdleState(this));
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                TransitionToState(new JumpState(this, jumpForce, runSpeed));
            }
        }

        if (_currentState is JumpState)
        {
            _currentState.Update();
        }

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
