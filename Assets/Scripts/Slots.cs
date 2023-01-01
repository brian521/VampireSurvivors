using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public GameObject Player;
    PlayerController PC;

    List<GameObject> WeaponSlots = new List<GameObject>();
    List<GameObject> PassiveSlots = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        PC = Player.GetComponent<PlayerController>();

        for (int i = 1; i <= 4; i++)
        {
            WeaponSlots.Add(transform.Find($"W_slot_{i}").transform.GetChild(0).gameObject);
        }
        for (int i = 1; i <= 4; i++)
        {
            PassiveSlots.Add(transform.Find($"P_slot_{i}").transform.GetChild(0).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        WSlot();
        PSlot();
    }

    void WSlot()
    {
        for (int i = 0; i < PC.gainedWeapon.Count; i++)
        {
            WeaponSlots[i].GetComponent<Image>().sprite = PC.gainedWeapon[i];
            WeaponSlots[i].GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        }

    }

    void PSlot()
    {
        for (int i = 0; i < PC.gainedPassive.Count; i++)
            {
                PassiveSlots[i].GetComponent<Image>().sprite = PC.gainedPassive[i];
                PassiveSlots[i].GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            }

    }
}
