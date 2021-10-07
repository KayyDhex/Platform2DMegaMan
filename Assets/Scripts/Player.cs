using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] float speed;
    [SerializeField] BoxCollider2D feet;
    [SerializeField] float jumpSpeed;
    [SerializeField] float shotRate;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;

    //Dash
    [SerializeField] bool dash;
    [SerializeField] float dashTime;
    [SerializeField] float speedDash;

    private float canFire;
    private bool canDoubleJump;
    Animator myAnimator;
    Rigidbody2D myBody;
    BoxCollider2D myCollider;
    
    // Start is called before the first frame update
    void Start()
    {   

        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        firePoint = GetComponent<Transform>();
        canDoubleJump = true;
        //StartCoroutine(ShowTime());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Falling();
        Fire();
        DashEffect();
    }
    /*IEnumerator ShowTime(){
        int count = 0;
        while(true){
            yield return new WaitForSeconds(1f);
            count++;
            Debug.Log("Tiempo:"+count);
        }
    }*/
    void Move(){
        float mov = Input.GetAxis("Horizontal");
        if(mov != 0){
            myAnimator.SetBool("running",true);
            transform.localScale = new Vector2(Mathf.Sign(mov),1);
            firePoint.localScale = new Vector2(Mathf.Sign(mov),1);
            transform.Translate(new Vector2(mov * speed * Time.deltaTime, 0));
        }else{
            myAnimator.SetBool("running",false);
        }
    }
    void Jump(){
        if(isGrounded() && !myAnimator.GetBool("jumping")){
            myAnimator.SetBool("falling",false);
            myAnimator.SetBool("jumping",false);
            canDoubleJump = true;
            if(Input.GetKeyDown(KeyCode.Space)){
                myAnimator.SetTrigger("takeoff");
                myAnimator.SetBool("jumping",true);
                myBody.AddForce(new Vector2(0,jumpSpeed), ForceMode2D.Impulse);
            }
        }else if(canDoubleJump && myAnimator.GetBool("jumping")){
            if(Input.GetKeyDown(KeyCode.Space)){
                myAnimator.SetTrigger("takeoff");
                myAnimator.SetBool("jumping",true);
                myAnimator.SetBool("falling",false);
                canDoubleJump = false;
                myBody.AddForce(new Vector2(0,jumpSpeed/2), ForceMode2D.Impulse);
            }
        }
    }
    void Fire(){
        if(Input.GetKey(KeyCode.X) && Time.time>=canFire){
            myAnimator.SetLayerWeight(1,1);
            float mov = Input.GetAxis("Horizontal");
            Instantiate(bullet,firePoint.position,Quaternion.identity);
            canFire = Time.time + shotRate;
        }else{
            myAnimator.SetLayerWeight(1,0);
        }
    }

    void DashEffect(){
        if(Input.GetKey(KeyCode.C)){
            dashTime +=Time.deltaTime;
            if(dashTime < 1f){
                dash = true;
                myAnimator.SetBool("dash",true);
                myAnimator.SetBool("running",false);
                transform.Translate(Vector3.right * speedDash * Time.deltaTime);
            }else{
                dash = false;
                myAnimator.SetBool("dash",false);
            }
        }else{
                dash = false;
                myAnimator.SetBool("dash",false);
                dashTime = 0;
        }
    }

    void Falling(){
        if(myBody.velocity.y<0 && !myAnimator.GetBool("jumping")){
            myAnimator.SetBool("falling",true);
        }
    }
    bool isGrounded(){ 
        //RaycastHit2D myRaycast = Physics2D.Raycast(myCollider.bounds.center,Vector2.down,myCollider.bounds.extents.y + 0.2f,LayerMask.GetMask("ground"));
        //Debug.DrawRay(myCollider.bounds.center,new Vector2(0, (myCollider.bounds.extents.y + 0.2f)*-1 ),Color.red);
        //return myRaycast.collider !=null;
        return feet.IsTouchingLayers(LayerMask.GetMask("ground"));
    }
    void AfterTakeOffEvent(){
        myAnimator.SetBool("falling",true);
        myAnimator.SetBool("jumping",false);
    }
}