using UnityEngine;

public class AttackMouseEvent : MonoBehaviour
{
    private Animator anim;
    private AudioSource AudioSource;

    public HpController HpController;
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
            AudioSource.Stop();
            ResetAnimation();
            anim.SetTrigger("attack");
            AudioSource.Play();

            HpController.Cur_Hp -= 5;
            HpController.img.fillAmount = HpController.Cur_Hp / HpController.Max_Hp;
            if (HpController.Cur_Hp <= 0)
            {
                HpController.standing.SetActive(false);
                HpController.die.SetActive(true);
            }
        }
    }
}
