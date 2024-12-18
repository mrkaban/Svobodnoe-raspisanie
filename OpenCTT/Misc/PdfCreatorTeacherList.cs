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
    class PdfCreatorTeacherList
    {
        internal static PdfDocument PDFDOCUMENT;

        private static ResourceManager RES_MANAGER;

        static int PAGE_COUNTER;
        static int TOTAL_PAGE_NUMBER;
        static int ROW_COUNTER;

        static int X_START = 75;
        static int Y_START = 140;
        static int COL_GAP = 5;
        static int[] COL_WIDTH = new int[5] { 115, 75, 55, 150, 60 };
        static int CURR_Y = Y_START;
        static int ROW_HEIGHT = 14;

        static PdfCreatorTeacherList()
		{
            if (RES_MANAGER == null)
            {
                
                RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.TeacherPropertiesForm", typeof(TeacherPropertiesForm).Assembly);
            }            
		}

        public static void createPdfDocumentTeacherList()
        {
            CURR_Y = Y_START;
            PAGE_COUNTER = 0;
            TOTAL_PAGE_NUMBER = 0;
            ROW_COUNTER = 0;
         
            string fileName = "ReportTeacherList" +".pdf";

            PDFDOCUMENT = new PdfDocument();
            PDFDOCUMENT.Info.Title = "OCTT Teacher List Report";
            PDFDOCUMENT.Info.Author = "Open Course Timetabler";
            PDFDOCUMENT.Info.Subject = "��������� ����������";

            /*PdfPage newPage = PDFDOCUMENT.AddPage();
            newPage.Size = PageSize.A4;
            //Console.WriteLine(newPage.Width + ", " + newPage.Height);
            newPage.Orientation = PdfSharp.PageOrientation.Portrait;*/
            PdfPage newPage = createNewPage();
            PAGE_COUNTER = 1;
            XGraphics gfx = XGraphics.FromPdfPage(newPage);

            double dab = System.Convert.ToDouble(AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes.Count / 34.0);            
            double dde = Math.Ceiling(dab);            
            TOTAL_PAGE_NUMBER = System.Convert.ToInt32(dde);           


            createPageHeader(gfx);
            
            foreach (Teacher teacher in AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes)
            {
                //Teacher teacher = (Teacher)AppForm.CURR_OCTT_DOC.TeachersRootNode.Nodes[0];
                ROW_COUNTER++;

                if (CURR_Y > 770)
                {
                    newPage = createNewPage();
                    PAGE_COUNTER++;
                    gfx = XGraphics.FromPdfPage(newPage);
                    CURR_Y = Y_START;
                    createPageHeader(gfx);
                }

                //XGraphics gfx = XGraphics.FromPdfPage(newPage);

                //XPen pen = new XPen(XColors.Black, 0.5);

                /*string institutionName = AppForm.CURR_OCTT_DOC.EduInstitutionName;

                XRect rect = new XRect(45, 80, 505, 30);
                //XRect rect = new XRect(tableStartX + termsTableColumnWidth, tableStartY - 25, columnCount * columnWidth, 20);
                XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
                XFont font = new XFont("Arial", 16, XFontStyle.Regular, options);

                XBrush brush = XBrushes.Black;
                XStringFormat format = new XStringFormat();
                gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
                format.LineAlignment = XLineAlignment.Center;
                format.Alignment = XStringAlignment.Center;
                gfx.DrawString(institutionName, font, brush, rect, format);

                string printDate = System.DateTime.Now.ToShortDateString();
                rect = new XRect(430, 50, 120, 16);
                font = new XFont("Arial", 10, XFontStyle.Regular, options);
                format.Alignment = XStringAlignment.Far;
                gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
                gfx.DrawString(printDate, font, brush, rect, format);
                 
                createTableHeader(gfx);*/

                

                createTableRow(gfx, teacher);

                /*string reportName = RES_MANAGER.GetString("teacher_list");
                rect = new XRect(75, 140, 445, 26);
                font = new XFont("Arial", 14, XFontStyle.Bold, options);
                format.Alignment = XStringAlignment.Center;
                gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
                gfx.DrawString(reportName, font, brush, rect, format);

                string headerLastName = RES_MANAGER.GetString("lastname");
                rect = new XRect(45, 180, 120, 16);
                font = new XFont("Arial", 12, XFontStyle.Bold, options);
                format.Alignment = XStringAlignment.Center;
                gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
                gfx.DrawString(headerLastName, font, brush, rect, format);

                string headerName = RES_MANAGER.GetString("name");
                rect = new XRect(170, 180, 120, 16);
                gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
                gfx.DrawString(headerName, font, brush, rect, format);

                string headerTitle = RES_MANAGER.GetString("title");
                rect = new XRect(295, 180, 60, 16);
                gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
                gfx.DrawString(headerTitle, font, brush, rect, format);

                string headerEduRank = RES_MANAGER.GetString("edurank");
                rect = new XRect(360, 180, 120, 16);
                gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
                gfx.DrawString(headerEduRank, font, brush, rect, format);

                string headerExtID = RES_MANAGER.GetString("extid");
                rect = new XRect(485, 180, 65, 16);
                gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
                gfx.DrawString(headerExtID, font, brush, rect, format);*/




                

                /*string docPropertiesString = AppForm.CURR_OCTT_DOC.EduInstitutionName + " " + AppForm.CURR_OCTT_DOC.SchoolYear;

                string lastChangeString;
                if (AppForm.CURR_OCTT_DOC.FullPath != null)
                {
                    FileInfo fi = new FileInfo(AppForm.CURR_OCTT_DOC.FullPath);
                    lastChangeString = RES_MANAGER.GetString("lastchangedate.text") + " " + fi.LastWriteTime.ToShortDateString() + " " + fi.LastWriteTime.ToLongTimeString();
                }
                else
                {
                    lastChangeString = "";
                }

                rect = new XRect(tableStartX, tableStartY + headerTableRowHeight + rowHeight * rowCount + 5, 250, 10);
                //font = new XFont("Times", 8, XFontStyle.Regular, options);
                font = getMyFont(Settings.TTREP_FONT_FOOTER, options);
                //gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
                format.LineAlignment = XLineAlignment.Center;
                format.Alignment = XStringAlignment.Near;
                gfx.DrawString(docPropertiesString, font, brush, rect, format);

                rect = new XRect(tableStartX + termsTableColumnWidth + columnWidth * columnCount - 200, tableStartY + headerTableRowHeight + rowHeight * rowCount + 5, 200, 10);
                //font = new XFont("Times", 8, XFontStyle.Regular, options);				
                //gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
                format.LineAlignment = XLineAlignment.Center;
                format.Alignment = XStringAlignment.Far;
                gfx.DrawString(lastChangeString, font, brush, rect, format);

                rect = new XRect(tableStartX, tableStartY + headerTableRowHeight + rowHeight * rowCount + 5, tableStartX + termsTableColumnWidth + columnWidth * columnCount, 10);
                //font = new XFont("Times", 8, XFontStyle.Regular, options);				
                //gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
                format.LineAlignment = XLineAlignment.Center;
                format.Alignment = XStringAlignment.Center;
                gfx.DrawString("��������� ���������� (����������������.��)", font, brush, rect, format);
                */
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


        private static void createTableHeader(XGraphics gfx)
        {
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            XBrush brush = XBrushes.Black;
            XStringFormat format = new XStringFormat();
            format.LineAlignment = XLineAlignment.Center;

            XPen xpen = new XPen(XColors.Black, 1.5);
            XBrush xbrush = XBrushes.Bisque;

            XRect rect;
            XFont font;

            int currX = X_START;

            string headerLastName = RES_MANAGER.GetString("lastname");
            rect = new XRect(currX, CURR_Y, COL_WIDTH[0], 16);
            font = new XFont("Arial", 12, XFontStyle.Bold, options);
            format.Alignment = XStringAlignment.Near;
            //gfx.DrawRectangle(xpen, xbrush, rect);
            gfx.DrawString(headerLastName, font, brush, rect, format);

            currX += COL_WIDTH[0] + COL_GAP;

            string headerName = RES_MANAGER.GetString("name");
            rect = new XRect(currX, CURR_Y, COL_WIDTH[1], 16);
            //gfx.DrawRectangle(xpen, xbrush, rect);
            gfx.DrawString(headerName, font, brush, rect, format);

            currX += COL_WIDTH[1] + COL_GAP;

            string headerTitle = RES_MANAGER.GetString("title");
            rect = new XRect(currX, CURR_Y, COL_WIDTH[2], 16);
            //gfx.DrawRectangle(xpen, xbrush, rect);
            gfx.DrawString(headerTitle, font, brush, rect, format);

            currX += COL_WIDTH[2] + COL_GAP;

            string headerEduRank = RES_MANAGER.GetString("edurank");
            rect = new XRect(currX, CURR_Y, COL_WIDTH[3], 16);
            //gfx.DrawRectangle(xpen, xbrush, rect);
            gfx.DrawString(headerEduRank, font, brush, rect, format);

            currX += COL_WIDTH[3] + COL_GAP;

            string headerExtID = RES_MANAGER.GetString("extid");
            rect = new XRect(currX, CURR_Y, COL_WIDTH[4], 16);
            //gfx.DrawRectangle(xpen, xbrush, rect);
            gfx.DrawString(headerExtID, font, brush, rect, format);

            gfx.DrawLine(xpen, X_START-20, CURR_Y + 18, X_START + 475, CURR_Y + 18);

            CURR_Y += 20;


        }


        private static void createTableRow(XGraphics gfx, Teacher teacher)
        {

            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            XBrush brush = XBrushes.Black;
            XStringFormat format = new XStringFormat();
            format.LineAlignment = XLineAlignment.Center;
                        
            XPen xpen = new XPen(XColors.Black, 0.5);
            XBrush xbrush = XBrushes.Bisque;

            XRect rect;
            XFont font;

            int currX = X_START-30;

            string ordinalNum = ROW_COUNTER.ToString() + ".";
            rect = new XRect(currX, CURR_Y, 28, ROW_HEIGHT);
            font = new XFont("Arial", 10, XFontStyle.Regular, options);
            format.Alignment = XStringAlignment.Far;
            //gfx.DrawRectangle(xpen, xbrush, rect);
            gfx.DrawString(ordinalNum, font, brush, rect, format);

            currX = X_START;

            string teacherLastName = teacher.getLastName();
            rect = new XRect(currX, CURR_Y, COL_WIDTH[0], ROW_HEIGHT);
            font = new XFont("Arial", 10, XFontStyle.Regular, options);
            format.Alignment = XStringAlignment.Near;
            //gfx.DrawRectangle(xpen, xbrush, rect);
            gfx.DrawString(teacherLastName, font, brush, rect, format);

            currX += COL_WIDTH[0] + COL_GAP;

            string teacherName = teacher.getName();
            rect = new XRect(currX, CURR_Y, COL_WIDTH[1], ROW_HEIGHT);
            //gfx.DrawRectangle(xpen, xbrush, rect);
            gfx.DrawString(teacherName, font, brush, rect, format);

            currX += COL_WIDTH[1] + COL_GAP;

            string teacherTitle = teacher.getTitle();
            rect = new XRect(currX, CURR_Y, COL_WIDTH[2], ROW_HEIGHT);
            //gfx.DrawRectangle(xpen, xbrush, rect);
            gfx.DrawString(teacherTitle, font, brush, rect, format);

            currX += COL_WIDTH[2] + COL_GAP;

            string teacherEduRank = teacher.getEduRank();
            rect = new XRect(currX, CURR_Y, COL_WIDTH[3], ROW_HEIGHT);
            //gfx.DrawRectangle(xpen, xbrush, rect);
            gfx.DrawString(teacherEduRank, font, brush, rect, format);

            currX += COL_WIDTH[3] + COL_GAP;

            string teacherExtID = teacher.ExtID;
            rect = new XRect(currX, CURR_Y, COL_WIDTH[4], ROW_HEIGHT);
            //gfx.DrawRectangle(xpen, xbrush, rect);
            gfx.DrawString(teacherExtID, font, brush, rect, format);

            gfx.DrawLine(xpen, X_START-20, CURR_Y + ROW_HEIGHT + 2, X_START + 475, CURR_Y + ROW_HEIGHT + 2);

            CURR_Y += ROW_HEIGHT+4;
        }


        private static PdfPage createNewPage()
        {
            PdfPage newPage = PDFDOCUMENT.AddPage();
            newPage.Size = PageSize.A4;            
            newPage.Orientation = PdfSharp.PageOrientation.Portrait;

            return newPage;
        }

        private static void createPageHeader(XGraphics gfx)
        {
            string institutionName = AppForm.CURR_OCTT_DOC.EduInstitutionName;

            XRect rect = new XRect(45, 60, 505, 30);
            //XRect rect = new XRect(tableStartX + termsTableColumnWidth, tableStartY - 25, columnCount * columnWidth, 20);
            XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            XFont font = new XFont("Arial", 16, XFontStyle.Regular, options);

            XBrush brush = XBrushes.Black;
            XStringFormat format = new XStringFormat();
            //gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
            format.LineAlignment = XLineAlignment.Center;
            format.Alignment = XStringAlignment.Center;
            gfx.DrawString(institutionName, font, brush, rect, format);

            string reportName = RES_MANAGER.GetString("teacher_list");
            rect = new XRect(75, 100, 445, 26);
            font = new XFont("Arial", 14, XFontStyle.Bold, options);
            format.Alignment = XStringAlignment.Center;
            //gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
            gfx.DrawString(reportName, font, brush, rect, format);


            string printDate = System.DateTime.Now.ToShortDateString();
            rect = new XRect(430, 30, 120, 16);
            font = new XFont("Arial", 10, XFontStyle.Regular, options);
            format.Alignment = XStringAlignment.Far;
            //gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
            gfx.DrawString(printDate, font, brush, rect, format);

            createTableHeader(gfx);


            string pageNumber = RES_MANAGER.GetString("page") +": " + PAGE_COUNTER+"/"+TOTAL_PAGE_NUMBER;
            rect = new XRect(430, 790, 120, 16);
            font = new XFont("Arial", 10, XFontStyle.Regular, options);
            format.Alignment = XStringAlignment.Far;
            //gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
            gfx.DrawString(pageNumber, font, brush, rect, format);

            string octt = "��������� ���������� (����������������.��)";
            rect = new XRect(150, 790, 295, 16);
            font = new XFont("Tahoma", 7, XFontStyle.Regular, options);
            format.Alignment = XStringAlignment.Center;
            //gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
            gfx.DrawString(octt, font, brush, rect, format);

        }





    }
}
