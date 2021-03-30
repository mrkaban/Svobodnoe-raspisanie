#region Open Course Timetabler - An application for school and university course timetabling
//
// Author:
//   Ivan �urak (mailto:Ivan.Curak@fesb.hr)
//
// Copyright (c) 2007 Ivan �urak, Split, Croatia
//
// http://www.openctt.org
//
//This file is part of Open Course Timetabler.
//
//Open Course Timetabler is free software;
//you can redistribute it and/or modify it under the terms of the GNU General Public License
//as published by the Free Software Foundation; either version 2 of the License,
//or (at your option) any later version.
//
//Open Course Timetabler is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
//or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
//You should have received a copy of the GNU General Public License along with
//Open Course Timetabler; if not, write to the Free Software Foundation, Inc., 51 Franklin St,
//Fifth Floor, Boston, MA  02110-1301  USA

#endregion

using System;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Resources;
using System.Diagnostics;

using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing.Layout;


namespace OpenCTT
{
    class PdfCreatorMasterTimetable
    {
        internal static PdfDocument PDFDOCUMENT;

        private static ResourceManager RES_MANAGER;

        static int PAGE_COUNTER;
        static int TOTAL_PAGE_NUMBER;
        static int ROW_COUNTER;

        static int X_START = 30;
        static int Y_START = 30;

        static int CURR_Y = Y_START;
        static int CURR_X = X_START;

        static int ROW_HEIGHT = 93;
        static int EP_COLUMN_WIDTH = 30;


        static int COLUMN_WIDTH;

        static int TIME_PERIOD_RECT_HEIGHT = 40;


        
        static PdfCreatorMasterTimetable()
        {
            if (RES_MANAGER == null)
            {

                RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.TeacherPropertiesForm", typeof(TeacherPropertiesForm).Assembly);
            }
        }


        public static void createPdfDocument(DataTable dt)
        {
            CURR_Y = Y_START;
            PAGE_COUNTER = 0;
            TOTAL_PAGE_NUMBER = 0;
            ROW_COUNTER = 0;

            string fileName = "ReportMasterTimetable" + ".pdf";

            PDFDOCUMENT = new PdfDocument();
            PDFDOCUMENT.Info.Title = "OCTT Master Timetable Report";
            PDFDOCUMENT.Info.Author = "Open Course Timetabler";
            PDFDOCUMENT.Info.Subject = "��������� ����������";
                        
            PdfPage myPage = createNewPage();
            PAGE_COUNTER = 1;
            XGraphics gfx = XGraphics.FromPdfPage(myPage);

            double dab = System.Convert.ToDouble(dt.Rows.Count / 5.0);//5 rows per page
            double dde = Math.Ceiling(dab);
            TOTAL_PAGE_NUMBER = System.Convert.ToInt32(dde);

            createPageHeader(gfx, myPage);

            foreach (DataRow dr in dt.Rows)
            {
                //Console.WriteLine((string)dr[0]);

                ROW_COUNTER++;

                if (CURR_Y > 500)
                {
                    myPage = createNewPage();
                    PAGE_COUNTER++;
                    gfx = XGraphics.FromPdfPage(myPage);
                    CURR_Y = Y_START;
                    createPageHeader(gfx,myPage);
                }

                createTableRow(gfx, myPage,dr);

            }

            try
            {
                PDFDOCUMENT.Save(fileName);
                Process.Start(Settings.PDF_READER_APPLICATION, fileName);
            }
            catch (Exception e)
            {
                try
                {
                    Process.Start(fileName);
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.Message);
                }
            }

        }


        private static void createPageHeader(XGraphics gfx, PdfPage page)
        {
            string institutionName = AppForm.CURR_OCTT_DOC.EduInstitutionName;

            XRect rect = new XRect(30, 560, 285, 14);            
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            XFont font = new XFont("Arial", 7, XFontStyle.Regular, options);

            XBrush brush = XBrushes.Black;
            XStringFormat format = new XStringFormat();
            //gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
            format.LineAlignment = XLineAlignment.Center;
            format.Alignment = XStringAlignment.Near;
            gfx.DrawString(institutionName, font, brush, rect, format);            

            string octt = "��������� ���������� (����������������.��)";
            rect = new XRect(320, 560, 202, 14);
            font = new XFont("Tahoma", 7, XFontStyle.Regular, options);
            format.Alignment = XStringAlignment.Center;
            //gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
            gfx.DrawString(octt, font, brush, rect, format);

            
            createTableHeader(gfx,page);

            int columnCount = AppForm.CURR_OCTT_DOC.getNumberOfDays();
            int xEnd = X_START + EP_COLUMN_WIDTH + COLUMN_WIDTH * columnCount;

            string pageNumber = RES_MANAGER.GetString("page") + ": " + PAGE_COUNTER + "/" + TOTAL_PAGE_NUMBER;
            rect = new XRect(xEnd-80, 560, 80, 14);
            font = new XFont("Arial", 7, XFontStyle.Regular, options);
            format.Alignment = XStringAlignment.Far;
            //gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
            gfx.DrawString(pageNumber, font, brush, rect, format);

        }


