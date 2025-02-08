using System;
using System.Collections.Generic;
using Godot;
interface IFighter {
    interface IlivingState {
        IlivingState livingState();
    }
    void StartBattle();
    void FightEnd();
    void TakeTurn();
    void EndTurn();
}