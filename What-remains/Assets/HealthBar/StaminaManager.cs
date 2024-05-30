using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public StaminaBar staminaBar;
    private int maxStamina = 100;
    private float currentStamina; // Use float for smoother increments
    private float timeSinceLastPress;
    private float regenerationDelay = 5f;
    private float regenerationRate = 50f; // Amount of stamina regenerated per second

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
        timeSinceLastPress = 0f;
        Debug.Log("Starting Stamina: " + currentStamina);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 'J' key is pressed
        if (Input.GetKeyDown(KeyCode.J))
        {
            DecreaseStamina(20);
            timeSinceLastPress = 0f; // Reset the timer
            Debug.Log("J key pressed. Current Stamina: " + currentStamina);
        }
        else
        {
            // Update the time since the last key press
            timeSinceLastPress += Time.deltaTime;

            // Start regenerating stamina if the delay has passed
            if (timeSinceLastPress >= regenerationDelay)
            {
                RegenerateStamina();
            }
        }
    }

    public void SetMaxStamina(int stamina)
    {
        maxStamina = stamina;
        staminaBar.SetMaxStamina(stamina);
        Debug.Log("Max Stamina set to: " + maxStamina);
    }

    public void SetCurrentStamina(float stamina)
    {
        currentStamina = stamina;
        staminaBar.SetCurrentStamina((int)stamina);
        Debug.Log("Current Stamina set to: " + currentStamina);
    }

    private void DecreaseStamina(int amount)
    {
        currentStamina -= amount;
        if (currentStamina < 0)
        {
            currentStamina = 0;
        }
        staminaBar.SetCurrentStamina(currentStamina);
        Debug.Log("Stamina decreased. Current Stamina: " + currentStamina);
    }

    private void RegenerateStamina()
    {
        // Only regenerate stamina if it's not full
        if (currentStamina < maxStamina)
        {
            currentStamina += regenerationRate * Time.deltaTime;
            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }
            staminaBar.SetCurrentStamina(currentStamina);
            Debug.Log("Stamina regenerated. Current Stamina: " + currentStamina);
        }
    }
}
