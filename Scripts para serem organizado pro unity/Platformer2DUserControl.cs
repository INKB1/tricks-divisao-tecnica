using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

//NOVO

//name UnityStandardAssets._2D{
  [RequireComponent(typeof(PlatformerCharacter2D))]
  public class Platformer2DUserControl : MonoBehaviour{
    private PlatformerCharacter2D m_Character;
    private bool m_Jump;
    private bool beast_Jump;
    private bool extremely_Jump;

    private void Awake(){
      m_Character = GetComponent<PlatformerCharacter2D>();
    }

    private void Update(){
      if(!m_Jump || !beast_Jump || !extremely_Jump){
        m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        beast_Jump = Input.GetKeyDown(KeyCode.Z);
        extremely_Jump = Input.GetKeyDown(KeyCode.X);
      }
    }

    private void FixedUpdate(){
      float h = 1;
      m_Character.Move(h, extremely_Jump, beast_Jump, m_Jump);
      m_Jump = false;
      extremely_Jump = false;
      beast_Jump = false;
    }
  }
//}
