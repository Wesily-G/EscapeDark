using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState { 
normal,
dialog
}
public class GameManager : BaseManager<GameManager>
{
    public GameState state;
    public void setState(GameState state) {
        this.state = state;
    }
}
