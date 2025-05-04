using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text ammoText;
    public TMP_Text healthText;
    public Image HealthBar;
   

    void Start()   
    {
         WeaponHandler.OnAmmoChanged += UpdateAmmo;
          PlayerHealth.OnHealthChanged += UpdateHealth;
    }

    public void UpdateAmmo(int current, int max)
    {
        ammoText.text = $"{current} / {max}";
    }

    public void UpdateHealth(int current, int max)
    {
        healthText.text = $"HP: {Mathf.RoundToInt(current)}";
        HealthBar.fillAmount = (float)current/(float)max;
    }
}
