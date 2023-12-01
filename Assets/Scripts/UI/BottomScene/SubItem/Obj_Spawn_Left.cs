using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obj_Spawn_Left : MonoBehaviour
{
    private TextMeshProUGUI text_SP_Count;      // 현재 SP 수치

    /// <summary>
    /// 초기화 함수
    /// 김민섭_231128
    /// </summary>
    public void Init()
    {
        text_SP_Count = transform.Find("Background/Text_SP_Count").GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// 현재 SP 수치 텍스트 세팅 함수
    /// 김민섭_231128
    /// </summary>
    /// <param name="value">수치</param>
    public void SetSPText(int value)
    {
        text_SP_Count.text = value.ToString();
    }
}
