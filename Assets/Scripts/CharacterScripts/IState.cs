using UnityEngine;

public interface IState
{
    void Enter();
    void Update();
    void Exit();
}

class IdleState : IState
{
    private Player player;

    public IdleState(Player player)
    {
        this.player = player;
    }

    public void Enter()
    {
        player.Animator.SetTrigger("Idle");
    }

    public void Exit()
    {
        //throw new System.NotImplementedException();
    }

    public void Update()
    {
        //do nothing in this case
    }
}

class MoveState : IState
{

    private Player player;
    private float speed;

    public MoveState(Player player, float speed)
    {
        this.player = player;
        this.speed = speed;
    }

    public void Enter()
    {
        player.Animator.SetTrigger("Walk");
    }

    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal > 0)
        {
            player.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            player.transform.localScale = new Vector3(-1, 1, 1);
        }
        player.transform.Translate(new Vector3(horizontal * speed, 0, 0) * Time.deltaTime);
    }

    public void Exit()
    {
        player.Animator.SetTrigger("Idle");
    }
}

class RunState : IState
{

    private Player player;
    private float speed;

    public RunState(Player player, float speed)
    {
        this.player = player;
        this.speed = speed;
    }

    public void Enter()
    {
        player.Animator.SetTrigger("Run");
    }

    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0)
        {
            player.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            player.transform.localScale = new Vector3(-1, 1, 1);
        }
        player.transform.Translate(new Vector3(horizontal * speed, 0, 0) * Time.deltaTime);
    }

    public void Exit()
    {
        player.Animator.SetTrigger("Idle");
    }
}

class JumpState : IState
{

    private Player player;
    private float jumpForce;
    private float speed;

    public JumpState(Player player, float jumpForce, float speed)
    {
        this.player = player;
        this.jumpForce = jumpForce;
        this.speed = speed;
    }

    public void Enter()
    {
        player.Animator.SetTrigger("Jump");
        player.Body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void Exit()
    {
        player.Animator.SetTrigger("Idle");
    }

    public void Update()
    {
        if(player.Body.velocity.y == 0)
        {
            player.TransitionToState(new IdleState(player));
        }

        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal >= 0f)
        {
            player.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            player.transform.localScale = new Vector3(-1, 1, 1);
        }
        player.transform.Translate(new Vector3(horizontal * speed, 0, 0) * Time.deltaTime);
    }
}