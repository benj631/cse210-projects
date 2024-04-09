using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
// using SixLabors.ImageSharp;
// using SixLabors.ImageSharp.Processing;
class EditImageMetadata : EditMetadata{

    public EditImageMetadata(string filePath) : base(filePath) {
        this.filePath = filePath;
    }
    private string filePath = "filePath";
    public void WriteMetadata(string filePath, string fieldToEdit, string newValue){
        
        // Resize the image in place and return it for chaining.
        // 'x' signifies the current image processing context.
        // ImageInfo imageInfo = Image.Identify(@"filepath");
        // The library automatically picks an encoder based on the file extension then
        // encodes and write the data to disk.
        // You can optionally set the encoder to choose.
        // imageInfo.Save("bar.jpg"); 
        
            // Dispose - releasing memory into a memory pool ready for the next image you wish to process.

    }
}