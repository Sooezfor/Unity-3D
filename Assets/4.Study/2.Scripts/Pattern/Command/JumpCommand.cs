using Pattern.Command;
using UnityEngine;

public class JumpCommand : ICommand
{
    Player2 player;
    public JumpCommand(Player2 player)
    {
        this.player = player;
    }
    public void Execute()
    {
        player.Jump();
    }
    public void Cancel()
    {
        player.JumpCancel();

    }

}
