using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifeController : MonoBehaviour
{
    [SerializeField] Image lifebar;

    public void UpdateLifeBar(float hp, float maxHp)
    {
        lifebar.fillAmount = hp / maxHp;
    }
}
