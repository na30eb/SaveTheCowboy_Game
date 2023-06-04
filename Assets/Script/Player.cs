using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D charjump;
    Animator MyAnim;
    AudioSource _AudioPlayer;
    public AudioClip JumpingSound;
    public float forcejump=4;
    public GameObject menu;
    bool goRight,goLeft;
    // Start is called before the first frame update
    void Start()
    {
        charjump = GetComponent<Rigidbody2D>();
        MyAnim=GetComponent<Animator>();
        _AudioPlayer=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Runningforpc
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(new Vector2(2f*Time.deltaTime,0));
            transform.localScale=new Vector3(1,transform.localScale.y,transform.localScale.z);
            MyAnim.SetBool("Running",true);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(new Vector2(-2f*Time.deltaTime,0));
            transform.localScale=new Vector3(-1,transform.localScale.y,transform.localScale.z);
            MyAnim.SetBool(name: "Running",true);
        }
        //Running for android 
        if(goRight){
            transform.Translate(new Vector2(2f*Time.deltaTime,0));
            transform.localScale=new Vector3(1,transform.localScale.y,transform.localScale.z);
            MyAnim.SetBool("Running",true);
        }
        if(goLeft){
            transform.Translate(new Vector2(-2f*Time.deltaTime,0));
            transform.localScale=new Vector3(-1,transform.localScale.y,transform.localScale.z);
            MyAnim.SetBool(name: "Running",true);
        }
        //not Running : music ===> mute
        if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)&& goLeft==false && goRight==false){

           
            MyAnim.SetBool("Running",false);
        }
        //Jumping for pc 
        if(Input.GetKeyDown(KeyCode.Space)){
            
            charjump.velocity=new Vector2 (charjump.velocity.x,forcejump);
            MyAnim.Play("Jump_Animation");
            _AudioPlayer.PlayOneShot(JumpingSound);
                        MyAnim.SetBool("Running",false);

        }
        //player falling ==> game over
        if(transform.position.y<-4.5){
            menu.SetActive(true);
        }
        
    }
    public void click_down_Right(){
        goRight=true;
    }
        public void click_up_Right(){
        goRight=false;
    }
     public void click_down_Left(){
        goLeft=true;
    }
        public void click_up_Left(){
        goLeft=false;
    }
    //juping for android 
        public void jump(){
             charjump.velocity=new Vector2 (charjump.velocity.x,forcejump);
            MyAnim.Play("Jump_Animation");
            _AudioPlayer.PlayOneShot(JumpingSound);
                        MyAnim.SetBool("Running",false);

        }
    
}
