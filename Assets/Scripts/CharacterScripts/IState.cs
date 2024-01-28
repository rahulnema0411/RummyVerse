using UnityEngine;

interface IState
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