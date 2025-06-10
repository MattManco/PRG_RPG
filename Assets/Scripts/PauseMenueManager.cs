using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PauseMenueManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    private BaseCharacterController baseCC;


    private void Start()
    {
        baseCC = FindObjectOfType<BaseCharacterController>();

        EnablePauseMenu(true);
    }

    public void TogglePauseMenu()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);

        baseCC.PausePlayer(pauseMenuUI.activeSelf);
    }

    public void EnablePauseMenu(bool isEnabled)
    {
        if(isEnabled)
            GetComponent<PlayerInput>().actions.FindAction("Pause").performed += ctx => TogglePauseMenu();
        else
            GetComponent<PlayerInput>().actions.FindAction("Pause").performed -= ctx => TogglePauseMenu();
    }
}
