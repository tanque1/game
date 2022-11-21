using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public bool IsMarioInFireState(){
        return GetMarioState() == GameState.PlayerMode.FIRE;
    }

    public bool IsMarioInBigState(){
        return GetMarioState() == GameState.PlayerMode.BIG;
    }

    public bool IsMarioInRegularState(){
        return GetMarioState() == GameState.PlayerMode.REGULAR;
    }

    public void SetFireState(){
        SetMarioState(GameState.PlayerMode.FIRE);
    }

    public void SetBigState(){
        SetMarioState(GameState.PlayerMode.BIG);
    }

    public void SetRegularState(){
        SetMarioState(GameState.PlayerMode.REGULAR);
    }

    private GameState.PlayerMode GetMarioState(){
        return GameState.Mode;
    }

    private void SetMarioState(GameState.PlayerMode mode){
        GameState.Mode = mode;
    }

}
