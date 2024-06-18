using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScroeValue;
    public TextMeshProUGUI CoinValue;
    public GameObject enemydie;

    public float score;
    public float coin;
    
    void Start()
    {
        score = 0;
        coin = 0;
    }

    void Update()
    {
        UpScore();
    }

    void UpScore()
    {
        float CoinGain = Random.Range(0, 10);

        if (Input.GetMouseButtonDown(0))
        {
            score += 10;
            if (CoinGain > 5)
            {
                coin = coin + 4.5f;
            }
            else { }
        }

        if(enemydie.activeSelf)
        {
            score += 1000;
            coin += 100;
        }

        ScroeValue.text = score.ToString();
        CoinValue.text = coin.ToString();
    }

}
