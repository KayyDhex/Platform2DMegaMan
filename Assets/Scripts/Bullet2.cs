using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0,0));
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
