using UnityEngine;

public class PlayerAnimation : Singleton<PlayerAnimation>
{
    private Animator animatorPlayer;
    private SpriteRenderer spritePlayer;

    private enum MovementState{ idle, run, jump}
    MovementState state;

    protected override void CustomAwake()
    {
        base.CustomAwake();
        animatorPlayer = GetComponent<Animator>();
        spritePlayer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationPLayerMove(){

        if(PlayerMovement.Instance.directioX > 0f){
            state = MovementState.run;
            spritePlayer.flipX = false;
        }
        else if(PlayerMovement.Instance.directioX < 0f){
            state = MovementState.run;
            spritePlayer.flipX = true;
        }
        else{
            state = MovementState.idle;
        }

        if(PlayerMovement.Instance.rigidbodyPlayer.velocity.y > .1f){
            state = MovementState.jump;
        }

        animatorPlayer.SetInteger("state", (int)state);
    }

    public void AnimationPLayerAttack(){
        animatorPlayer.SetTrigger("isAttack");
    }
}
