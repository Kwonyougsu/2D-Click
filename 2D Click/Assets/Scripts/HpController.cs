using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    public Image img;
    public float Cur_Hp;
    public float Max_Hp;

    public GameObject standing;
    public GameObject die;

    private void Awake()
    {
        SpriteRenderer ChangeSprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        Max_Hp = 1000;
        Cur_Hp = Max_Hp;
    }

}
