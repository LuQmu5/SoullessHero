﻿using UnityEngine;

public static class PauseManager
{
    public static void Pause()
    {
        Time.timeScale = 0;
    }

    public static void Unpause()
    {
        Time.timeScale = 1;
    }
}
