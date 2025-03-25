namespace MediaVisualizer.Services.Dtos;

public class LimitedStream : Stream
{
    private readonly Stream _innerStream;
    private readonly long _length;
    private long _position;

    public LimitedStream(Stream innerStream, long length)
    {
        _innerStream = innerStream;
        _length = length;
        _position = 0;
    }

    public override bool CanRead => _innerStream.CanRead;
    public override bool CanSeek => _innerStream.CanSeek;
    public override bool CanWrite => false;
    public override long Length => _length;

    public override long Position
    {
        get => _position;
        set => throw new NotSupportedException();
    }

    public override void Flush()
    {
        _innerStream.Flush();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        if (_position >= _length)
            return 0;

        var remaining = _length - _position;
        if (count > remaining)
            count = (int)remaining;

        var read = _innerStream.Read(buffer, offset, count);
        _position += read;
        return read;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        throw new NotSupportedException();
    }

    public override void SetLength(long value)
    {
        throw new NotSupportedException();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        throw new NotSupportedException();
    }
}