using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null){
            StartCoroutine("Restar");
            
        }
    }
    IEnumerator Restar()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}
