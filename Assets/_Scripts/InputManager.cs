using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public float GetPlayerDirection(){
        if(Input.GetKey(KeyCode.D)){ // when player press D key from keyboard
            return 1f;
        }else if(Input.GetKey(KeyCode.A)){
            return -1f;
        }

        return 0f;
    }

    public bool IsPlayerJumping(){
        return Input.GetKeyDown(KeyCode.W);
    }
}
