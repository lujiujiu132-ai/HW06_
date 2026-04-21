using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Pistol Class (Child Class) - Specialized for semi-auto firing
/// 手枪类 (子类) - 专门用于单发射击
/// </summary>
public class FPS2_Weapon_Pistol : FPS2_WeaponBase
{
    // 'override' is used to redefine the Update method from the parent class (FPS2_WeaponBase)
    // 'override' 用于重写父类 (FPS2_WeaponBase) 中的 Update 方法
    protected override void Update()
    {
        // Comparison of Input Methods / 输入方式对比:
        // 1. GetButton (Parent): Continuous firing as long as held down / 只要按住就会持续连射
        // 2. GetButtonDown (Pistol): Fires only once per click (Semi-auto) / 每次点击仅发射一次 (单发)

        // Check if the button was JUST pressed AND if the cooldown has passed
        // 检查是否 刚按下 按钮，并且 冷却时间已过
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            // Calculate the next time firing is allowed
            // 计算下次允许射击的时间
            nextFireTime = Time.time + fireRate;

            // Calls the Shoot() method defined in the parent class
            // 调用在父类中定义的 Shoot() 方法
            Shoot();
        }
    }
}