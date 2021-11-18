using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] GameObject player;
    [SerializeField] AudioClip sfx_death;
    private float canFire;
    [SerializeField] float shotRate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("Player")) != null)
            Fire();
    }
    void Fire()
    {
        if (Time.time >= canFire)
        {
            //GameObject bull = Instantiate(bullet, firePoint.transform.position, Quaternion.identity);
            Debug.Log("Disparo enemigo.");
            canFire = Time.time + shotRate;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(255f, 0f, 0f, 0.3f);
        Gizmos.DrawSphere(transform.position, range);
        Gizmos.DrawLine(transform.position, player.transform.position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shot"))
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(sfx_death, Camera.main.transform.position);
            Destroy(explosion, 1f);
            Destroy(gameObject);
        }
    }
}
