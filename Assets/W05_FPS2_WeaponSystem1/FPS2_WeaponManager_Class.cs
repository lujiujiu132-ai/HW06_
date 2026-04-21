using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Weapon Manager Class - Handles swapping between different weapons
/// 武器管理类 - 负责在不同武器之间 진행 切换
/// </summary>
public class FPS2_WeaponManager_Class : MonoBehaviour
{
    // List using the Parent Class type (Polymorphism)
    // 使用父类类型的列表 (多态性) - 可以同时存储手枪、步枪等
    public List<FPS2_WeaponBase> Weapons = new List<FPS2_WeaponBase>();

    private int currentWeaponIndex = 0; // Currently selected index / 当前选中的索引

    void Start()
    {
        // Initialize: Activate the first weapon if the list is not empty
        // 初始化：如果列表不为空，则激活第一把武器
        if (Weapons.Count > 0) SelectWeapon(0);
    }

    void Update()
    {
        // Swap weapons using numeric keys 1 and 2
        // 使用数字键 1 和 2 切换武器
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectWeapon(2);
    }

    /// <summary>
    /// Activates the chosen weapon and deactivates others
    /// 激活选中的武器，并禁用其他武器
    /// </summary>
    void SelectWeapon(int index)
    {
        // 1. Safety Check: Ensure the index exists in the list
        // 1. 安全检查：确保索引在列表范围内
        if (index < 0 || index >= Weapons.Count) return;

        // 2. Loop through all weapons in the list
        // 2. 遍历列表中的所有武器
        for (int i = 0; i < Weapons.Count; i++)
        {
            // If i matches the index, turn it ON; otherwise, turn it OFF
            // 如果 i 等于索引，则开启(True)；否则关闭(False)
            Weapons[i].gameObject.SetActive(i == index);
        }

        // 3. Update the current index and log the weapon name
        // 3. 更新当前索引并打印武器名称
        currentWeaponIndex = index;
        Debug.Log("Selected Weapon: " + Weapons[currentWeaponIndex].weaponName);
    }
}