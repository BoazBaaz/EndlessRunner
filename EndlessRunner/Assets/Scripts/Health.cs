using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageble
{
    [Header("Health")]
    public int m_StartingHealth = 1; //starting health of the object

    //private
    public int healthPoints { get; private set; } //the objects current health
    public bool isAlive { get; private set; } //the alive state of the object

    private void Start()
    {
        healthPoints = m_StartingHealth;
        isAlive = true;
    }

    /// <summary>
    /// Adds the _value to the current health.
    /// </summary>
    /// <param name="_value">The modify amount</param>
    public void ModifyHealth(int _value)
    {
        healthPoints += _value;

        if (healthPoints <= 0)
        {
            isAlive = false;

            if (gameObject.layer == LayerMask.NameToLayer("Player"))
                GameManager.instance.ShowDeathScreen();

            Destroy(gameObject);
        }
    }
}
