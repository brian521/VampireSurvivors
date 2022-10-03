using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image img;
    public GameObject Player;
    PlayerController PC;

    // Start is called before the first frame update
    void Start()
    {
        PC = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount = PC.PlayerHp / (float) PC.MaxHp; 
    }

}
