using UnityEngine;

/// <summary>
/// Base class for all weapons (Parent Class)
/// 所有武器的基础类 (父类)
/// </summary>
public class FPS2_WeaponBase : MonoBehaviour
{
    [Header("Weapon Settings")]
    public string weaponName;      // Name of the weapon / 武器名称
    
    [Tooltip("Damage per shot / 每발伤害")]
    public int damage = 10;        
    
    [Tooltip("Interval between shots / 射击间隔 (连射速度)")]
    public float fireRate = 0.2f;  
    
    [Tooltip("Speed of the bullet / 子弹飞行速度")]
    public float bulletSpeed = 30f;
    
    [Header("References")]
    public GameObject BulletPrefab; // Prefab to spawn / 要生成的子弹预制体
    public Transform FirePoint;     // Muzzle position / 枪口发射位置

    // nextFireTime: Time when the player can fire again
    // 存储下一次允许射击的时间点
    protected float nextFireTime = 0f;

    // 'virtual' allows child classes (Pistol, Rifle) to override this logic
    // 'virtual' 关键字允许子类（手枪、步枪等）重写此逻辑
    protected virtual void Update()
    {
        // Fire1 = Left Mouse Button / 鼠标左键
        // Check if button is pressed AND cooldown has passed
        // 检查是否按下按键 并且 冷却时间已过
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            // Calculate next allowed fire time
            // 计算下一次允许射击的时间
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    // Core shooting logic / 核心射击逻辑
    protected virtual void Shoot()
    {
        // 1. Create (Instantiate) the bullet at FirePoint
        // 1. 在枪口位置生成(实例化)子弹
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        
        // 2. Pass the weapon's damage to the bullet script
        // 2. 将武器的伤害值传递给子弹脚本
        FPS2_Bullet bulletScript = bullet.GetComponent<FPS2_Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetDamage(damage); // Dependency Injection / 伤害数值注入
        }

        // 3. Apply physical velocity to the bullet
        // 3. 给子弹添加物理速度
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null) 
        {
            // Move forward based on FirePoint's direction
            // 根据枪口的前方方向进行移动
            rb.velocity = FirePoint.forward * bulletSpeed;
        }

        // 4. Automatically destroy bullet after 3 seconds to save memory
        // 4. 3초 후 자탄을 자동 제거하여 메모리 절약
        Destroy(bullet, 3f);
    }
}