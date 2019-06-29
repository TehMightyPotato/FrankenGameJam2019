﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceToContinueScript : MonoBehaviour
{
    public void Update()
    {
        if (Input.anyKeyDown)
        {
            PressButtonToContinue();
        }
    }

    public void PressButtonToContinue()
    {
        SceneManager.LoadScene("Credits");
    }
}