        private static void createTableHeader(XGraphics gfx, PdfPage page)
        {
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            XBrush brush = XBrushes.Black;
            XStringFormat format = new XStringFormat();
            format.LineAlignment = XLineAlignment.Center;
            format.Alignment = XStringAlignment.Center;

            XPen xpen = new XPen(XColors.Black, 1.0);
            XBrush xbrush = XBrushes.Bisque;
                        
            XFont font = new XFont("Verdana", 12, XFontStyle.Regular, options);
            XRect rect;

            CURR_X = X_START + EP_COLUMN_WIDTH;
            //
            
            int columnCount = AppForm.CURR_OCTT_DOC.getNumberOfDays();
            int rowCount = AppForm.CURR_OCTT_DOC.IncludedTerms.Count;
            //COLUMN_WIDTH=144;
            COLUMN_WIDTH = (int)(page.Width - 2 * X_START - EP_COLUMN_WIDTH) / columnCount;
            int sWidth = COLUMN_WIDTH / rowCount;
            COLUMN_WIDTH = sWidth * rowCount;
                        
            string dayName = "";
            int modPos = 0;            
            for (int kk = 0; kk < columnCount; kk++)
            {
                while (true)
                {
                    if (AppForm.CURR_OCTT_DOC.getIsDayIncluded(modPos))
                    {
                        break;
                    }
                    modPos++;
                }


                dayName = AppForm.getDayText()[modPos];
                modPos++;

                rect = new XRect(CURR_X, CURR_Y, COLUMN_WIDTH, 20);

                gfx.DrawRectangle(xpen, xbrush, rect);
                gfx.DrawString(dayName, font, brush, rect, format);

                CURR_X += COLUMN_WIDTH;
            }

            //

            CURR_Y = Y_START + 20;
            CURR_X = X_START + EP_COLUMN_WIDTH;

            font = new XFont("Arial", 6, XFontStyle.Regular, options);
            
            for (int gb = 0; gb < columnCount; gb++)
            {
                for (int j = 0; j < rowCount; j++)
                {
                    int[] term = (int[])AppForm.CURR_OCTT_DOC.IncludedTerms[j];
                    string[] printTerm = new string[4];
                    for (int t = 0; t < 4; t++)
                    {
                        if (term[t] < 10)
                        {
                            printTerm[t] = "0" + System.Convert.ToString(term[t]);
                        }
                        else
                        {
                            printTerm[t] = System.Convert.ToString(term[t]);
                        }
                    }

                    string termText = printTerm[0] + ":" + printTerm[1] + "-" + printTerm[2] + ":" + printTerm[3];


                    /*rect = new XRect(CURR_X, CURR_Y, sWidth, 40);
                    gfx.DrawRectangle(xpen, xbrush, rect);
                    gfx.DrawString(termText, font, brush, rect, format);*/

                    ///
                    gfx.TranslateTransform(page.Width / 2, page.Height / 2);
                    gfx.RotateTransform(-90);
                    gfx.TranslateTransform(-page.Height / 2, -page.Width / 2);


                    rect = new XRect(page.Height - CURR_Y - TIME_PERIOD_RECT_HEIGHT, CURR_X, TIME_PERIOD_RECT_HEIGHT, sWidth);
                    gfx.DrawRectangle(xpen, xbrush, rect);
                    gfx.DrawString(termText, font, brush, rect, format);

                    gfx.TranslateTransform(page.Height / 2, page.Width / 2);
                    gfx.RotateTransform(90);
                    gfx.TranslateTransform(-page.Width / 2, -page.Height / 2);
                    ///

                    CURR_X += sWidth;
                }
            }

            CURR_Y = Y_START + 20 + TIME_PERIOD_RECT_HEIGHT;

        }


