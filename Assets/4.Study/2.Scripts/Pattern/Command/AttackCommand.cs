using Pattern.Command;
using UnityEngine;

public class AttackCommand : ICommand
{
    Player2 player;
    public AttackCommand(Player2 player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.Attack();
    }
    public void Cancel()
    { 
        player.AttackCancel();
    }
}
