using UnityEngine;
using System.Collections;

public class MarkScript : MonoBehaviour
{
    //variaveis controladoras de multiclicks
    private float _buttonDownPhaseStart;
    private float _doubleClickPhaseStart;
    public float timeDoubleClick = 0.0f;
    public float timeLongClick = 0.0f;

    Animator anim;
    private Transform p_Transform;
    private Rigidbody2D rb2d;
    [SerializeField] private float jumpForce = 400f;
    int jumpHash = Animator.StringToHash("Jump");
    int beastHash = Animator.StringToHash("Beast_Jump");
    int extremelyHash = Animator.StringToHash("Extremely_Jump");
    bool jump2 = false, jump3 = false;
    int countJump = 0;
    Renderer carga1, carga2, carga3, carga4;
    public GameObject go1, go2, go3, go4;
    bool m_GroundCheck = false;

  void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            m_GroundCheck = true;
        }else
        {
            m_GroundCheck = false;
        }
        Debug.Log(m_GroundCheck);
    }

    void Start()
    {
        p_Transform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        carga1 = go1.GetComponent<Renderer>();
        carga2 = go2.GetComponent<Renderer>();
        carga3 = go3.GetComponent<Renderer>();
        carga4 = go4.GetComponent<Renderer>();
        carga1.enabled = false;
        carga2.enabled = false;
        carga3.enabled = false;
        carga4.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_GroundCheck)
        {
            _buttonDownPhaseStart = Time.time;
        }

        if (_doubleClickPhaseStart > -1 && (Time.time - _doubleClickPhaseStart) > timeDoubleClick)
        {
            Debug.Log("Single Click");
            _doubleClickPhaseStart = -1;
            m_GroundCheck = false;
            anim.SetTrigger(jumpHash);
            rb2d.AddForce(new Vector2(0f, jumpForce));
            anim.Play("Jump");
        }

        if (Input.GetKeyUp(KeyCode.Space) && m_GroundCheck)
        {
            if (Time.time - _buttonDownPhaseStart > timeLongClick)
            {
                Debug.Log("Long Click");
                _doubleClickPhaseStart = -1;
                m_GroundCheck = false;
                anim.SetTrigger(beastHash);
                rb2d.AddForce(new Vector2(0f, jumpForce));
                anim.Play("Beast_Jump");
                jump2 = true;
            }
            else
            {
                if (Time.time - _doubleClickPhaseStart < timeDoubleClick)
                {
                    Debug.Log("Double Click");
                    _doubleClickPhaseStart = -1;
                    m_GroundCheck = false;
                    anim.SetTrigger(extremelyHash);
                    rb2d.AddForce(new Vector2(0f, jumpForce));
                    anim.Play("Extremely_Jump");
                    jump3 = true;
                }
                else
                {
                    _doubleClickPhaseStart = Time.time;
                }
            }
            /*if (Input.GetKeyDown(KeyCode.Space) && m_GroundCheck)
            {
                m_GroundCheck = false;
                //Debug.Log(m_GroundCheck);
                anim.SetTrigger (jumpHash);
                rb2d.AddForce(new Vector2(0f, jumpForce));
                anim.Play("Jump");
            }
            if (Input.GetKeyDown(KeyCode.Z) && m_GroundCheck)
            {
                //Debug.Log(m_GroundCheck);
                m_GroundCheck = false;
                anim.SetTrigger (beastHash);
                rb2d.AddForce(new Vector2(0f, jumpForce));
                anim.Play("Beast_Jump");
                jump2 = true;
            }
            if (Input.GetKeyDown(KeyCode.X) && m_GroundCheck)
            {
              //Debug.Log(m_GroundCheck);
              m_GroundCheck = false;
              anim.SetTrigger(extremelyHash);
              rb2d.AddForce(new Vector2(0f, jumpForce));
              anim.Play("Extremely_Jump");
              jump3 = true;
            }*/

            IniciarBarraManobra();
        }
    }

    void FixedUpdate()
    {
        anim.SetFloat("vSpeed", rb2d.velocity.y);
        anim.ResetTrigger(jumpHash);
        anim.ResetTrigger(beastHash);
        anim.ResetTrigger(extremelyHash);
        jump2 = false;
        jump3 = false;
    }

    void IniciarBarraManobra()
    {
        //adiciona mais um sempre que é detectado um "super pulo"
        if(jump2 || jump3)
        {
            countJump++;

        }

        if(countJump == 5)
        {
            carga1.enabled = true;
            Debug.Log("Carga 1 Ativada");
        }

        if(countJump == 10)
        {
            carga2.enabled = true;
            Debug.Log("Carga 2 Ativada");
        }
        if(countJump == 15)
        {
            carga3.enabled = true;
            Debug.Log("Carga 3 Ativada");
        }
        if(countJump == 20)
        {
            carga4.enabled = true;
            Debug.Log("Carga 4 Ativada");
        }

        if(countJump > 20)
        {
            countJump = 0;
        }
    }
}
