using Pattern.Command;
using UnityEngine;

public class SkillCommand : ICommand
{
    Player2 player;
    string skillName;

    public SkillCommand (Player2 player, string skillName)
    {
        this.player = player;
        this.skillName = skillName;
    }
    public void Execute()
    {
        player.UseSkill(skillName);
    }
    public void Cancel()
    {
        player.UseSkillCancel(skillName);
    }

}
