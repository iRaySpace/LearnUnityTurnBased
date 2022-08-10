using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public TMP_Text healthText;
    public float value = 100f;

    public bool IsDead()
    {
        return value <= 0;
    }

    public void TakeDamage(float damage)
    {
        value -= damage;
    }

    // Start is called before the first frame update
    // private void Start() {}

    // Update is called once per frame
    private void Update()
    {
        healthText.text = value.ToString();
    }
}
