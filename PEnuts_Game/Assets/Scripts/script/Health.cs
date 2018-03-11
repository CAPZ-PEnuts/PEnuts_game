using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public const int maxhealth = 100;
    public int currentHealth = maxhealth;
    public RectTransform healthbar; 
    public void TakeDamage(int amout)
    {
        currentHealth -= amout;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("dead!");
        }
        healthbar.sizeDelta = new Vector2(currentHealth, healthbar.sizeDelta.y); 
    }
}
