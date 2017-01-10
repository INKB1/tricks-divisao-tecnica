using System;
using UnityEngine;

//NOVO

//namespace UnityStandardAssets._2D{
  public class PlatformerCharacter2D : MonoBehaviour{
    [SerializeField] private float m_MaxSpeed = 10f;
    [SerializeField] private float m_JumpForce = 400f;
    [SerializeField] private bool m_AirControl = false;
    [SerializeField] LayerMask m_WhatIsGround;

    private Transform m_GroundCheck;
    const float k_GroundedRadius = .2f;
    private bool m_Grounded;
    private Transform m_CeilingCheck;
    const float k_CeilingRadius = .01f;
    private Animator m_Anim;
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;

    private void Awake(){
      m_GroundCheck = transform.Find("GroundCheck");
      m_CeilingCheck = transform.Find("CeilingCheck");
      m_Anim = GetComponent<Animator>();
      m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate(){
      m_Grounded = false;

      Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
      for(int i=0; i < colliders.Length; i++){
        if (colliders[i].gameObject != gameObject)
          m_Grounded = true;
      }
      m_Anim.SetBool("Ground", m_Grounded);
      m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
    }

    //fazendo modificações nessa parte colocando as animações de cada pulo.
    public void Move(float move, bool extremely, bool beast, bool jump){
      if(m_Grounded || m_AirControl){
        m_Anim.SetFloat("Speed", Mathf.Abs(move));

        m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

        if(move > 0 && !m_FacingRight){
          Flip();
        } else if (move < 0 && m_FacingRight){
          Flip();
        }
      }
      //se o player deve pular
      if (m_Grounded && jump && m_Anim.GetBool("Ground")){
        m_Grounded = false;
        m_Anim.SetBool("Ground", false);
        m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
      }
      //se o player deve realizar o extremely_jump
      if(m_Grounded && extremely && m_Anim.GetBool("Ground")){
        m_Grounded = false;
        m_Anim.SetBool("Ground", false);
        m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
      }
      //se o player deve realizar o beast_jump
      if(m_Grounded && beast && m_Anim.GetBool("Ground")){
        m_Grounded = false;
        m_Anim.SetBool("Ground", false);
        m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
      }
    }

    private void Flip(){
      m_FacingRight = !m_FacingRight;

      Vector3 theScale = transform.localScale;
      theScale.x *= -1;
      transform.localScale = theScale;
    }
  }
//}
