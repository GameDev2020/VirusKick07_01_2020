﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SpeedTutorMainMenuSystem
{
    public class MenuController : MonoBehaviour
    {
        #region Default Values
        [Header("Default Menu Values")]
        [SerializeField] private float defaultBrightness;
        [SerializeField] private float defaultVolume;
        [SerializeField] private int defaultSen;
        [Header("Levels To Load")]
        public string _newGameButtonLevel;
        private string levelToLoad;

        private int menuNumber;
        #endregion

        #region Menu Dialogs
        [Header("Main Menu Components")]
        [SerializeField] private GameObject menuDefaultCanvas;
        [SerializeField] private GameObject GeneralSettingsCanvas;
        [SerializeField] private GameObject soundMenu;
        [SerializeField] private GameObject gameplayMenu;
        [SerializeField] private GameObject controlsMenu;
        [Space(10)]
        [Header("Menu Popout Dialogs")]
        [SerializeField] private GameObject noSaveDialog;
        [SerializeField] private GameObject newGameDialog;
        #endregion

        #region Slider Linking
        [Header("Menu Sliders")]
        [SerializeField] private Text controllerSenText;
        [SerializeField] private Slider controllerSenSlider;
        public float controlSenFloat = 2f;
        [Space(10)]
        [SerializeField] private Brightness brightnessEffect;
        [SerializeField] private Slider brightnessSlider;
        [SerializeField] private Text brightnessText;
        [Space(10)]
        [SerializeField] private Text volumeText;
        [SerializeField] private Slider volumeSlider;
        [Space(10)]
        [SerializeField] private Toggle invertYToggle;
        #endregion

        #region Initialisation - Button Selection & Menu Order
        private void Start()
        {
            menuNumber = 1;
        }
        #endregion

        //MAIN SECTION
 

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menuNumber == 2 || menuNumber == 7 || menuNumber == 8)
                {
                    GoBackToMainMenu();
                    ClickSound();
                }

                else if (menuNumber == 3 || menuNumber == 4 || menuNumber == 5)
                {
                    GoBackToOptionsMenu();
                    ClickSound();
                }

                else if (menuNumber == 6) //CONTROLS MENU
                {
                    GoBackToGameplayMenu();
                    ClickSound();
                }
            }
        }

        private void ClickSound()
        {
            GetComponent<AudioSource>().Play();
        }

        #region Menu Mouse Clicks
        public void MouseClick(string buttonType)
        {
            if (buttonType == "Controls")
            {
                gameplayMenu.SetActive(false);
                controlsMenu.SetActive(true);
                menuNumber = 6;
            }

            if (buttonType == "Graphics")
            {
                GeneralSettingsCanvas.SetActive(false);
                menuNumber = 3;
            }

            if (buttonType == "Sound")
            {
                GeneralSettingsCanvas.SetActive(false);
                soundMenu.SetActive(true);
                menuNumber = 4;
            }

            if (buttonType == "Gameplay")
            {
                GeneralSettingsCanvas.SetActive(false);
                gameplayMenu.SetActive(true);
                menuNumber = 5;
            }

            if (buttonType == "Exit")
            {
                Debug.Log("YES QUIT!");
                Application.Quit();
            }

            if (buttonType == "Options")
            {
                menuDefaultCanvas.SetActive(false);
                GeneralSettingsCanvas.SetActive(true);
                menuNumber = 2;
            }

            if (buttonType == "NewGame")
            {
                menuDefaultCanvas.SetActive(false);
                newGameDialog.SetActive(true);
                menuNumber = 7;
            }
        }
        #endregion

        public void VolumeSlider(float volume)
        {
            AudioListener.volume = volume;
            volumeText.text = volume.ToString("0.0");
        }

        public void VolumeApply()
        {
            PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
            Debug.Log(PlayerPrefs.GetFloat("masterVolume"));
        }

        public void BrightnessSlider(float brightness)
        {
            brightnessEffect.brightness = brightness;
            brightnessText.text = brightness.ToString("0.0");
        }

        public void BrightnessApply()
        {
            PlayerPrefs.SetFloat("masterBrightness", brightnessEffect.brightness);
            Debug.Log(PlayerPrefs.GetFloat("masterBrightness"));
            
        }

        public void ControllerSen()
        {
            controllerSenText.text = controllerSenSlider.value.ToString("0");
            controlSenFloat = controllerSenSlider.value;
        }

        public void GameplayApply()
        {


            PlayerPrefs.SetFloat("masterSen", controlSenFloat);
            Debug.Log("Sensitivity" + " " + PlayerPrefs.GetFloat("masterSen"));

          
        }

        #region ResetButton
        public void ResetButton(string GraphicsMenu)
        {
            if (GraphicsMenu == "Brightness")
            {
                brightnessEffect.brightness = defaultBrightness;
                brightnessSlider.value = defaultBrightness;
                brightnessText.text = defaultBrightness.ToString("0.0");
                BrightnessApply();
            }

            if (GraphicsMenu == "Audio")
            {
                AudioListener.volume = defaultVolume;
                volumeSlider.value = defaultVolume;
                volumeText.text = defaultVolume.ToString("0.0");
                VolumeApply();
            }

            if (GraphicsMenu == "Graphics")
            {
                controllerSenText.text = defaultSen.ToString("0");
                controllerSenSlider.value = defaultSen;
                controlSenFloat = defaultSen;

                invertYToggle.isOn = false;

                GameplayApply();
            }
        }
        #endregion

        public void ClickNewGameDialog(string ButtonType)
        {
            if (ButtonType == "Yes")
            {
                SceneManager.LoadScene(_newGameButtonLevel);
            }

            if (ButtonType == "No")
            {
                GoBackToMainMenu();
            }
        }



        #region Back to Menus
        public void GoBackToOptionsMenu()
        {
            GeneralSettingsCanvas.SetActive(true);
            soundMenu.SetActive(false);
            gameplayMenu.SetActive(false);

            GameplayApply();
            BrightnessApply();
            VolumeApply();

            menuNumber = 2;
        }

        public void GoBackToMainMenu()
        {
            menuDefaultCanvas.SetActive(true);
            newGameDialog.SetActive(false);
            noSaveDialog.SetActive(false);
            GeneralSettingsCanvas.SetActive(false);
            soundMenu.SetActive(false);
            gameplayMenu.SetActive(false);
            menuNumber = 1;
        }

        public void GoBackToGameplayMenu()
        {
            controlsMenu.SetActive(false);
            gameplayMenu.SetActive(true);
            menuNumber = 5;
        }

        public void ClickQuitOptions()
        {
            GoBackToMainMenu();
        }

        public void ClickNoSaveDialog()
        {
            GoBackToMainMenu();
        }
        #endregion
    }
}
