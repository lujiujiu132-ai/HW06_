using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Game Manager - Controls game rules, timer, and UI
/// 游戏管理器 - 控制游戏规则、计时器和 UI
/// </summary>
public class EX_FPS_GameManager : MonoBehaviour
{
    [Header("UI Settings")]
    public GameObject GameOverPanel; // Panel shown when game ends / 游戏结束时显示的面板
    public TMP_Text TimeText;        // Text to display remaining time / 显示剩余时间的文本

    [Header("Game State")]
    bool isPlaying = true;           // Is the game currently running? / 游戏是否正在运行？
    float currentTime;               // Remaining time variable / 剩余时间变量
    public float maxTime = 60f;      // Total game time / 游戏总时长

    [Header("References")]
    // Reference to other scripts to stop them when game ends
    // 引用其他脚本，以便在游戏结束时停止它们
    public EX_Weapon PlayerWeapon;   // Player's shooting script / 玩家射击脚本
    public EX_TargetSpawner Spawner; // Enemy spawning script / 敌人生成脚本

    void Start()
    {
        // Initialization / 初始化
        GameOverPanel.SetActive(false); // Hide game over UI / 隐藏游戏结束 UI
        TimeText.text = maxTime.ToString("F1"); // Set initial time / 设置初始时间
    }

    void Update()
    {
        // 1. If the game is over, stop updating
        // 1. 如果游戏已结束，停止更新
        if(!isPlaying) return;

        // 2. Calculate remaining time (Total - Elapsed Time)
        // 2. 计算剩余时间 (总时间 - 已过时间)
        currentTime = maxTime - Time.time;
        
        // 3. UI Feedback: Change color to Red when 10 seconds left
        // 3. UI 反馈：剩余 10 秒时文字变红
        if(currentTime <= 10f)
        {
            TimeText.color = Color.red;
        }

        // 4. Game Over Logic
        // 4. 游戏结束逻辑
        if(currentTime <= 0f)
        {
            isPlaying = false;
            currentTime = 0; // Prevent negative time / 防止出现负数时间
            
            GameOverPanel.SetActive(true); // Show Game Over UI / 显示游戏结束 UI
            Debug.Log("Game Over");

            // Disable player and spawner to stop the game
            // 禁用玩家和生成器以停止游戏
            PlayerWeapon.enabled = false;
            Spawner.enabled = false;
        }
    
        // 5. Update the UI text (F1: show 1 decimal place)
        // 5. 更新 UI 文本 (F1: 保留一位小数)
        TimeText.text = currentTime.ToString("F1");
    }
}