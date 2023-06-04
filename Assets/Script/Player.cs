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
        //Running
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
        //not Running : music ===> mute
        if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)){

           
            MyAnim.SetBool("Running",false);
        }
        //Jumping
        if(Input.GetKeyDown(KeyCode.Space)){
            charjump.velocity=new Vector2 (charjump.velocity.x,forcejump);
            MyAnim.Play("Jump_Animation");
            _AudioPlayer.PlayOneShot(JumpingSound);
        }
        
    }
}
