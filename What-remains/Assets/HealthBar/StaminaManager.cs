using UnityEngine;

public class StaminaManager : MonoBehaviour
{
    public StaminaBar staminaBar;
    private int maxStamina = 100;
    public float currentStamina; // Use float for smoother increments
    public float timeSinceLastPress;
    private float regenerationDelay = 5f;
    private float regenerationRate = 50f; // Amount of stamina regenerated per second

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.SetMaxStamina(maxStamina);
        timeSinceLastPress = 0f;
        //Debug.Log("Starting Stamina: " + currentStamina);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 'J' key is pressed
        /*if (Input.GetKeyDown(KeyCode.H))
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
        }*/

        if (timeSinceLastPress >= regenerationDelay)
        {
            RegenerateStamina();
        }
        timeSinceLastPress += Time.deltaTime;

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

    public void DecreaseStamina(int amount)
    {
        currentStamina -= amount;
        if (currentStamina < 0)
        {
            currentStamina = 0;
        }
        staminaBar.SetCurrentStamina(currentStamina);
        //Debug.Log("Stamina decreased. Current Stamina: " + currentStamina);
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

    // Method to increase max stamina
    public void IncreaseMaxStamina(int amount)
    {
        maxStamina += amount;
        currentStamina = maxStamina; // Optional: fully replenish stamina when max stamina is increased
        staminaBar.SetMaxStamina(maxStamina);
        staminaBar.SetCurrentStamina(currentStamina);
    }
}
