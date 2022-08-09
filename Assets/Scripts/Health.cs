using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public TMP_Text healthText;

    private float value;

    public bool IsDead()
    {
        return value <= 0;
    }

    public void TakeDamage(float damage)
    {
        value -= damage;
    }

    // Start is called before the first frame update
    private void Start()
    {
        value = 100f;
    }

    // Update is called once per frame
    private void Update()
    {
        healthText.text = value.ToString();
    }
}
