﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("level1");

    }
}
