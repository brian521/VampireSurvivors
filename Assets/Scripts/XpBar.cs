using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slXp;
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
        slXp.value = PC.currentXp / (float)PC.requiredXp[PC.currentLevel];



        if (slXp.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);
    }


}
