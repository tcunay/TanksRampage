using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _kills;

    private int _currentKills = 0;

    public void OnKillsChanged(int reward)
    {
        Debug.Log("Kill");
        //_player.AddMoney(reward);
        _currentKills++;
        _kills.text = _currentKills.ToString();
    }
}
