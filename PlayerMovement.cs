using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

  // Movement code from DistortedPixelStudios on yourube, video link - https://www.youtube.com/watch?v=n4N9VEA2GFo

  public float MovementSpeed = 1.5f;
  public float JumpForce = 2;
  public Animator anim;
  public float delay = 0.4f;

  float timer;
  // _Attack;
  bool ADelay;

  private Rigidbody2D _rigidbody;

  float horizontalMove = 0f;

    void Start() {
      _rigidbody = GetComponent<Rigidbody2D>();
      ADelay = false;
      anim.SetBool("_Attack", false);
    }

    public void Update() {

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (Input.GetButtonDown("Horizontal"))  {
        anim.SetBool("Running", true);
        }
        else if (Input.GetButtonUp("Horizontal")) {
          anim.SetBool("Running", false);
        }

          Debug.Log(anim.GetBool("_Attack"));
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
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f) {
          _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
          anim.SetBool("Jumping", true);
        }
        else if (Input.GetButtonUp("Jump")) {
          anim.SetBool("Jumpung", false);
        }
    }
    void AttackOff() {
      anim.SetBool("_Attack", false);
      anim.SetBool("ADelay", false);
    }
}
