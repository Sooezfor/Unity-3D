using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SingleBoard_Controller : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;
    [SerializeField] Transform cellGroup;
    [SerializeField] TextMeshProUGUI statusText;
    [SerializeField] Button restartButton;

    Single_BoardTicTacToe gameBoard;
    Single_Cell[,] cells = new Single_Cell[3, 3];

    public static Action startAction;

    private void Awake()
    {
        restartButton.onClick.AddListener(StartGame); //���

        startAction += StartGame;

    }
   

    public void StartGame()
    {
        gameBoard = new Single_BoardTicTacToe();

        statusText.text = "Player X Turn";
        restartButton.gameObject.SetActive(false);

        for (int i = 0; i < cellGroup.childCount; i++)
        {
            Destroy(cellGroup.GetChild(i).gameObject);
        }
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject cellObj = Instantiate(cellPrefab, cellGroup);
                Single_Cell cell = cellObj.GetComponent<Single_Cell>();

                cell.SetButton(j, i, OnCellClicked);
                cells[i, j] = cell;

            }
        }

        UpdateBoardVisual();
    }

    void OnCellClicked(int x, int y) //Cell�� ������ O �� X�� ����
    {
        if (gameBoard.IsGameOver() || gameBoard.board[y, x] != 0) //���� �������� �ƴ��� Ȯ��
            return;

        Single_Move move = new Single_Move(x, y, gameBoard.player); 
        gameBoard.MakeMove(move);

        UpdateBoardVisual();
        CheckForGameOver();
    }

    private void UpdateBoardVisual() //Ŭ���� ���� ���ؼ� O�� X�� ����� ���
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                string str = "";
                if (gameBoard.board[i, j] == 1)
                    str = "X";
                else if (gameBoard.board[i, j] == 2)
                    str = "O";

                cells[i, j].SetText(str);
            }
        }
    }

    void CheckForGameOver() //
    {
        int winner = gameBoard.CheckWinner();
        if (winner == 0) //���ʰ� ���� ���� ���� ��
        {
            string nextPlayer = gameBoard.player == 1 ? "X" : "O";
            statusText.text = $"Player : {nextPlayer} Turn";
            return;
        }
        if (winner == 3) //���º�
            statusText.text = "Draw";
         else //1�̳� 2�� �̱� ���
         {
            string result = winner == 1 ? "X" : "O";
            statusText.text = $"Player {result} Win";
         }
        restartButton.gameObject.SetActive(true);
        }
 }

