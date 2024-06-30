using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{   
    public Rigidbody2D rigidbodyPlayer{get; private set;}
    private BoxCollider2D colliderPlayer;
    [SerializeField] private LayerMask jumpAbleGround;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

    public float directioX {get; private set;}

    // Start is called before the first frame update
    protected override void CustomAwake()
    {
        base.CustomAwake();
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        colliderPlayer = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        if(Input.GetMouseButtonDown(0)){
            PlayerAnimation.Instance.AnimationPLayerAttack();
        }
    }

    //Player moves
    public void PlayerMove(){
        directioX = InputManager.Instance.GetPlayerDirection();//When player press key from keyboard
        rigidbodyPlayer.velocity = new Vector2(directioX * moveSpeed, rigidbodyPlayer.velocity.y);//Player move to left if press A or right if press D

        if(InputManager.Instance.IsPlayerJumping() && IsGround()){//When player press W key from keyboard and is standing on the ground
            rigidbodyPlayer.velocity = new Vector2(rigidbodyPlayer.velocity.x, jumpForce);//Player jump in higher one time
        }
        PlayerAnimation.Instance.AnimationPLayerMove();
    }

    //Check player is standing on the ground
    public bool IsGround(){
        return Physics2D.BoxCast(colliderPlayer.bounds.center, colliderPlayer.bounds.size, 0f, Vector2.down, .1f, jumpAbleGround);
    }
}
