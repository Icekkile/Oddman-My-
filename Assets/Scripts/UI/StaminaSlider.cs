using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class StaminaSlider : MonoBehaviour
{
    public Controller watchingController;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (BattleData.ins.Player.controller == null)
            return;
        watchingController = BattleData.ins.Player.controller;

        float stamina = watchingController.Stamina;
        stamina /= 100;
        slider.value = stamina;
    }
}
