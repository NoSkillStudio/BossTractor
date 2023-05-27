using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : WeaponBase
{
    [SerializeField] private Transform playerPosition;
    private Vector3 raftPosition;

    [SerializeField] private Vector2 attackSize;

    [SerializeField] private UnityEvent OnShot;

    [SerializeField] private float offset;

    private float bulletsInMagazine = 25;

    private bool canShoot = true;
    private void Update()
    {
        if (canShoot)
        Rotate();
    }
    public void Rotate()
    {
        if (Time.time > nextShotTime)
        {
            if(playerPosition != null)
            targetPosition = new Vector3(Random.Range(playerPosition.transform.position.x - offset, playerPosition.transform.position.x + offset), Random.Range(playerPosition.transform.position.y - offset, playerPosition.transform.position.y + offset), playerPosition.transform.position.z);

            if (targetPosition.x < 0)
            {
                if(transform.rotation.eulerAngles.y == 180)
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180f /* изменить!!! */, Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg);
                else transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg);
                transform.localScale = new Vector3(1f, -1f, 1f);
            }
            else if (targetPosition.x > 0)
            {
                if (transform.rotation.eulerAngles.y == 180f)
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 180f, Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg);
                else transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x) * Mathf.Rad2Deg);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }

            OnShot.Invoke();
            Shoot();
            nextShotTime = Time.time + timeBetweenShots;
        }
    }

    protected override void Shoot()
    {
        bulletsInMagazine--;
        if (bulletsInMagazine <= 1)
        {
            RechargeMagazine();
        } 
        BulletActivate(firePoint, transform);
    }

    private void RechargeMagazine()
    {
        canShoot = false;
        bulletsInMagazine = 25;
        Invoke("ActiveShoot", 10f);
    }

    private void ActiveShoot() => canShoot = true;
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(raftPosition, attackSize);
    }
}