using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public Image fill; // This field is not used but kept for completeness

    public void SetMaxStamina(int stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
    }

    public void SetCurrentStamina(float stamina)
    {
        slider.value = stamina;
    }
}
