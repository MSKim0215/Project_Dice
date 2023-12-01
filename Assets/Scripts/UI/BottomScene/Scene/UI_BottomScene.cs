using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BottomScene : MonoBehaviour
{
    private Slider slider_Timer;        // 타이머 슬라이더

    private Transform obj_SpawnGroup;   // 스폰 관련 그룹
    private Transform obj_UpgradeGroup; // 업그레이드 관련 그룹

    private float currTime = START_TIME;     // 현재 타이머 수치
    private int currWave = 1;               // 현재 웨이브

    private int currSP = 0;                     // 현재 보유 중인 SP

    public float CurrTime
    {
        get => currTime;
        set
        {
            currTime = value;

            // UI 처리
            obj_Spawn_Right?.SetTimerText(currTime);
        }
    }

    public int CurrSP
    {
        get => currSP;
        set
        {
            currSP = value;

            // UI 처리
            obj_Spawn_Left?.SetSPText(currSP);
        }
    }

    private Obj_Spawn_Left obj_Spawn_Left;      // 보유 중인 SP, SP Lv
    private Obj_Spawn_Right obj_Spawn_Right;    // 타이머, 생성 버튼

    // 코루틴
    private IEnumerator nextWaveTimer;    // 다음 웨이브까지의 타이머 코루틴

    // Prefab
    private GameObject prefab_spawnBoard;   // 스폰 보드
    private GameObject prefab_spawn_left;   // 스폰 관련 왼쪽 UI
    private GameObject prefab_spawn_right;  // 스폰 관련 오른쪽 UI
    private GameObject prefab_upgradeBox;   // 업그레이드 박스 버튼

    // 상수
    private const int UPGRADE_COUNT = 5;    // 업그레이드 주사위 개수
    private const float START_TIME = 5f;    // 초기 타이머 수치
    private const float BASE_TIME = 13f;  // 기본 타이머 수치
    private const int BASE_GET_SP = 150;    // 웨이브 마다 생성되는 SP

    private void Awake()
    {
        slider_Timer = transform.Find("Background/Slider_Timer").GetComponent<Slider>();

        obj_SpawnGroup = transform.Find("Background/Obj_SpawnGroup");
        obj_UpgradeGroup = transform.Find("Background/Obj_UpgradeGroup");

        prefab_spawnBoard = Resources.Load<GameObject>("Prefabs/UI/BottomScene/SubItem/Obj_Spawn_Board");
        prefab_spawn_left = Resources.Load<GameObject>("Prefabs/UI/BottomScene/SubItem/Obj_Spawn_Left");
        prefab_spawn_right = Resources.Load<GameObject>("Prefabs/UI/BottomScene/SubItem/Obj_Spawn_Right");
        prefab_upgradeBox = Resources.Load<GameObject>("Prefabs/UI/BottomScene/SubItem/Btn_UpgradeBox");
    }

    private void Start()
    {
        Init_SpawnGroup();
        Init_UpgradeGroup();
        Init_Timer();
    }

    /// <summary>
    /// 타이머 초기화 함수
    /// 김민섭_231128
    /// </summary>
    private void Init_Timer()
    {
        slider_Timer.value = 1f;

        if(nextWaveTimer == null)
        {
            nextWaveTimer = NextWaveTimer();
            StartCoroutine(nextWaveTimer);
        }
    }

    /// <summary>
    /// 다음 웨이브까지의 타이머 동작 코루틴 함수
    /// 김민섭_231128
    /// </summary>
    private IEnumerator NextWaveTimer()
    {
        while(true)
        {
            if(slider_Timer.value <= 0f)
            {
                // 다음 웨이브 진행
                currWave++;
                CurrTime = (currWave == 1 ? START_TIME : BASE_TIME);
                CurrSP += BASE_GET_SP;

                nextWaveTimer = null;
                Init_Timer();
                break;
            }

            CurrTime -= Time.deltaTime;
            slider_Timer.value = CurrTime / (currWave == 1 ? START_TIME : BASE_TIME);

            yield return null;
        }
    }

    /// <summary>
    /// 스폰 그룹 초기화 함수
    /// 김민섭_231128
    /// </summary>
    private void Init_SpawnGroup()
    {
        obj_Spawn_Left = Instantiate(prefab_spawn_left, Vector3.zero, Quaternion.identity, obj_SpawnGroup).GetComponent<Obj_Spawn_Left>();
        obj_Spawn_Left.Init();

        CurrSP = 0;

        Instantiate(prefab_spawnBoard, Vector3.zero, Quaternion.identity, obj_SpawnGroup);

        obj_Spawn_Right = Instantiate(prefab_spawn_right, Vector3.zero, Quaternion.identity, obj_SpawnGroup).GetComponent<Obj_Spawn_Right>();
        obj_Spawn_Right.Init(this);
    }

    /// <summary>
    /// 업그레이드 그룹 초기화 함수
    /// 김민섭_231128
    /// </summary>
    private void Init_UpgradeGroup()
    {
        for(int i = 0; i < UPGRADE_COUNT; i++)
        {
            Instantiate(prefab_upgradeBox, Vector3.zero, Quaternion.identity, obj_UpgradeGroup);
        }
    }
}
