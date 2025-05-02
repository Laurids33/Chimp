using UnityEditor;
using UnityEngine;

public class BuildAllPlatforms
{
    private static string[] scenes = { "Assets/Scenes/SampleScene.unity" }; // Passe das ggf. an

    [MenuItem("Build/Build All Targets")]
    public static void BuildAll()
    {
        // Windows Intel 64-bit
        BuildPipeline.BuildPlayer(scenes, "Builds/Windows64/MyGame.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);

        // Windows ARM64
        BuildPipeline.BuildPlayer(scenes, "Builds/WindowsARM64/MyGame.exe", BuildTarget.StandaloneWindows64, BuildOptions.None); // Hinweis: Unity unterstützt ARM64 nur über zusätzliche Konfiguration oder bestimmte Versionen

        // WebGL Brotli
        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Brotli;
        BuildPipeline.BuildPlayer(scenes, "Builds/WebGL_Brotli", BuildTarget.WebGL, BuildOptions.None);

        // WebGL No Compression
        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Disabled;
        BuildPipeline.BuildPlayer(scenes, "Builds/WebGL_NoCompression", BuildTarget.WebGL, BuildOptions.None);

        // Linux
        BuildPipeline.BuildPlayer(scenes, "Builds/Linux/MyGame.x86_64", BuildTarget.StandaloneLinux64, BuildOptions.None);

        // macOS
        BuildPipeline.BuildPlayer(scenes, "Builds/macOS/MyGame.app", BuildTarget.StandaloneOSX, BuildOptions.None);
    }
}
