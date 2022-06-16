using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControler : MonoBehaviour
{
    [SerializeField] GameObject lanterna;
    [SerializeField] float folego = 50f;
    float folegoMax = 50f;
    bool podeAndar = true;
    private Rigidbody2D rb;    
    [SerializeField] private Animator animator;
    [SerializeField] private Animator fxAnimator;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private bool facingRight = true;
    private bool pulou = false;
    private float temp;
    private bool atacando = false;
    private float horizontal;
    public bool PodeAndar
    {
        get { return podeAndar; }
        set { podeAndar = value; }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public float JumpForce
    {
        get { return jumpForce; }
    }
    void Update()
    {
        Debug.Log(folego);
        if (podeAndar == true && PauseManager.paused == false)
        {
            Movimento();
            Anims();
            //Interact();
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        Debug.DrawRay(transform.position,transform.right*1f,Color.red);
    }
    private void Movimento()
    {
        if (atacando == false)
        {
            horizontal = Input.GetAxis("Horizontal");
            transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * speed;
            if (horizontal > 0 && !facingRight)
            {
                Flip();
            }
            else if (horizontal < 0 && facingRight)
            {
                Flip();
            }
            if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                Jump();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            lanterna.SetActive(!lanterna.activeSelf);
            AudioManager.instance.PlaySound("LanternON");
        }
    }
    private void Jump()
    {
        if (atacando == false)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            GameObject.Find("Ella").GetComponent<PlayerSounds>().JumpSound();
        }       
    }
    private void Anims()
    {
        if (pulou == false)
        {
            if (folego < folegoMax && Input.GetButton("Fire3") == false)
            {
                if (folego > folegoMax)
                {
                    folego = folegoMax;
                }
                folego += 5f * Time.fixedDeltaTime;
            }
            speed = 6;
            animator.speed = 1f;
        }
        if (horizontal != 0 && pulou == false)
        {
            animator.SetBool("Walking",true);
            if (Input.GetButton("Fire3") && folego>0)
            {
                if (Input.GetAxis("Horizontal") != 0)
                {
                    speed = 9;
                    animator.speed = 2f;
                    folego -= 5f * Time.fixedDeltaTime;
                }               
            }
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        if (Input.GetButtonDown("Fire1") && !atacando && !pulou)
        {
            animator.SetBool("Attack", true);
            fxAnimator.SetBool("Attack", true);
            GameObject.Find("Ella").GetComponent<PlayerSounds>().AttackSound();
            atacando = true;
        }
        if (atacando)
        {
            StopAnim(0.4f,"Attack");
        }
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Jump", true);
            pulou = true;
        }
        if (pulou)
        {
            StopAnim(1f, "Jump");
            //pulou = false;
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }
    private void StopAnim(float cont,string anim)
    {       
        temp += Time.deltaTime * 1;
        if (temp >= cont)
        {
            //Debug.Log(temp);
            animator.SetBool(anim, false);
            if (anim == "Attack")
            {
                fxAnimator.SetBool(anim, false);
            }
            if (anim == "Jump")
            {
                pulou = false;
            }
            atacando = false;
            temp = 0;
        }
    }
}
