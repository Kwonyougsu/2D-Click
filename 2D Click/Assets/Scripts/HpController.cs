using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    public Image img;
    private float Cur_Hp;
    private float Max_Hp;

    public GameObject standing;
    public GameObject die;

    private void Awake()
    {
        SpriteRenderer ChangeSprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        Max_Hp = 100;
        Cur_Hp = Max_Hp;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cur_Hp -= 10;
        }
        img.fillAmount = Cur_Hp / Max_Hp;
        if(Cur_Hp <= 0)
        {
            standing.SetActive(false);
            die.SetActive(true);
        }
    }
}
