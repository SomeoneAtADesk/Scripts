using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
// Movement code from DistortedPixelStudios on yourube, video link - https://www.youtube.com/watch?v=n4N9VEA2GFo
  [SerializeField]  private float JumpForce = 10.5f; // how high you can jump, customisable in inspector so that there can be a different amount for different scenes

  public float MovementSpeed = 1.5f; // The speed that the player moves at. Customise from the inspector
  public Animator anim; // ANIMATION!!!
  public float delay = 0.4f; // A delay for the Attack stop
  public Vector2 Boxsize; // the size of the jump box
  public float Castdistance; // how far the object that allows jump is
  public LayerMask PlatformLayer; //Set all objects that players want jumper to this Layer

  float timer; // Used with the delay to make a short timer to stop the attack if it's held down.
  bool ARDelay; // honestly don't remember, but looks like its trying to make it so that you cant attack then run straight away
  bool PlayerGravFlip = true; // Gravity flip
  float horizontalMove = 0f; // I don't think i ended up using this, but i'm leaving it here just in case

  private Rigidbody2D _rigidbody; // Get the rigidbody component so its usable in the script

    void Start() {
      _rigidbody = GetComponent<Rigidbody2D>(); // get rigidbody so that you can refer to it in the script
      anim = GetComponent<Animator>(); // ANIMATION!!!
      anim.SetBool("_Attack", false); // Set the animation bool to false, just in case it's not already
      bool ARDelay = false; // set the bool to false
    }

    public void Update() {
// If ARDdelay as a bool is set to false, allow the horizontal Axis button status' and if user is pressing a horizontal movement button, move in that direction
      if (ARDelay == false) {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
      }
// If Attack button was pushed in the frame the game is currently running on, set the animation bool to true and run the Function "RunAttack" to run that Function with a delay
      if (UserInput.instance.Controls.AttackI.AttackI.WasPressedThisFrame()) {
        bool ARDelay = true;
        Invoke("RunAttack", 0.4f);
      }
// If the horizontal movement buttons are pressed or being held down, set the animation bool to true so that the animation plays
        if (Input.GetButton("Horizontal"))  {
        anim.SetBool("Running", true);
        }
// and if a horizontal movement button is unpressed, and a different horizontal movement button isn;t still being held or pushed, set the animation bool to false and stop the animation
        else if (Input.GetButtonUp("Horizontal")) {
          anim.SetBool("Running", false);
        }
// was any attack button pressed this frame, if so set the animation bool to true so that the attack animation plays
        if (UserInput.instance.Controls.AttackI.AttackI.WasPressedThisFrame())  {
            anim.SetBool("_Attack", true);
        }
// turning the attack animation trigger off so that animation will change off when completed. Stops the animation getting stuck if button held down.
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
// The Function the timer uses to turn the attack animation off if button is held down. Sets animation bool to false
    void AttackOff() {
      anim.SetBool("_Attack", false);
    }
// Sets the ARDelay bool to false.
    void RunAttack() {
      bool ARDelay = false;
    }
//when anything enters trigger
    private void OnTriggerEnter2D(Collider2D col) {
//checks if objects that collides has the tag "GravFlip"
      if (col.gameObject.tag == "GravFlip") {
// If true, Change the rigidbody gravity to -0.5f so that the player fly's up, changes the jump force to a negitive so that player jumps down, and changed the cast distance of the jump raycast to the underside of the player when gravity is flipped
        _rigidbody.gravityScale = -0.5f;
        JumpForce *= -1;
        Castdistance *= -1;
// Invokes the Flip Function to change the way the player looks in the game, changing the players position to be upsidedown when in grav flip
        Invoke("Flip", 0f);
      }
    }
    //WHen anything exits trigger
    private void OnTriggerExit2D(Collider2D col) {
//checks if objects that collides has the tag "GravFlip"
      if (col.gameObject.tag == "GravFlip") {
// If true, Set everything that was changed in the OnTriggerEnter2D back to the way it was before that
        _rigidbody.gravityScale = 0.5f;
        JumpForce *= -1;
        Castdistance *= -1;
// Invoke the FLip Function to flip the oritation of the player character, back to being unreversed.
        Invoke("Flip", 0f);
      }
    }
    //Gravity Flip Function. Changes the y scale of the player allowing them to look upsidedown. Also changes bool to be the oppersite of what it currently is.
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
