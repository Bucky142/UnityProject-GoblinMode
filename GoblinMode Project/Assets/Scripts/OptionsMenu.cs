using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public WeaponSwing RotateSwordScript;
    public Slider SwordVelocitySlider;

    private void Start()
    {
        RotateSwordScript = GameObject.Find("Pivot").GetComponent<WeaponSwing>();
    }
    public void UpdateSwingVelocity()
    {        
        RotateSwordScript.autoSwingVelocity = (int)SwordVelocitySlider.value;
    }
}
