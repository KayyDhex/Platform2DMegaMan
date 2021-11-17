using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float range;
    [SerializeField] GameObject player;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] AudioClip sfx_death;
    [SerializeField] GameObject firePoint;
    [SerializeField] float shotRate;
    [SerializeField] GameObject bullet;
    private float canFire;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        if (distance <= range)
            Fire();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255f, 0f, 0f, 0.3f);
        Gizmos.DrawSphere(transform.position, range);
        Gizmos.DrawLine(transform.position, player.transform.position);
    }
    private void Fire()
    {
        if (Time.time >= canFire)
        {
            GameObject bull = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            Destroy(bull, 3);
            canFire = Time.time + shotRate;
        }
    }
}