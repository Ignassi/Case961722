c﻿using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Build : Editor
{
    [MenuItem("Bild/Bild")]
    public static void PerformTestBuild()
    {
        string[] scenes = { "Assets/Scenes/InitialScene.unity"};
        string path = string.Format("C:/Build/{0}", DateTime.Now.ToString("yyyyMMMddHHmm"));
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        using (TextWriter writer = File.CreateText(path + "/buildlog.txt"))
        {
            writer.WriteLine("Start buid...");
            writer.Write(BuildPipeline.BuildPlayer(scenes, path + "/build.exe", BuildTarget.StandaloneWindows64, BuildOptions.None));
            writer.WriteLine("Finished!");
        }
    }

}
