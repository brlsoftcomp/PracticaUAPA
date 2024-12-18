using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing;
using BRL_SVentas.Forms;

namespace DoctConsults
{
    public static class ClassImprimir
    {
        private static int m_currentPageIndex;
        private static IList<Stream> m_streams;
        public static void ImprimirReporte(string DataSource, string Reporte, ReportParameter[] paramCollection, DataTable dt)
        {
            try
            {
                var frm = new FormVisor();
                frm.reportViewer1.Reset();
                frm.reportViewer1.LocalReport.EnableExternalImages = true;
                frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(DataSource, dt));
                frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas." + Reporte +".rdlc";
                frm.reportViewer1.LocalReport.SetParameters(paramCollection);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void ImprimirRecibo(string DataSource, string Reporte, ReportParameter[] paramCollection, DataTable dt, string tipoPapel, string tipoDocumento)
        {
            try
            {
                var frm = new FormVisor();
                frm.reportViewer1.Reset();
                frm.reportViewer1.LocalReport.EnableExternalImages = true;
                frm.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(DataSource, dt));
                frm.reportViewer1.LocalReport.ReportEmbeddedResource = "BRL_SVentas." + Reporte + ".rdlc";
                frm.reportViewer1.LocalReport.SetParameters(paramCollection);
                //frm.ShowDialog();
                Export(frm.reportViewer1.LocalReport, tipoPapel, tipoDocumento);
                Print(tipoPapel, tipoDocumento);
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static void Export(LocalReport report, string tipoPapel, string tipoDocumento)
        {
            //<PageHeight>3.67in</PageHeight>  configuracion de recibo de cenovi a 3/4 de pagina  
            //6.00003cm, 11.28843cm

            if (tipoPapel == "PAPEL ROLLO")
            {
                if (tipoDocumento == "FACTURA")
                {
                    string deviceInfo =
                        @"<DeviceInfo>

                        <OutputFormat>EMF</OutputFormat>
                        <PageWidth>3in</PageWidth>
                        <PageHeight>8.3in</PageHeight>              
                        <MarginTop>0.2cm</MarginTop>
                        <MarginLeft>0.0cm</MarginLeft>
                        <MarginRight>0.0cm</MarginRight>
                        <MarginBottom>0cm</MarginBottom>
                    </DeviceInfo>";
                    Warning[] warnings;
                    m_streams = new List<Stream>();
                    report.Render("Image", deviceInfo, CreateStream, out warnings);
                    foreach (Stream stream in m_streams)
                        stream.Position = 0;
                }
                else if (tipoDocumento == "CIERRE_CAJA")
                {
                    string deviceInfo =
                    @"<DeviceInfo>

                        <OutputFormat>EMF</OutputFormat>
                        <PageWidth>3in</PageWidth>
                        <PageHeight>11in</PageHeight>              
                        <MarginTop>0.0cm</MarginTop>
                        <MarginLeft>0.0cm</MarginLeft>
                        <MarginRight>0.0cm</MarginRight>
                        <MarginBottom>0cm</MarginBottom>
                    </DeviceInfo>";
                    Warning[] warnings;
                    m_streams = new List<Stream>();
                    report.Render("Image", deviceInfo, CreateStream, out warnings);
                    foreach (Stream stream in m_streams)
                        stream.Position = 0;
                }
            }
            else if (tipoPapel == "MEDIA PAGINA")
            {
                if (tipoDocumento == "FACTURA")
                {
                    string deviceInfo =
                        @"<DeviceInfo>
                        <OutputFormat>EMF</OutputFormat>
                        <PageWidth>8.5in</PageWidth>
                        <PageHeight>5.7in</PageHeight>              
                        <MarginTop>0.2cm</MarginTop>
                        <MarginLeft>0.0cm</MarginLeft>
                        <MarginRight>0.0cm</MarginRight>
                        <MarginBottom>0.0cm</MarginBottom>
                    </DeviceInfo>";
                    Warning[] warnings;
                    m_streams = new List<Stream>();
                    report.Render("Image", deviceInfo, CreateStream, out warnings);
                    foreach (Stream stream in m_streams)
                        stream.Position = 0;
                }
                else if (tipoDocumento == "CIERRE_CAJA")
                {
                    //<PageHeight>8.5in</PageHeight>  
                    string deviceInfo =
                        @"<DeviceInfo>
                        <OutputFormat>EMF</OutputFormat>
                        <PageWidth>8.5in</PageWidth>
                        <PageHeight>5.7in</PageHeight>              
                        <MarginTop>0.2cm</MarginTop>
                        <MarginLeft>0.0cm</MarginLeft>
                        <MarginRight>0.0cm</MarginRight>
                        <MarginBottom>0.0cm</MarginBottom>
                    </DeviceInfo>";
                    Warning[] warnings;
                    m_streams = new List<Stream>();
                    report.Render("Image", deviceInfo, CreateStream, out warnings);
                    foreach (Stream stream in m_streams)
                        stream.Position = 0;
                }
                
            }
        }

        private static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private static void Print(string tipoPapel, string tipoDocumento)
        {
            try
            {
                if (m_streams == null || m_streams.Count == 0)
                    throw new Exception("Error: no stream to print.");
                PrintDocument printDoc = new PrintDocument();
                if (tipoPapel == "PAPEL ROLLO")
                {
                    if (tipoDocumento == "FACTURA")
                    {
                        printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom Paper Size", 300, 830);
                        printDoc.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 2, 0);
                    }
                    else if (tipoDocumento == "CIERRE_CAJA")
                    {
                        printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom Paper Size", 300, 1100);
                        printDoc.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
                    }
                }
                else if (tipoPapel == "MEDIA PAGINA")
                {
                    if (tipoDocumento == "FACTURA")
                    {
                        printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom Paper Size", 850, 570);
                        printDoc.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 2, 0);
                    }
                    else if (tipoDocumento == "CIERRE_CAJA")
                    {
                        //printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom Paper Size", 850, 850);
                        //printDoc.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
                        printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom Paper Size", 850, 570);
                        printDoc.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 2, 0);
                    }
                }

                if (!printDoc.PrinterSettings.IsValid)
                {
                    throw new Exception("Error: cannot find the default printer.");
                }
                else
                {
                    printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                    m_currentPageIndex = 0;
                    printDoc.Print();                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX, ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY, ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public static void Dispose()
        {
            if(m_streams != null)
            {
                foreach (Stream stream in m_streams)                
                    stream.Close();                   
                m_streams = null;              
            }
        }
    }
}
