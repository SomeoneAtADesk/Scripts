using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
  [SerializeField]  private float JumpForce = 10.5f;
  // Movement code from DistortedPixelStudios on yourube, video link - https://www.youtube.com/watch?v=n4N9VEA2GFo

  public float MovementSpeed = 1.5f;
  public Animator anim;
  public float delay = 0.4f;
  public Vector2 Boxsize; // the size of the jump box
  public float Castdistance; // how far the object that allows jump is
  public LayerMask PlatformLayer; //Set all objects that players want jumper to this Layer

  float timer;
  bool ARDelay;
  bool PlayerGravFlip = true;
  bool _ADelay = false;
  float horizontalMove = 0f;

  private Rigidbody2D _rigidbody;


    void Start() {
      _rigidbody = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();
      anim.SetBool("_Attack", false);
      bool ARDelay = false;
    }

    public void Update() {
      if (ARDelay == false) {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
      }

      if (UserInput.instance.Controls.AttackI.AttackI.WasPressedThisFrame()) {
        bool ARDelay = true;
        Invoke("RunAttack", 0.4f);

      }

        if (Input.GetButton("Horizontal"))  {
        anim.SetBool("Running", true);
        }

        else if (Input.GetButtonUp("Horizontal")) {
          anim.SetBool("Running", false);
        }
// was any attack button pressed this frame,
        if (UserInput.instance.Controls.AttackI.AttackI.WasPressedThisFrame() && _ADelay == false)  {
            _ADelay = true;
            anim.SetBool("_Attack", true);
        }

// turning the attack animation trigger off so that animation will change off when completed.
        if (anim.GetBool("_Attack") == true) {
          timer += Time.deltaTime;
          if (timer > delay) {
            AttackOff();
            timer -= delay;
          }
        }
//Jump Variable Check
        if (Input.GetButtonDown("Jump")) {
//Checks if the Variable isGround is true than applies Jump force and plays Jumping animation.
            if (isGrounded() == true) {
              _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
              anim.SetBool("Jumping", true);
            }
            //If player can't jump, sends debug message. Possiblity of SFX?
            else {
              Debug.Log("Player Can't Jump.");
            }
        }
    }

    void AttackOff() {
      anim.SetBool("_Attack", false);
      _ADelay = false;
    }

    void RunAttack() {
      bool ARDelay = false;
    }
    //when anything enters trigger
    private void OnTriggerEnter2D(Collider2D col) {
      if (col.gameObject.tag == "GravFlip") {
        _rigidbody.gravityScale = -0.5f;
        JumpForce *= -1;
        Castdistance *= -1;
        Invoke("Flip", 0f);
      }
    }
    //WHen anything exits trigger
    private void OnTriggerExit2D(Collider2D col) {
      if (col.gameObject.tag == "GravFlip") {
        _rigidbody.gravityScale = 0.5f;
        JumpForce *= -1;
        Castdistance *= -1;
        Invoke("Flip", 0f);
      }
    }
    //Gravity Flip FUnction
    void Flip() {
      Vector3 currentScale = gameObject.transform.localScale;
      currentScale.y *= -1;
      gameObject.transform.localScale = currentScale;
      PlayerGravFlip = !PlayerGravFlip;
    }
//Jump Command Script from https://www.youtube.com/watch?v=P_6W-36QfLA
//Jump Command
    public bool isGrounded()   {
      //Create A box based off the bunch of variables, not 100% what all do but 0 is angle so don't change.
      if (Physics2D.BoxCast(transform.position, Boxsize, 0, -transform.up, Castdistance, PlatformLayer)) {
        return true;
      }
      else {
        return false;
    }
  }
//Jump Box Visualizer
    private void OnDrawGizmos() {
      Gizmos.DrawWireCube(transform.position-transform.up * Castdistance, Boxsize);
    }
  }
