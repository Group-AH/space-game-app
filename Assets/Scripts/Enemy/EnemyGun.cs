using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public Transform Player;
    private float fireRate = 2.0f;
    private float fireTime = 0.0f;
    

    void Update() {
        if (Menus.gamePaused) return;

        float range = transform.parent.GetComponent<Enemy.Enemy>().shootingRange;
        float distance = Vector3.Distance(transform.position, Player.position);
        if (distance <= range  && Time.time >= fireTime){
            transform.parent.LookAt(Player);

            CharacterController characterController = Player.GetComponent<CharacterController>();
            Vector3 center = characterController.center;
            Vector3 playerCenter = Player.position + center;

            Vector3 direction = (playerCenter  - bulletSpawnPoint.position).normalized;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;

            fireTime = Time.time + fireRate;
        }
    }
}
