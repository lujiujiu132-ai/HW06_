using UnityEngine;

public class FPS2_Weapon_Shotgun : FPS2_WeaponBase
{
    [Header("霰弹枪专属设置")]
    public Transform firePoint;
    public int pellets = 8;
    public float spreadAngle = 8f;
    public GameObject bulletPrefab;

    // 不再定义任何和父类重复的变量（包括 bulletSpeed）

    protected override void Update()
    {
        // 和手枪保持完全一致的逻辑
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    protected override void Shoot()
    {
        for (int i = 0; i < pellets; i++)
        {
            // 生成散射方向
            Vector3 dir = firePoint.forward;
            dir = Quaternion.Euler(
                Random.Range(-spreadAngle, spreadAngle),
                Random.Range(-spreadAngle, spreadAngle),
                0
            ) * dir;

            // 实例化子弹，使用父类的 bulletSpeed
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(dir));
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = dir * bulletSpeed;
            }
            Destroy(bullet, 3f);
        }
    }
}