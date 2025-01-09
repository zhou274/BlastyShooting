using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OnefallGames;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI missileTxt;
    [SerializeField] private TextMeshProUGUI bombTxt;
    [SerializeField] private TextMeshProUGUI laserTxt;
    [SerializeField] private TextMeshProUGUI coins;
    //[SerializeField] private GameObject GameMenu;
    public void BuyBomb()
    {
        if(CoinManager.Instance.Coins>50)
        {
            ItemsManager.Instance.AddBomb(1);
            CoinManager.Instance.RemoveCoins(50);
        }
    }
    
    public void ButLaser()
    {
        if (CoinManager.Instance.Coins > 50)
        {
            ItemsManager.Instance.AddLaser(1);
            CoinManager.Instance.RemoveCoins(50);
        }
        
    }
    public void BuyMissile()
    {
        if (CoinManager.Instance.Coins > 50)
        {
            ItemsManager.Instance.AddMissile(1);
            CoinManager.Instance.RemoveCoins(50);
        }
        
    }
    public void BackMenu()
    {
        gameObject.SetActive(false);
    }
    public void Shop()
    {
        
    }
    private void Update()
    {
        missileTxt.text = ItemsManager.Instance.Missiles.ToString();
        bombTxt.text = ItemsManager.Instance.Bombs.ToString();
        laserTxt.text = ItemsManager.Instance.Lasers.ToString();
        coins.text = CoinManager.Instance.Coins.ToString();
    }
}
