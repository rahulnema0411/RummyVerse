using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coins;
    [SerializeField] private TextMeshProUGUI keys;
    [SerializeField] private Image healthIcon;
    [SerializeField] private List<Sprite> heartCollection;

    private void OnEnable()
    {
        LevelManager.UpdateCoinsEvent += UpdateCoins;
        LevelManager.UpdateKeyEvent += UpdateKeys;
        Player.HitEvent += UpdateHealth;
    }

    private void UpdateHealth(object sender, int e)
    {
        healthIcon.sprite = heartCollection[e];
    }

    private void OnDisable()
    {
        LevelManager.UpdateCoinsEvent -= UpdateCoins;
        LevelManager.UpdateKeyEvent -= UpdateKeys;
        Player.HitEvent -= UpdateHealth;
    }

    private void UpdateCoins()
    {
        coins.text = LevelManager.instance.GetCoins().ToString();
    }

    private void UpdateKeys()
    {
        keys.text = LevelManager.instance.IsKeyCollected() ? "1" : "0";
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
