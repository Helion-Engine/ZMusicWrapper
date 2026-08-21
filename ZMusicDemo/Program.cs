namespace ZMusicDemo
{
    using System;
    using System.IO;
    using OpenTK.Audio.OpenAL;

    public class Program
    {
        // This is just a simple demo program to test ZMusic and OpenAL integration.

        public static unsafe void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: 'ZMusicDemo <songFileName1> <songFileName2> ... <songFileNameN>'");
                return;
            }

            if (OperatingSystem.IsMacOS())
            {
                // There are two possible search paths depending on whether we are in a non runtime-specific build or not.
                string noRuntimePath = Path.Combine(AppContext.BaseDirectory, "libopenal.dylib");
                string runtimePath = Path.Combine(AppContext.BaseDirectory, "runtimes/osx-arm64/native/libopenal.dylib");

                if (Path.Exists(runtimePath))
                {
                    OpenALLibraryNameContainer.OverridePath = runtimePath;
                }
                else if (Path.Exists(noRuntimePath))
                {
                    OpenALLibraryNameContainer.OverridePath = noRuntimePath;
                }
                else
                {
                    throw new InvalidOperationException("Cannot find OpenAL-Soft");
                }
            }

            Console.WriteLine($"Asking OpenTK to use OpenAL library: {OpenALLibraryNameContainer.OverridePath}");
            SimplePlayer.Play(args);
        }
    }
}
