using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float baseHealth = 3f;
    float playerHealth;
    [SerializeField] int damage = 1;
    Text healthText;

    
    void Start()
    {
        playerHealth = baseHealth - PlayerPrefsController.GetDifficulty();
        healthText = GetComponent<Text>();
        UpdateDisplay();
        Debug.Log("difficulty setting currently is " + PlayerPrefsController.GetDifficulty());
    }
    private void UpdateDisplay()
    {
        healthText.text = playerHealth.ToString();
    }
    public void TakeHealth()
    {        
        playerHealth -= damage;
        UpdateDisplay();    
        
        if(playerHealth <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
