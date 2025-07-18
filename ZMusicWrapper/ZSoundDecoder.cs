using ZMusicWrapper.Generated;
using System;

namespace ZMusicWrapper;

public enum SampleType
{
    UInt8,
    Int16,
    Float32,
}

public unsafe class ZSoundDecoder : IDisposable
{
    private readonly SoundDecoder* m_soundDecoder;

    public readonly int SampleRate;
    public readonly bool Stereo;
    public readonly SampleType SampleType;

    public ZSoundDecoder(byte[] data)
    {
        int sampleRate;
        ChannelConfig_ channelConfig;
        SampleType_ sampleType;
        fixed (byte* ptr = data)
            m_soundDecoder = ZMusic.CreateDecoder(ptr, (nuint)data.Length, 1);

        if (m_soundDecoder == null)
            return;

        ZMusic.SoundDecoder_GetInfo(m_soundDecoder, &sampleRate, &channelConfig, &sampleType);
        SampleRate = sampleRate;
        Stereo = channelConfig == ChannelConfig_.ChannelConfig_Stereo;
        SampleType = (SampleType)sampleType;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        ZMusic.SoundDecoder_Close(m_soundDecoder);
    }

    public unsafe int DecodeRead(Span<byte> buffer)
    {
        fixed (byte* ptr = buffer)
            return (int)ZMusic.SoundDecoder_Read(m_soundDecoder, ptr, (nuint)buffer.Length);
    }
}
