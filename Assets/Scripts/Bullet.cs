using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    public float direction;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("player");
        Transform playerTransform = player.transform;
        direction = playerTransform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(direction * speed * Time.deltaTime, 0,0));
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}