using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obj_Spawn_Right : MonoBehaviour
{
    private UI_BottomScene root;

    private TextMeshProUGUI tmp_Timer;         // 타이머 수치 텍스트
    private Button btn_Spawn;                   // 생성 버튼
    private TextMeshProUGUI tmp_Spawn_SP;       // 생성 요구량 SP 텍스트

    private int currSpawnSP;    // 현재 필요한 SP

    public int CurrSpawnSP
    {
        get => currSpawnSP;
        set
        {
            currSpawnSP = value;

            // UI 처리
            SetSpawnSPText(currSpawnSP);
        }
    }

    private const int START_SPAWN_SP = 5;       // 생성하는데 필요한 시작 SP
    private const int BASE_GROW_SP = 5;         // 생성하는데 필요한 SP 증가량

    /// <summary>
    /// 초기화 함수
    /// 김민섭_231128
    /// </summary>
    public void Init(UI_BottomScene root)
    {
        this.root = root;

        tmp_Timer = transform.Find("Obj_TimerBox/Text_Timer").GetComponent<TextMeshProUGUI>();
        btn_Spawn = transform.Find("Btn_Spawn").GetComponent<Button>();
        tmp_Spawn_SP = btn_Spawn.transform.Find("Text_Spawn_SP").GetComponent<TextMeshProUGUI>();

        CurrSpawnSP = START_SPAWN_SP;

        btn_Spawn.onClick.AddListener(() => { OnSpawnDice(); });
    }

    /// <summary>
    /// 타이머 텍스트 세팅 함수
    /// 김민섭_231128
    /// </summary>
    /// <param name="value">수치</param>
    public void SetTimerText(float value)
    {
        tmp_Timer.text = ((int)value).ToString();
    }

    /// <summary>
    /// 주사위 생성 버튼 이벤트 함수
    /// 김민섭_231128
    /// </summary>
    private void OnSpawnDice()
    {
        if (root.CurrSP >= CurrSpawnSP)
        {
            root.CurrSP -= CurrSpawnSP;
            CurrSpawnSP += BASE_GROW_SP;
        }
    }

    /// <summary>
    /// 생성 SP 요구량 텍스트 세팅 함수
    /// 김민섭_231128
    /// </summary>
    /// <param name="value">수치</param>
    public void SetSpawnSPText(int value)
    {
        tmp_Spawn_SP.text = value.ToString();
    }
}
