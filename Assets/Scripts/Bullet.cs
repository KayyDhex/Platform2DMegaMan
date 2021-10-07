using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0,0));
    }
    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Choco con algo");
        if(!collision.gameObject.CompareTag("Shot") && !collision.gameObject.CompareTag("Player")) Debug.Log("Choco con un muro");
    }
}
