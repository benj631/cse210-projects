using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

class EditMp3Metadata : EditMetadata {

    public EditMp3Metadata(string filePath) : base(filePath) {
        this.filePath = filePath;
    }
    public string filePath = "";

    
    public override void ReplaceTag(ref byte[] metadata, string tag, string newValue)
    {
        byte[] tagBytes = Encoding.ASCII.GetBytes(tag);
        int index = 0;
        while ((index = Array.IndexOf(metadata, tagBytes[0], index)) != -1)
        {
            if (index + tagBytes.Length <= metadata.Length)
            {
                bool match = true;
                for (int i = 1; i < tagBytes.Length; i++)
                {
                    if (metadata[index + i] != tagBytes[i])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    int dataLength = (metadata[index + 4] << 24) | (metadata[index + 5] << 16) | (metadata[index + 6] << 8) | metadata[index + 7];
                    byte[] newValueBytes = Encoding.UTF8.GetBytes(newValue);
                    if (dataLength != newValueBytes.Length)
                    {
                        byte[] newDataLengthBytes = BitConverter.GetBytes(newValueBytes.Length);
                        Array.Reverse(newDataLengthBytes);
                        newDataLengthBytes.CopyTo(metadata, index + 4);
                    }
                    Array.Copy(newValueBytes, 0, metadata, index + 10, newValueBytes.Length);
                    break;
                }
                index++;
            }
            else
            {
                break;
            }
        }
    }
}