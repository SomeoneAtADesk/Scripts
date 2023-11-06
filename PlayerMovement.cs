using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

  // Movement code from DistortedPixelStudios on yourube, video link - https://www.youtube.com/watch?v=n4N9VEA2GFo
  
  //State all Valuables
  public float MovementSpeed = 1.5f;
  public float JumpForce = 2;
  public Animator anim;
  public float delay = 0.4f;
  public Vector2 Boxsize;
  public float Castdistance;
  public LayerMask PlatformLayer; //Set all objects that players want jumper to this Layer

  float timer;
  // _Attack;
  bool ADelay;
  private Rigidbody2D _rigidbody;

    void Start() {
      _rigidbody = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();
      ADelay = false;
      anim.SetBool("_Attack", false);
    }

    public void Update() {

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButton("Horizontal"))  {
        anim.SetBool("Running", true);
        }
        else if (Input.GetButtonUp("Horizontal")) {
          anim.SetBool("Running", false);
        }

          //Debug.Log(anim.GetBool("_Attack"));
          // ^^ see when Attack on and off are triggered, helpful for fixing.

      // TODO: Prevent the glitch that occurs when spamming the click button rapidly

        if (Input.GetMouseButtonDown(0) && anim.GetBool("_Attack") == false)  {
            anim.SetBool("_Attack", true);
            anim.SetBool("ADelay", true);
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

    //If clicking being held, turn off anim.
    void AttackOff() {
      anim.SetBool("_Attack", false);
    }
    
    //Jump Command Script from https://www.youtube.com/watch?v=P_6W-36QfLA
    //Jump Command
    public bool isGrounded() 
    {
      //Create A box based off the bunch of variables, not 100% what all do but 0 is angle so don't change.
      if (Physics2D.BoxCast(transform.position, Boxsize, 0, -transform.up, Castdistance, PlatformLayer)) {
        return true;
      }
      else
      {
        return false;
      }
    }

    //Jump Box Visualizer
    private void OnDrawGizmos() 
    {
      Gizmos.DrawWireCube(transform.position-transform.up * Castdistance, Boxsize);
    } 
}
