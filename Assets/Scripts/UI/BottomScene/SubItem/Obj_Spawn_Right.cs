using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obj_Spawn_Right : MonoBehaviour
{
    private TextMeshProUGUI text_Timer;        // 타이머 수치 텍스트

    /// <summary>
    /// 초기화 함수
    /// 김민섭_231128
    /// </summary>
    public void Init()
    {
        text_Timer = transform.Find("Obj_TimerBox/Text_Timer").GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// 타이머 텍스트 세팅 함수
    /// 김민섭_231128
    /// </summary>
    /// <param name="value">수치</param>
    public void SetTimerText(float value)
    {
        text_Timer.text = ((int)value).ToString();
    }
}
