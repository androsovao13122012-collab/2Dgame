using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPanel : MonoBehaviour
{
    public GameObject panel;
    public bool isActivePanel;
    private void Start()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isActivePanel = !isActivePanel;
            panel.SetActive(isActivePanel);
            Time.timeScale = isActivePanel?0:1;
        }
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
}
