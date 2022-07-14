using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;

namespace JSON_to_PDF_resume
{
    public partial class Form1 : Form
    {
        private readonly string filepath = @"C:\Users\Alver\source\repos\PDF_RESUME_GENERATOR\jsconfig1.JSON";
        public Form1()
        {
            InitializeComponent();
        }

        public class Resumeimfo
        {
            public string Fullname { get; set; }
            public string Objective { get; set; }
            public string Objective2 { get; set; }
            public string Objective3 { get; set; }
            public string Objective4 { get; set; }
            public string Objective5 { get; set; }
            public string Primary { get; set; }
            public string PrimaryGraduated { get; set; }
            public string Secondary { get; set; }
            public string SecondaryGraduated { get; set; }
            public string Tertiary { get; set; }
            public string TertiaryGraduated { get; set; }
            public string Assets1 { get; set; }
            public string Assets2 { get; set; }
            public string Assets3 { get; set; }
            public string Assets4 { get; set; }
            public string Email { get; set; }
            public string Number { get; set; }
            public string Address { get; set; }
            public string Birth { get; set; }
            public string PlaceofBirth { get; set; }
            public string CivilStatus { get; set; }
            public string Citizenship { get; set; }

        }

        private void GenerateBTN_Click(object sender, EventArgs e)
        {
            string jsonFile;
            using (var reader = new StreamReader(filepath))
            {
                jsonFile = reader.ReadToEnd();
            }
            var JSONreume = JsonConvert.DeserializeObject<Resumeimfo>(jsonFile);

            //fullname & objective
            string Fullname = JSONreume.Fullname;
            string Objective = JSONreume.Objective;
            string Objective2 = JSONreume.Objective2;
            string Objective3 = JSONreume.Objective3;
            string Objective4 = JSONreume.Objective4;
            string Objective5 = JSONreume.Objective5;
            
            //Contacts
            string Email = JSONreume.Email;
            string Number = JSONreume.Number;
            string Address = JSONreume.Address;
            
            //Personal Infos
            string Birth = JSONreume.Birth;
            string PlaceofBirth = JSONreume.PlaceofBirth;
            string Citizenship = JSONreume.Citizenship;

            //Educations
            string Primary = JSONreume.Primary;
            string PrimaryGraduated = JSONreume.PrimaryGraduated;
            string Secondary = JSONreume.Secondary;
            string SecondaryGraduated = JSONreume.SecondaryGraduated;
            string Tertiary = JSONreume.Tertiary;
            string TertiaryGraduated = JSONreume.TertiaryGraduated;

            //Assets
            string Assets1 = JSONreume.Assets1;
            string Assets2 = JSONreume.Assets2;
            string Assets3 = JSONreume.Assets3;
            string Assets4 = JSONreume.Assets4;

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.InitialDirectory = @"C:\Users\Alver\source\repos\PDF_RESUME_GENERATOR\PDF";
                saveFile.FileName = Fullname + ".pdf";
                saveFile.Filter = "PDF|*.pdf";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    PdfDocument pdf = new PdfDocument();
                    pdf.Info.Title = Fullname + "_" + "Resume";
                    PdfPage page = pdf.AddPage();

                    XGraphics graphics = XGraphics.FromPdfPage(page);                  

                    XFont captionfont = new XFont(" ", 18, XFontStyle.Bold);
                    XFont captionfont2 = new XFont(" ", 16, XFontStyle.Bold);
                    XFont regularfont = new XFont(" ", 12, XFontStyle.Regular);
                    XFont BigFont = new XFont(" ", 24, XFontStyle.Bold);

                    graphics.DrawRectangle(XBrushes.PeachPuff, 0, 0, page.Width.Point, page.Height.Point);
                    graphics.DrawRectangle(XBrushes.PapayaWhip, 200, 0, page.Width.Point, page.Height.Point);

                    int leftmargin = 25;
                    int leftinitial = 200;

                    int middlemargin = 220;
                    int middleinitial = 200;

                    //FULL NAME
                    graphics.DrawString(Fullname, BigFont, XBrushes.Black, new XRect(-39, 40, page.Width.Point, page.Height.Point), XStringFormats.TopRight);

                    //OBJECTIVE
                    graphics.DrawString("OBJECTIVE", captionfont, XBrushes.Black, new XRect(-138, 90, page.Width.Point, page.Height.Point), XStringFormats.TopRight);
                    graphics.DrawString(Objective, regularfont, XBrushes.Black, new XRect(middlemargin, middleinitial - 85, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(Objective2, regularfont, XBrushes.Black, new XRect(middlemargin, middleinitial - 72, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(Objective3, regularfont, XBrushes.Black, new XRect(middlemargin, middleinitial - 59, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(Objective4, regularfont, XBrushes.Black, new XRect(middlemargin, middleinitial - 46, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(Objective5, regularfont, XBrushes.Black, new XRect(middlemargin, middleinitial - 33, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    //LINE BELOW OBJECTTIVE
                    graphics.DrawRectangle(XBrushes.PeachPuff, middlemargin, middleinitial - 10, 345, 2);

                    //PICTURE
                    string pic =  @"C:\Users\Alver\source\repos\PDF_RESUME_GENERATOR\picko.png";
                    XImage image = XImage.FromFile(pic);
                    graphics.DrawImage(image, leftmargin, 50, 150, 150);

                    //CONTACTS
                    graphics.DrawString("CONTACTS", captionfont, XBrushes.Black, new XRect(leftmargin, leftinitial +35, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(Email, regularfont, XBrushes.Black, new XRect(leftmargin, leftinitial + 60, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(Number, regularfont, XBrushes.Black, new XRect(leftmargin, leftinitial + 75, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(Address, regularfont, XBrushes.Black, new XRect(leftmargin, leftinitial + 90, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    //PERSONAL DETAILS
                    graphics.DrawString("PERSONAL DETAILS", captionfont2, XBrushes.Black, new XRect(17, leftinitial + 130, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(Birth, regularfont, XBrushes.Black, new XRect(leftmargin, leftinitial + 155, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(PlaceofBirth, regularfont, XBrushes.Black, new XRect(leftmargin, leftinitial + 170, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(Citizenship, regularfont, XBrushes.Black, new XRect(leftmargin, leftinitial + 185, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    //EDUCATIONS
                    graphics.DrawString("EDUCATIONAL PROFILE", captionfont, XBrushes.Black, new XRect(middlemargin + 50, middleinitial + 10, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString("PRIMARY", captionfont2, XBrushes.Black, new XRect(middlemargin, middleinitial + 50, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(Primary, regularfont, XBrushes.Black, new XRect(middlemargin, middleinitial + 70, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(PrimaryGraduated, regularfont, XBrushes.Black, new XRect(middlemargin, middleinitial + 85, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString("SECONDARY", captionfont2, XBrushes.Black, new XRect(middlemargin, middleinitial + 120, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(Secondary, regularfont, XBrushes.Black, new XRect(middlemargin, middleinitial + 140, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(SecondaryGraduated, regularfont, XBrushes.Black, new XRect(middlemargin, middleinitial + 155, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString("TERTIARY", captionfont2, XBrushes.Black, new XRect(middlemargin, middleinitial + 190, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(Tertiary, regularfont, XBrushes.Black, new XRect(middlemargin, middleinitial + 210, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graphics.DrawString(TertiaryGraduated, regularfont, XBrushes.Black, new XRect(middlemargin, middleinitial + 225, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);



                    pdf.Save(saveFile.FileName);
                }
            }
        }
    }
}
