using System.IO;
using Tamir.SharpSsh.java.io;

public class GenericSftpInputStream : InputStream
{
    Stream stream;
    public GenericSftpInputStream(Stream stream)
    {
        this.stream = stream;
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        return stream.Read(buffer, offset, count);
    }

    public override void Flush()
    {
        stream.Flush();
    }

    public override void Close()
    {
        stream.Close();
    }

    public override bool CanSeek
    {
        get { return stream.CanSeek; }
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        return stream.Seek(offset, origin);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (this.stream != null)
        {
            this.stream.Dispose();
            this.stream = null;
        }
    }
}