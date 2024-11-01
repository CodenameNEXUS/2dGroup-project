using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _image.fillAmount = currentHealth / maxHealth;
    }













}
