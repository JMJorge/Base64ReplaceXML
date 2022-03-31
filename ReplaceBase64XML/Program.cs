using System;
using System.Xml;

namespace ReplaceBase64XML
{
    class Program
    {
        //Encode pdf to base 64
        private static string Encode(string inFileName)
        {
            
            byte[] bytes = System.IO.File.ReadAllBytes(inFileName);
            String file = Convert.ToBase64String(bytes);            
            return file;
        }

        //Add the encoding pdf to the xml file
        private static void ReplaceXml(string xmlfile, string base64)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlfile);

            XmlNodeList DataList = xmlDoc.GetElementsByTagName("cbc:EmbeddedDocumentBinaryObject");
            for (int i = 0; i < DataList.Count; i++)
            {
                //Console.WriteLine(DataList[i].InnerXml);

                DataList[i].InnerXml = base64;
                //Console.WriteLine("Change: {0}", DataList[i].InnerXml);
                //Console.WriteLine();
            }
            //xmlDoc.Save(xmlfile);
            xmlDoc.Save(@"C:\Temp\CFA\FAC_TESTE-ALTER.xml");
        }

        static void Main(string[] args)
        {
            string fac = @"C:\Temp\CFA\FAC.pdf";                           

            const string xmlfile = @"C:\Temp\CFA\FAC_TESTE.xml";

            ReplaceXml(xmlfile, Encode(fac));          

        }
    }
}
