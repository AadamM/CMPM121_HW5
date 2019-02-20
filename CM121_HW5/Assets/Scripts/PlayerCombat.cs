using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform emergePoint;
    public GameObject projectile;
    public GameObject cannon;

    public float rechargeTime;
    public float projectileForce;

    private float timeSinceShot;

    private void Start() {
        timeSinceShot = 0f;
    }

    private void Update() {
        if (Input.GetButton("Fire1") && (timeSinceShot > rechargeTime)) {
            GameObject currentProjectile = Instantiate(projectile, emergePoint.position, emergePoint.rotation);
            currentProjectile.GetComponent<Rigidbody>().AddForce(currentProjectile.transform.forward * projectileForce);
            timeSinceShot = 0f;
            cannon.GetComponent<Animator>().SetTrigger("Cannon_Shoot");
        } else {
            timeSinceShot += Time.deltaTime;
        }
    }
}
