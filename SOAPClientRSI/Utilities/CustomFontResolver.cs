using PdfSharp.Fonts;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using ServiceReference;
using System;

namespace SOAPClientRSI.Utilities
{

    // Implement a font resolver
    public class CustomFontResolver : IFontResolver
    {
        public byte[] GetFont(string faceName)
        {
            // Return the binary data of the font file based on the face name
            switch (faceName.ToLower())
            {
                case "arial":
                    return File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "../../../fonts/Arial.ttf"); // Change the path as needed
                                                                             // Add other font mappings as necessary
                default:
                    return null; // Font not found
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            // Return font information based on the family name
            if (familyName.ToLower() == "arial")
            {
                // For simplicity, assume regular style for Arial
                return new FontResolverInfo("Arial");
            }
            else
            {
                return null; // Font not found
            }
        }
    }
}
