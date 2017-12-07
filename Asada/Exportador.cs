
using System;



using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;









namespace Asada
{
    class Exportador
    {


        //protected bool ocultarComandos;

        //public Exportador(bool ocultarComandos = false)
        //{
        //    this.ocultarComandos = ocultarComandos;
        //}

        //protected void ocultarCeldaComandos(GridView cuadricula)
        //{
        //    //
        //    foreach (GridViewRowPresenter fila in cuadricula)
        //    {
        //        if (fila.UseLayoutRounding == DataControlRowType.DataRow)
        //        {
        //            foreach (TableCell celda in fila.Cells)
        //            {
        //                DataControlField campo = ((DataControlFieldCel)celda).ContainingField;
        //                if (campo.GetType().Name == "CommandField")
        //                {
        //                    celda.Visible = false;
        //                }
        //            }
        //        }
        //    }
        //}

        //public void cuadriculasEnPDF(List<GridView> cuadriculas, HttpResponse respuesta)
        //{
        //    //
        //    using (StringWriter escritor = new StringWriter())
        //    {
        //        //
        //        using (HtmlTextWriter escritorHTML = new HtmlTextWriter(escritor))
        //        {
        //            //
        //            foreach (GridView cuadricula in cuadriculas)
        //            {
        //                //
        //                if (this.ocultarComandos)
        //                {
        //                    this.ocultarCeldaComandos(cuadricula);
        //                }
        //                cuadricula.RenderControl(escritorHTML);
        //            }
        //            //
        //            StringReader lector = new StringReader(escritor.ToString());
        //            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //            PdfWriter escritorPDF = PdfWriter.GetInstance(pdfDoc, respuesta.OutputStream);
        //            //
        //            pdfDoc.Open();
        //            //
        //            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(escritorPDF, pdfDoc, lector);
        //            pdfDoc.Close();
        //            //
        //            respuesta.ContentType = "application/pdf";
        //            respuesta.AddHeader("content-disposition", "attachment;filename=" + cuadriculas[0].Page.ID + ".pdf");
        //            respuesta.Cache.SetCacheability(HttpCacheability.NoCache);
        //            respuesta.Write(pdfDoc);
        //            respuesta.End();
        //        }
        //    }
        //}

        //public void enPDF(GridView cuadricula, HttpResponse respuesta)
        //{
        //    List<GridView> cuadriculas = new List<GridView>();
        //    cuadriculas.Add(cuadricula);
        //    this.cuadriculasEnPDF(cuadriculas, respuesta);
        //}




    }
}
