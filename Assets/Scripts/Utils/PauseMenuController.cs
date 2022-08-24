using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public List<GameObject> hud = new List<GameObject>();
    public AudioSource musicPlayer;
    public bool paused;
    private float originalTime;

    public void PauseGame()
    {
        Cursor.visible = true;
        musicPlayer.mute = true;
        pauseMenu.SetActive(true);
        HUDOn();

        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    public void UnPauseGame()
    {
        Cursor.visible = false;
        musicPlayer.mute = false;
        paused = false;
        pauseMenu.SetActive(false);
        HUDOff();

        Time.timeScale = 1;
        Time.fixedDeltaTime = originalTime;
    }

    public void HUDOn()
    {
        foreach (var objs in hud)
            objs.SetActive(false);
    }

    public void HUDOff()
    {
        foreach (var objs in hud)
            objs.SetActive(true);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void Start()
    {
        Cursor.visible = false;
        paused = false;
        pauseMenu.SetActive(false);
        originalTime = Time.fixedDeltaTime;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == true)
            {
                paused = false;
                UnPauseGame();
            }
            else
            {
                paused = true;
                PauseGame();
            }
        }
    }
}