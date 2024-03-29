using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    public UI Ui;
    public int Ennemies;
    [SerializeField] PlayerController _playerController;

    public void CheckVictory()
    {
        if (Ennemies <= 0)
        {
            Ui.WinScreen.SetActive(true);
        }
        else if (_playerController.IsDead)
        {
            Ui.LoseScreen.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
