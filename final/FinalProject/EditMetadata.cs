using System;
using System.IO;
using System.Text;
// using SixLabors.ImageSharp;
public class EditMetadata{

    private string filePath = "";
    public EditMetadata(string filePath){
        this.filePath = filePath;
    }
    public virtual void ReplaceTag(ref byte[] metadata, string tag, string newValue)
    {
        throw new NotImplementedException("ReplaceTag method should be overridden in derived classes.");
    }
    public int FindMarker(byte[] jpegData, int marker1, int marker2){
        int offset = 0;
        while (offset < jpegData.Length - 1)
        {
            if (jpegData[offset] == 0xFF && jpegData[offset + 1] == marker1)
            {
                offset += 2;
                if (BitConverter.ToInt32(jpegData, offset) == marker2)
                {
                    return offset + 4;
                }
            }
            else
            {
                offset++;
            }
        }
        return -1;
    }
}



