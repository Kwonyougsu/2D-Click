using UnityEngine;

public class AttackMouseEvent : MonoBehaviour
{

    private Animator anim;
    private AudioSource AudioSource;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
    }

    void ResetAnimation()
    {
        anim.SetBool("isLookUp", false);
        anim.SetBool("isRun", false);
        anim.SetBool("isJump", false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ResetAnimation();
            anim.SetTrigger("attack");
            AudioSource.Play();
        }
    }
}
