using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [SerializeField] float range;
    public AIPath aIPath;
    [SerializeField] GameObject player;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] AudioClip sfx_death;

    // Start is called before the first frame update
    void Start()
    {
        aIPath.canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (aIPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aIPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        /*float distance = Vector2.Distance(player.transform.position, transform.position);
        if(distance <= range)
        Debug.Log("Esta cerca");*/
        if (Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("Player")) != null)
        {
            aIPath.canMove = true;
        }
        else
        {
            aIPath.canMove = false;
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
