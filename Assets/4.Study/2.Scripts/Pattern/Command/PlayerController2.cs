using System.Collections.Generic;
using UnityEngine;

namespace Pattern.Command
{
    public class PlayerController2 : MonoBehaviour
    {
        public Player2 player;

        ICommand attackCommand, jumpCommand, skillCommand;

        Queue<ICommand> commandQueue = new Queue<ICommand>();
        Stack<ICommand> executeCommand = new Stack<ICommand>();

        private void Awake()
        {
            attackCommand = new AttackCommand(player);
            jumpCommand = new JumpCommand(player);
            skillCommand = new SkillCommand(player, "fireball");
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Q))//공격기능
            {
                attackCommand.Execute();
                executeCommand.Push(attackCommand);
            }
            else if(Input.GetKeyDown(KeyCode.W))//점프기능
            {
                jumpCommand.Execute();
                executeCommand.Push(jumpCommand);
            }
            else if(Input.GetKeyDown(KeyCode.E))//스킬기능 
            {
                skillCommand.Execute();
                executeCommand.Push(skillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))//공격 기능 캡슐화
            {
                commandQueue.Enqueue(attackCommand);               
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))//점프기능 캡슐화
            {
                commandQueue.Enqueue(jumpCommand);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))//스킬기능 캡슐화
            {
                commandQueue.Enqueue(skillCommand);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("턴 종료 및 명령 실행");
                while(commandQueue.Count > 0)
                {
                    ICommand command = commandQueue.Dequeue();
                    command.Execute();
                    executeCommand.Push(command); //실행 내역 남기기
                }
            }

            if (Input.GetKeyDown(KeyCode.Z))//취소기능
            {
                if (executeCommand.Count > 0)
                {
                    ICommand lastCommand = executeCommand.Pop(); //가장최근 실행된 명령
                    Debug.Log($"명령 취소 : {lastCommand.GetType().Name}");
                    lastCommand.Cancel(); //Undo
                }
                else
                    Debug.Log("되돌릴 명령이 없습니다.");
            }
        }
    }

}
