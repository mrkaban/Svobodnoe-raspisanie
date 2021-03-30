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
	/// <summary>
	/// Summary description for PdfCreator.
	/// </summary>
	public class PdfCreator
	{
		private static ResourceManager RES_MANAGER = new System.Resources.ResourceManager("OpenCTT.MyStrings.PdfCreator",typeof (PdfCreator).Assembly);		
		internal static PdfDocument PDFDOCUMENT;

		public PdfCreator()
		{
			
		}

		public static void createPdfDocument(ArrayList pdfReportDataTablesList)
		{
            int tableStartX = Settings.TTREP_MTS_X;
            int tableStartY = Settings.TTREP_MTS_Y;
            int rowHeight = Settings.TTREP_MTRH;
            int columnWidth = Settings.TTREP_MTCW;
            int headerTableRowHeight = Settings.TTREP_HTRH;
            int termsTableColumnWidth = Settings.TTREP_TPTCW;
            			
			string fileName ="ReportTimetable"+".pdf";
				
			PDFDOCUMENT = new PdfDocument();
			PDFDOCUMENT.Info.Title = "OCTT Timetable Report";
			PDFDOCUMENT.Info.Author = "Open Course Timetabler";
			PDFDOCUMENT.Info.Subject = "��������� ����������";

			foreach(Object[] reportGroupAndTable in pdfReportDataTablesList)
			{
				PdfPage newPage= PDFDOCUMENT.AddPage();
                //newPage.Size = PageSize.A4;

                Type ps = typeof(PageSize);
                newPage.Size = (PageSize)getValueForEnumeration(ps,Settings.TTREP_PAPER_SIZE);
                //Console.WriteLine(newPage.Width + "," + newPage.Height);
                
				//newPage.Orientation = PdfSharp.PageOrientation.Landscape;
                Type po = typeof(PageOrientation);
                newPage.Orientation = (PageOrientation)getValueForEnumeration(po, Settings.TTREP_PAPER_ORIENTATION);

				XGraphics gfx = XGraphics.FromPdfPage(newPage);			
				XPen pen = new XPen(XColors.Black, 0.3);                
                

				int rowCount=AppForm.CURR_OCTT_DOC.IncludedTerms.Count;
				int columnCount = AppForm.CURR_OCTT_DOC.getNumberOfDays();

				string groupTitle=(string)reportGroupAndTable[0];
                                
				XRect rect = new XRect(tableStartX+termsTableColumnWidth, tableStartY-25, columnCount*columnWidth, 20);
                XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
                
                //
                /*char[] separator = new char[1];
                separator[0] = ',';
                string[] ss = Settings.TTREP_FONT_PAGE_TITLE.Split(separator, 3);
                string fontFamily = ss[0];
                string fontStyle = ss[1];
                int fontSize = System.Convert.ToInt32(ss[2]);
                //
                Type fs = typeof(XFontStyle);
                XFontStyle xfs=(XFontStyle)getValueForEnumeration(fs, fontStyle);

                XFont font = new XFont(fontFamily, fontSize, xfs, options);*/
                //XFont font = new XFont("Times", 16, XFontStyle.Bold, options);

                XFont font = getMyFont(Settings.TTREP_FONT_PAGE_TITLE, options);

				XBrush brush = XBrushes.Black;
				XStringFormat format = new XStringFormat();
				//gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
				format.LineAlignment = XLineAlignment.Center;
				format.Alignment = XStringAlignment.Center;
				gfx.DrawString(groupTitle, font, brush, rect, format);

                DataTable groupTable = (DataTable)reportGroupAndTable[1];

				drawHeaderTable(newPage, gfx, pen, tableStartX+termsTableColumnWidth,tableStartY,columnWidth, headerTableRowHeight);

				drawTermsTable(newPage, gfx, pen, tableStartX, tableStartY+headerTableRowHeight, termsTableColumnWidth, rowHeight);

				drawMainTable(newPage, gfx, pen, tableStartX+termsTableColumnWidth, tableStartY+headerTableRowHeight, columnWidth, rowHeight, groupTable);

				
				
				
				string docPropertiesString=AppForm.CURR_OCTT_DOC.EduInstitutionName+" "+AppForm.CURR_OCTT_DOC.SchoolYear;
				
				string lastChangeString;
				if(AppForm.CURR_OCTT_DOC.FullPath!=null)
				{
					FileInfo fi = new FileInfo(AppForm.CURR_OCTT_DOC.FullPath);				
					lastChangeString=RES_MANAGER.GetString("lastchangedate.text")+" "+fi.LastWriteTime.ToShortDateString()+" "+fi.LastWriteTime.ToLongTimeString();
				}
				else
				{
					lastChangeString="";
				}
				
				rect = new XRect(tableStartX,tableStartY+headerTableRowHeight+rowHeight*rowCount+5,250,10);
                //font = new XFont("Times", 8, XFontStyle.Regular, options);
                font = getMyFont(Settings.TTREP_FONT_FOOTER, options);
				//gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
				format.LineAlignment = XLineAlignment.Center;
				format.Alignment = XStringAlignment.Near;
				gfx.DrawString(docPropertiesString, font, brush, rect, format);

				rect = new XRect(tableStartX+termsTableColumnWidth+columnWidth*columnCount-200,tableStartY+headerTableRowHeight+rowHeight*rowCount+5,200,10);
                //font = new XFont("Times", 8, XFontStyle.Regular, options);				
				//gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
				format.LineAlignment = XLineAlignment.Center;
				format.Alignment = XStringAlignment.Far;
				gfx.DrawString(lastChangeString, font, brush, rect, format);

				rect = new XRect(tableStartX,tableStartY+headerTableRowHeight+rowHeight*rowCount+5,tableStartX+termsTableColumnWidth+columnWidth*columnCount,10);
                //font = new XFont("Times", 8, XFontStyle.Regular, options);				
				//gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
				format.LineAlignment = XLineAlignment.Center;
				format.Alignment = XStringAlignment.Center;
				gfx.DrawString("��������� ���������� (����������������.��)", font, brush, rect, format);
				
			}
			
			

			try
			{
				PDFDOCUMENT.Save(fileName);				
				Process.Start(Settings.PDF_READER_APPLICATION,fileName);
			}
			catch(Exception e)
			{
				try
				{
					Process.Start(fileName);
				}
				catch(Exception e2)
				{
					MessageBox.Show(e2.Message);
				}                
			}			
		}

		private static void drawHeaderTable(PdfPage newPage, XGraphics gfx, XPen pen, int startX, int startY, int columnWidth, int rowHeight)
		{
			int columnCount = AppForm.CURR_OCTT_DOC.getNumberOfDays();		

			gfx.DrawRectangle(pen, startX, startY, columnWidth*columnCount, rowHeight);

			for(int k=0;k<columnCount-1;k++)
			{
                gfx.DrawLine(pen, startX+(k+1)*columnWidth, startY, startX+(k+1)*columnWidth, startY+rowHeight);	
			}

			string dayName="";
			int modPos=0;
			for(int kk=0;kk<columnCount;kk++)
			{
				while(true)
				{
					if(AppForm.CURR_OCTT_DOC.getIsDayIncluded(modPos))
					{						
						break;
					}
					modPos++;
				}


				dayName=AppForm.getDayText()[modPos];
				modPos++;
				
				XRect rect = new XRect(startX+kk*columnWidth+4, startY+4, columnWidth-8, rowHeight-8);
                XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
                
				//XFont font = new XFont("Arial", 10, XFontStyle.Bold, options);
                XFont font = getMyFont(Settings.TTREP_FONT_DAY_NAMES, options);
				XBrush brush = XBrushes.Black;
				XStringFormat format = new XStringFormat();

                                                
                

				//gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);

				//gfx.DrawRectangle(XPens.Black, XBrushes.LightBlue, rect);
                char[] separator = new char[1];
                separator[0] = ',';
                string[] ss = Settings.TTREP_COLOR_HEADER.Split(separator, 3);
                int R = System.Convert.ToInt32(ss[0]);
                int G = System.Convert.ToInt32(ss[1]);
                int B = System.Convert.ToInt32(ss[2]);

                gfx.DrawRectangle(XPens.Black, new XSolidBrush(XColor.FromArgb(R,G,B)), rect);
                                

				format.LineAlignment = XLineAlignment.Center;
				format.Alignment = XStringAlignment.Center;
				gfx.DrawString(dayName, font, brush, rect, format);

			}
			
		}

		private static void drawTermsTable(PdfPage newPage, XGraphics gfx, XPen pen, int startX, int startY, int columnWidth, int rowHeight)
		{	

			int rowCount=AppForm.CURR_OCTT_DOC.IncludedTerms.Count;			

			gfx.DrawRectangle(pen, startX, startY, columnWidth, rowHeight*rowCount);

			for(int j=0;j<rowCount-1;j++)
			{
				gfx.DrawLine(pen, startX, startY+(j+1)*rowHeight, startX+columnWidth, startY+(j+1)*rowHeight);	
			}

			for(int j=0;j<rowCount;j++) 
			{
				int[] term=(int [])AppForm.CURR_OCTT_DOC.IncludedTerms[j];
				string [] printTerm=new string[4];
				for(int t=0;t<4;t++)
				{
					if(term[t]<10)
					{
						printTerm[t]="0"+System.Convert.ToString(term[t]);
					}
					else
					{
						printTerm[t]=System.Convert.ToString(term[t]);
					}
				}

				string termText=printTerm[0]+":"+printTerm[1]+"-"+printTerm[2]+":"+printTerm[3];


				XRect rect = new XRect(startX+4, startY+j*rowHeight+4, columnWidth-8, rowHeight-8);

                XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
				//XFont font = new XFont("Arial", 8, XFontStyle.Bold, options);
                XFont font = getMyFont(Settings.TTREP_FONT_TIME_PERIODS, options);

				XBrush brush = XBrushes.Black;
				XStringFormat format = new XStringFormat();

				//gfx.DrawRectangle(XPens.Black, XBrushes.Bisque, rect);
                char[] separator = new char[1];
                separator[0] = ',';
                string[] ss = Settings.TTREP_COLOR_TP.Split(separator, 3);
                int R = System.Convert.ToInt32(ss[0]);
                int G = System.Convert.ToInt32(ss[1]);
                int B = System.Convert.ToInt32(ss[2]);
                                
                gfx.DrawRectangle(XPens.Black, new XSolidBrush(XColor.FromArgb(R, G, B)), rect);
				//gfx.DrawRectangle(XPens.Black, XBrushes.LightBlue, rect);
                
				format.LineAlignment = XLineAlignment.Center;
				format.Alignment = XStringAlignment.Center;
				gfx.DrawString(termText, font, brush, rect, format);
			}

		}

		private static void drawMainTable(PdfPage newPage, XGraphics gfx, XPen pen, int startX, int startY, int columnWidth, int rowHeight,DataTable dt)
		{
			int rowCount=AppForm.CURR_OCTT_DOC.IncludedTerms.Count;	
			int columnCount = AppForm.CURR_OCTT_DOC.getNumberOfDays();

			for(int j=0;j<rowCount;j++)			
			{
				gfx.DrawLine(pen, startX, startY+(j+1)*rowHeight, startX+columnCount*columnWidth, startY+(j+1)*rowHeight);

				for(int k=0;k<columnCount;k++)
				{
					gfx.DrawLine(pen, startX+(k+1)*columnWidth, startY, startX+(k+1)*columnWidth, startY+rowCount*rowHeight);
				}
			}

			for(int j=0;j<rowCount;j++)			
			{
				DataRow dr=dt.Rows[j];
				for(int k=0;k<columnCount;k++)
				{
					string cellString=(string)dr[k];
					if(cellString!="")
					{
						XRect rect = new XRect(startX+k*columnWidth+4, startY+j*rowHeight+4, columnWidth-8, rowHeight-8);

                        //
                        XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);

						//XFont font = new XFont("Arial", 6, XFontStyle.Regular,  options);
                        XFont font = getMyFont(Settings.TTREP_FONT_TIME_SLOTS, options);
						XBrush brush = XBrushes.Black;
						//XStringFormat format = new XStringFormat();
                        //
                        char[] separator = new char[1];
                        separator[0] = ',';
                        string[] ss = Settings.TTREP_COLOR_TS.Split(separator, 3);
                        int R = System.Convert.ToInt32(ss[0]);
                        int G = System.Convert.ToInt32(ss[1]);
                        int B = System.Convert.ToInt32(ss[2]);

                        gfx.DrawRectangle(XPens.Black, new XSolidBrush(XColor.FromArgb(R, G, B)), rect);

                        //
						//gfx.DrawRectangle(XPens.Black, XBrushes.LightCyan, rect);

                        rect = new XRect(startX+k*columnWidth+6, startY+j*rowHeight+6, columnWidth-12, rowHeight-12);
						
						XTextFormatter tf = new XTextFormatter(gfx);
						tf.Alignment = XParagraphAlignment.Center;						
						tf.DrawString(cellString, font, brush, rect, XStringFormat.TopLeft);						
					}
				}
			}

		}

        private static XFont getMyFont(string myFontSettings, XPdfFontOptions options)
        {
            char[] separator = new char[1];
            separator[0] = ',';
            string[] ss = myFontSettings.Split(separator, 3);
            string fontFamily = ss[0];
            string fontStyle = ss[1];
            int fontSize = System.Convert.ToInt32(ss[2]);
            //
            Type fs = typeof(XFontStyle);
            XFontStyle xfs = (XFontStyle)getValueForEnumeration(fs, fontStyle);

            XFont font = new XFont(fontFamily, fontSize, xfs, options);
            //XFont font = new XFont("Times", 16, XFontStyle.Bold, options);

            return font;
        }


        private static object getValueForEnumeration(Type t, string sett)
        {
            string[] arstrps = Enum.GetNames(t);
            Array arps = Enum.GetValues(t);
            int nn = 0;
            int myindex = 0;
            foreach (string s in arstrps)
            {
                if (s == sett)
                {
                    myindex = nn;
                    break;
                }
                nn++;
            }

            return arps.GetValue(myindex);
        }


	}
}
