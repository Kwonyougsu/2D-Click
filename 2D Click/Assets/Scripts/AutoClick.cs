using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class AutoClick : MonoBehaviour
{
    public float clickInterval = 2.0f; 
    private bool isAutoClicking = false;

    public GameObject StartText;
    public GameObject endText;
    public HpController HpController;

    private Animator anim;
    private AudioSource AudioSource;
    private Score Score;

    void Awake()
    {
        anim = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
        Score = GetComponent<Score>();
    }
    private void Start()
    {
        StartText.SetActive(true);
        endText.SetActive(false);
    }

    public void Update()
    {
        StartText.SetActive(!isAutoClicking);
        endText.SetActive(isAutoClicking);
    }

    IEnumerator AutoClickRoutine()
    {
        while (isAutoClicking)
        {
            PerformClick();
            yield return new WaitForSeconds(clickInterval);
        }
    }

    void PerformClick()
    {
        anim.SetTrigger("attack");
        AudioSource.Play();

        HpController.Cur_Hp -= 5;
        HpController.img.fillAmount = HpController.Cur_Hp / HpController.Max_Hp;
        if (HpController.Cur_Hp <= 0)
        {
            HpController.standing.SetActive(false);
            HpController.die.SetActive(true);
        }

        float CoinGain = Random.Range(0, 10);
        Score.score += 10;
        if (CoinGain > 5)
        {
            Score.coin = Score.coin + 4.5f;
        }
        else { }

        if (Score.enemydie.activeSelf)
        {
            Score.score += 1000;
            Score.coin += 100;
        }
    }

    public void ToggleAutoClick()
    {
        isAutoClicking = !isAutoClicking;

        if (isAutoClicking)
        {
            StartCoroutine(AutoClickRoutine());
        }
    }
}
