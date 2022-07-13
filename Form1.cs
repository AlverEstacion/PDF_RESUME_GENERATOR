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
        private readonly string filepath = @"C:\Users\Alver\source\repos\JSON to PDF resume\jsconfig1.JSON";
        public Form1()
        {
            InitializeComponent();
        }

        public class Resumeimfo
        {
            public string Fullname { get; set; }
            public string Objective { get; set; }
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

            string Fullname = JSONreume.Fullname;
            string Objective = JSONreume.Objective;
            string Email = JSONreume.Email;
            string Number = JSONreume.Number;
            string Address = JSONreume.Address;
            string Birth = JSONreume.Birth;
            string PlaceofBirth = JSONreume.PlaceofBirth;
            string Citizenship = JSONreume.Citizenship;

            string Primary = JSONreume.Primary;
            string PrimaryGraduated = JSONreume.PrimaryGraduated;
            string Secondary = JSONreume.Secondary;
            string SecondaryGraduated = JSONreume.SecondaryGraduated;
            string Tertiary = JSONreume.Tertiary;
            string TertiaryGraduated = JSONreume.TertiaryGraduated;

            string Assets1 = JSONreume.Assets1;
            string Assets2 = JSONreume.Assets2;
            string Assets3 = JSONreume.Assets3;
            string Assets4 = JSONreume.Assets4;

            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.InitialDirectory = @"C:\Users\Alver\source\repos\JSON to PDF resume\PDF's\resume";
                saveFile.FileName = Fullname + ".pdf";
                saveFile.Filter = "PDF|*.pdf";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    PdfDocument pdf = new PdfDocument();
                    pdf.Info.Title = Fullname + "_" + "Resume";
                    PdfPage page = pdf.AddPage();

                    XGraphics graphics = XGraphics.FromPdfPage(page);
                   
                    XPen line = new XPen(XColors.PeachPuff, 1);

                    XFont captionfont = new XFont(" ", 18, XFontStyle.Bold);
                    XFont regularfont = new XFont(" ", 12, XFontStyle.Regular);
                    XFont BigFont = new XFont(" ", 24, XFontStyle.Bold);

                    graphics.DrawRectangle(XBrushes.PeachPuff, 0, 0, page.Width.Point, page.Height.Point);
                    graphics.DrawRectangle(XBrushes.PapayaWhip, 200, 0, page.Width.Point, page.Height.Point);

                    int leftmargin = 25;
                    int leftinitial = 200;

                    int middlemargin = 220;
                    int middleinitial = 200;


                    graphics.DrawString(Fullname, BigFont, XBrushes.Black, new XRect(-39, 40, page.Width.Point, page.Height.Point), XStringFormats.TopRight);

                    graphics.DrawString("OBJECTIVE", captionfont, XBrushes.Black, new XRect(-138, 90, page.Width.Point, page.Height.Point), XStringFormats.TopRight);





                    pdf.Save(saveFile.FileName);
                }
            }
        }
    }
}
