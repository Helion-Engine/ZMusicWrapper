namespace ZMusicWrapper.Generated;

using System.Runtime.InteropServices;

public static unsafe partial class ZMusic
{
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_SetGenMidi([NativeTypeName("const uint8_t *")] byte* data);
    
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("ZMusic_MusicStream")]
    public static extern _ZMusic_MusicStream_Struct* ZMusic_OpenSongMem([NativeTypeName("const void *")] void* mem, [NativeTypeName("size_t")] nuint size, [NativeTypeName("EMidiDevice")] EMidiDevice_ device, [NativeTypeName("const char *")] sbyte* Args);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ZMusic_FillStream([NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* stream, void* buff, int len);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ZMusic_Start([NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* song, int subsong, [NativeTypeName("zmusic_bool")] byte loop);

    //[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern void ZMusic_Pause([NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* song);

    //[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern void ZMusic_Resume([NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* song);

    //[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    //public static extern void ZMusic_Update([NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* song);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ZMusic_IsPlaying([NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* song);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_Stop([NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* song);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_Close([NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* song);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ZMusic_IsMIDI([NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* song);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ZMusic_GetStreamInfo([NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* song, [NativeTypeName("SoundStreamInfo *")] SoundStreamInfo_* info);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ChangeMusicSettingInt([NativeTypeName("EIntConfigKey")] EIntConfigKey_ key, [NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* song, int value, int* pRealValue);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ChangeMusicSettingFloat([NativeTypeName("EFloatConfigKey")] EFloatConfigKey_ key, [NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* song, float value, float* pRealValue);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("zmusic_bool")]
    public static extern byte ChangeMusicSettingString([NativeTypeName("EStringConfigKey")] EStringConfigKey_ key, [NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* song, [NativeTypeName("const char *")] sbyte* value);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("struct SoundDecoder *")]
    public static extern SoundDecoder* CreateDecoder([NativeTypeName("const uint8_t *")] byte* data, [NativeTypeName("size_t")] nuint size, [NativeTypeName("zmusic_bool")] byte isstatic);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SoundDecoder_GetInfo([NativeTypeName("struct SoundDecoder *")] SoundDecoder* decoder, int* samplerate, [NativeTypeName("ChannelConfig *")] ChannelConfig_* chans, [NativeTypeName("SampleType *")] SampleType_* type);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint SoundDecoder_Read([NativeTypeName("struct SoundDecoder *")] SoundDecoder* decoder, void* buffer, [NativeTypeName("size_t")] nuint length);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SoundDecoder_Close([NativeTypeName("struct SoundDecoder *")] SoundDecoder* decoder);

    public static bool ChangeMusicSetting([NativeTypeName("EStringConfigKey")] EStringConfigKey_ key, [NativeTypeName("ZMusic_MusicStream")] _ZMusic_MusicStream_Struct* song, [NativeTypeName("const char *")] sbyte* value)
    {
        return ChangeMusicSettingString(key, song, value) != 0;
    }
}