        private static void createTableRow(XGraphics gfx, PdfPage page, DataRow dr)
        {

            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            XBrush brush = XBrushes.Black;
            XStringFormat format = new XStringFormat();
            format.LineAlignment = XLineAlignment.Center;
            format.Alignment = XStringAlignment.Center;
            

            XPen xpen = new XPen(XColors.Black, 1.0);
            XBrush xbrush = XBrushes.Bisque;

            XFont font = new XFont("Verdana", 6, XFontStyle.Regular, options);
            XRect rect;

            XTextFormatter tf;


            string epName = (string)dr[0];

            
            CURR_X = X_START;

            gfx.TranslateTransform(page.Width / 2, page.Height / 2);
            gfx.RotateTransform(-90);
            gfx.TranslateTransform(-page.Height / 2, -page.Width / 2);


            rect = new XRect(page.Height - CURR_Y - ROW_HEIGHT, CURR_X, ROW_HEIGHT, EP_COLUMN_WIDTH);
            gfx.DrawRectangle(xpen, xbrush, rect);
            //gfx.DrawString(epName, font, brush, rect, format);
            tf = new XTextFormatter(gfx);
            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString(epName, font, brush, rect, XStringFormat.TopLeft);
            

            gfx.TranslateTransform(page.Height / 2, page.Width / 2);
            gfx.RotateTransform(90);
            gfx.TranslateTransform(-page.Width / 2, -page.Height / 2);
            
            ///
            
            int columnCount = AppForm.CURR_OCTT_DOC.getNumberOfDays();
            int xEnd = X_START + EP_COLUMN_WIDTH + COLUMN_WIDTH * columnCount;
            
            //vertical main lines
            CURR_X = X_START + EP_COLUMN_WIDTH;
            xpen = new XPen(XColors.Black, 1.0);

            for (int n = 0; n < columnCount+1; n++)
            {
                gfx.DrawLine(xpen, CURR_X, CURR_Y, CURR_X, CURR_Y+ROW_HEIGHT);
                CURR_X += COLUMN_WIDTH;
            }
            
            //cells
            xpen = new XPen(XColors.Black, 0.4);            
            CURR_X = X_START + EP_COLUMN_WIDTH;
            int rowCount = AppForm.CURR_OCTT_DOC.IncludedTerms.Count;
            int sWidth = COLUMN_WIDTH / rowCount;

            xbrush = XBrushes.Bisque;
            font = new XFont("Verdana", 5, XFontStyle.Regular, options);

            int drColIndex = 0;
            for (int k = 0; k < columnCount; k++)
            {
                for (int n = 0; n < rowCount; n++)
                {
                    drColIndex++;
                    string cellText=(string)dr[drColIndex];
                    //Console.WriteLine(cellText);

                    
                    gfx.TranslateTransform(page.Width / 2, page.Height / 2);
                    gfx.RotateTransform(-90);
                    gfx.TranslateTransform(-page.Height / 2, -page.Width / 2);


                    rect = new XRect(page.Height - CURR_Y - ROW_HEIGHT, CURR_X, ROW_HEIGHT, sWidth);
                    //gfx.DrawRectangle(xpen, xbrush, rect);
                    //gfx.DrawString(cellText, font, brush, rect, format);

                    tf = new XTextFormatter(gfx);
                    tf.Alignment = XParagraphAlignment.Center;
                    tf.DrawString(cellText, font, brush, rect, XStringFormat.TopLeft);


                    gfx.TranslateTransform(page.Height / 2, page.Width / 2);
                    gfx.RotateTransform(90);
                    gfx.TranslateTransform(-page.Width / 2, -page.Height / 2);

                    CURR_X += sWidth;

                    if(n!=rowCount-1) gfx.DrawLine(xpen, CURR_X, CURR_Y, CURR_X, CURR_Y + ROW_HEIGHT);
                }
            }

            //horizontal line
            xpen = new XPen(XColors.Black, 1.0);
            CURR_Y += ROW_HEIGHT;            
            gfx.DrawLine(xpen, X_START + EP_COLUMN_WIDTH, CURR_Y, xEnd, CURR_Y);

        }



        private static PdfPage createNewPage()
        {
            PdfPage newPage = PDFDOCUMENT.AddPage();
            newPage.Size = PageSize.A4;
            newPage.Orientation = PdfSharp.PageOrientation.Landscape;

            return newPage;
        }
    }    
}
