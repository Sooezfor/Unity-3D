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
            if(Input.GetKeyDown(KeyCode.Q))//���ݱ��
            {
                attackCommand.Execute();
                executeCommand.Push(attackCommand);
            }
            else if(Input.GetKeyDown(KeyCode.W))//�������
            {
                jumpCommand.Execute();
                executeCommand.Push(jumpCommand);
            }
            else if(Input.GetKeyDown(KeyCode.E))//��ų��� 
            {
                skillCommand.Execute();
                executeCommand.Push(skillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))//���� ��� ĸ��ȭ
            {
                commandQueue.Enqueue(attackCommand);               
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))//������� ĸ��ȭ
            {
                commandQueue.Enqueue(jumpCommand);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))//��ų��� ĸ��ȭ
            {
                commandQueue.Enqueue(skillCommand);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("�� ���� �� ��� ����");
                while(commandQueue.Count > 0)
                {
                    ICommand command = commandQueue.Dequeue();
                    command.Execute();
                    executeCommand.Push(command); //���� ���� �����
                }
            }

            if (Input.GetKeyDown(KeyCode.Z))//��ұ��
            {
                if (executeCommand.Count > 0)
                {
                    ICommand lastCommand = executeCommand.Pop(); //�����ֱ� ����� ���
                    Debug.Log($"��� ��� : {lastCommand.GetType().Name}");
                    lastCommand.Cancel(); //Undo
                }
                else
                    Debug.Log("�ǵ��� ����� �����ϴ�.");
            }
        }
    }

}
