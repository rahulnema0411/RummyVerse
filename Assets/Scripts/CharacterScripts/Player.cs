using UnityEngine;

public class Player : MonoBehaviour
{
    private IState _currentState;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float jumpForce;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    public Rigidbody2D Body { get => body; set => body = value; }
    public Animator Animator { get => animator; set => animator = value; }

    private void Awake()
    {
        _currentState = new IdleState(this);
    }

    private void Update()
    {

        //run
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if(!(_currentState is RunState))
            {
                _currentState.Exit();
                _currentState = new RunState(this, runSpeed);
                _currentState.Enter();
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            if(_currentState is RunState)
            {
                _currentState.Exit();
                _currentState = new IdleState(this);
                _currentState.Enter();
            }
        }


        //jump


        _currentState.Update();
    }

}
