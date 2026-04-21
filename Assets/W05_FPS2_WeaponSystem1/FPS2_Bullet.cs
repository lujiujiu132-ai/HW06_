using UnityEngine;

/// <summary>
/// Bullet Class - Carries damage and handles collision logic
/// 子弹类 - 携带伤害数值并 처리 碰撞逻辑
/// </summary>
public class FPS2_Bullet : MonoBehaviour
{
    private int bulletDamage;    // Damage value received from Weapon / 从武器接收的伤害值
    private bool isHit = false;  // Prevents multiple collision triggers / 防止多次触发碰撞逻辑
   
    /// <summary>
    /// Data Injection: Called by Weapon right after Instantiate
    /// 数据注入：在实例化后由武器脚本立即调用
    /// </summary>
    public void SetDamage(int amount)
    {
        bulletDamage = amount;
    }

    // Built-in Unity event for physical collisions
    // Unity 内置的物理碰撞事件
    void OnCollisionEnter(Collision collision)
    {
        // 1. Check if already hit to avoid double processing
        // 1. 检查是否已经发生过碰撞，避免重复处理
        if (isHit) return;

        // 2. Check if the collided object has the "Target" tag
        // 2. 检查碰撞到的物体是否具有 "Target" 标签
        if (collision.gameObject.CompareTag("Target"))
        {
            isHit = true;
            
            // Log the damage for debugging
            // 打印调试日志，显示伤害值
            Debug.Log("Hit Target! Damage: " + bulletDamage);

            // [Student Task] Add score logic or enemy HP reduction here
            // [学生练习] 在此处添加增加分数或减少敌人血量的逻辑
        }

        // 3. Destroy the bullet object upon any collision
        // 3. 无论碰撞到什么，立即销毁子弹物体
        Destroy(gameObject);
    }
}