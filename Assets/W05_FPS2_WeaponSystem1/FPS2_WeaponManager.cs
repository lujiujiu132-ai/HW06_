using UnityEngine;
using System.Collections.Generic;


public class FPS2_WeaponManager : MonoBehaviour
{
   
    public List<FPS2_WeaponBase> Weapons = new List<FPS2_WeaponBase>(); 
    
    private int currentWeaponIndex = 0; 

    void Start()
    {
        
        if(Weapons.Count > 0) SelectWeapon(0);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectWeapon(2);
    }

    void SelectWeapon(int index)
    {
       
        if (index < 0 || index >= Weapons.Count) return;

      
        for (int i = 0; i < Weapons.Count; i++)
        {
            Weapons[i].gameObject.SetActive(i == index);
        }

        currentWeaponIndex = index;
        Debug.Log("Selected Weapon: " + Weapons[currentWeaponIndex].weaponName);
    }
}