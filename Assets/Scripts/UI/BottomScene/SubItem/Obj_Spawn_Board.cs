using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Spawn_Board : MonoBehaviour
{
    private GameObject prefab_boardDice;        // 보드에 있는 다이스 칸 프리팹

    private const int BOARD_SIZE_WIDTH = 5;     // 보드판 가로 길이
    private const int BOARD_SIZE_HEIGHT = 3;    // 보드판 세로 길이

    private void Awake()
    {
        prefab_boardDice = Resources.Load<GameObject>("Prefabs/UI/BottomScene/SubItem/Obj_Board_Dice");
    }

    private void Start()
    {
        CreateBoard();
    }

    /// <summary>
    /// 보드판 생성 함수
    /// 김민섭_231201
    /// </summary>
    private void CreateBoard()
    {
        for (int i = 0; i < BOARD_SIZE_HEIGHT * BOARD_SIZE_WIDTH; i++)
        {
            Instantiate(prefab_boardDice, Vector3.zero, Quaternion.identity, transform);
        }
    }
}
