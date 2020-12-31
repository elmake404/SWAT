using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    #region StaticComponent
    public static bool IsStartGeme, IsGameFlow, IsWinGame, IsLoseGame;
    public static int NamberEnemy;
    public static CanvasManager CanvasMain;
    #endregion

    [SerializeField]
    private GameObject _menuUI, _inGameUI, _wimIU, _lostUI;
    [SerializeField]
    private Image _progresBar;

    private float _fillNaber, _namberProgresBar;
    private void Awake()
    {
        CanvasMain = this;
        IsWinGame = false;
        IsLoseGame = false;
    }
    private void Start()
    {
        _fillNaber = 1f / NamberEnemy;
        if (!IsGameFlow)
        {
            _menuUI.SetActive(true);
            IsGameFlow = true;
        }
        else
        {
            IsStartGeme = true;
        }
    }

    private void Update()
    {
        if (!_inGameUI.activeSelf && IsStartGeme)
        {
            _menuUI.SetActive(false);
            _inGameUI.SetActive(true);
        }

        if (!_wimIU.activeSelf && IsWinGame)
        {
            IsStartGeme = false;
            _inGameUI.SetActive(false);
            _wimIU.SetActive(true);
        }

        if (!_lostUI.activeSelf && IsLoseGame)
        {
            IsStartGeme = false;

            _inGameUI.SetActive(false);
            _lostUI.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        if (_namberProgresBar > _progresBar.fillAmount)
        {
            _progresBar.fillAmount += 0.02f;
            if (_progresBar.fillAmount>=1)
            {
                IsWinGame = true;
            }
        }
    }
    public void AddProgress()
    {
        _namberProgresBar += _fillNaber;
    }
}
