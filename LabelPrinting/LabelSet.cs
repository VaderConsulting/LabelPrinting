/*
 * 
 * Address Label Printing API for Windows
 * Copyright (C) 2007 Peter John
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 * 
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

namespace LabelPrinting
{
    public class LabelSet : PrintDocument
    {
        public Font LabelFont;
        private Collection<Label> Labels = new Collection<Label>();
        private LabelSheetSettings lssLabelSheetSettings;
        private int NextLabel;
        private int NextPage;
        private int LastPage;


        public LabelSet()
            : this(LabelKind.L7163)
        {
        }

        public LabelSet(LabelKind lkLabelKind)
        {
            LabelFont = new Font("Arial", 10);

            lssLabelSheetSettings = new LabelSheetSettings(lkLabelKind);

            this.DefaultPageSettings = (PageSettings)lssLabelSheetSettings;

        }

        public LabelSet(string strFilePath)
            : this(strFilePath, LabelKind.L7163)
        {
        }

        public LabelSet(string strFilePath, LabelKind lkLabelKind)
        {
            // Set up the label sheet, and page settings

            LabelFont = new Font("Arial", 10);

            lssLabelSheetSettings = new LabelSheetSettings(lkLabelKind);

            this.DefaultPageSettings = (PageSettings)lssLabelSheetSettings;

            ReadCSVLabels(strFilePath);
        }

        private void ReadCSVLabels(string strFilePath)
        {
            FileStream fsFileStream;
            StreamReader srStreamReader;
            string strRawLabelData;


            // Read the label data, creating a label set.

            fsFileStream = new FileStream(strFilePath, FileMode.Open);

            Encoding encEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");

            srStreamReader = new StreamReader(fsFileStream, encEncoding);

            // Consume header line
            strRawLabelData = srStreamReader.ReadLine();

            while (!srStreamReader.EndOfStream)
            {
                strRawLabelData = srStreamReader.ReadLine();
                string[] tokLabelTokens = strRawLabelData.Split(new Char[] { ',' });

                Label lblAddressLabel = new Label();

                lblAddressLabel.AddTextLine(tokLabelTokens[2] + " " + tokLabelTokens[3] + " " + tokLabelTokens[4]);
                lblAddressLabel.AddTextLine(tokLabelTokens[5]);
                lblAddressLabel.AddTextLine(tokLabelTokens[6]);
                lblAddressLabel.AddTextLine(tokLabelTokens[7]);
                lblAddressLabel.AddTextLine(tokLabelTokens[8]);
                lblAddressLabel.AddTextLine(tokLabelTokens[9]);
                lblAddressLabel.AddTextLine(tokLabelTokens[10]);

                this.AddLabel(lblAddressLabel);
            }

            srStreamReader.Close();

            fsFileStream.Close();

            return;
        }

        public void AddLabel(Label NewLabel)
        {
            Labels.Add(NewLabel);
        }

        public Collection<Label> GetLabels()
        {
            return Labels;
        }

        // OnBeginPrint - called when printing starts 
        protected override void OnBeginPrint(PrintEventArgs e)
        {
            base.OnBeginPrint(e);
            base.OnBeginPrint(e);
            NextPage = this.PrinterSettings.FromPage;
            NextPage = (NextPage < 1) ? 1 : NextPage;
            LastPage = this.PrinterSettings.ToPage;
            NextLabel = (NextPage-1) * this.lssLabelSheetSettings.LabelsPerSheet;
        }

        // OnPrintPage - called when printing needs to be done... 
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);
            float x = 0;
            float y = 0;
            float w = 0;
            float h = 0;
            int LastLabel = Labels.Count;
            int CurrentColumn;
            int CurrentRow;
            
            RectangleF rectLabel;
            Label lblLabel;

            w = lssLabelSheetSettings.LabelWidth - (lssLabelSheetSettings.LabelMargins.Left + lssLabelSheetSettings.LabelMargins.Right);
            h = lssLabelSheetSettings.LabelHeight - (lssLabelSheetSettings.LabelMargins.Top + lssLabelSheetSettings.LabelMargins.Bottom);

            for (CurrentRow = 0; CurrentRow < lssLabelSheetSettings.LabelRows; CurrentRow++)
            {
                for (CurrentColumn = 0; CurrentColumn < lssLabelSheetSettings.LabelColumns; CurrentColumn++)
                {
                    if (NextLabel < LastLabel)
                    {
                        lblLabel = Labels[NextLabel];

                        x = lssLabelSheetSettings.Margins.Left; // 1/100in
                        y = lssLabelSheetSettings.Margins.Top; // 1/100in

                        x = x + (CurrentColumn * (lssLabelSheetSettings.LabelWidth + lssLabelSheetSettings.LabelColumnSpacing)) + lssLabelSheetSettings.LabelMargins.Left;
                        y = y + (CurrentRow * (lssLabelSheetSettings.LabelHeight + lssLabelSheetSettings.LabelRowSpacing)) + lssLabelSheetSettings.LabelMargins.Top;

                        //y = y + (CurrentLine * e.Graphics.MeasureString(textToPrint, printFont).Height);

                        rectLabel = new RectangleF(new PointF(x, y), new SizeF(w, h));

                        lblLabel.DrawLabel(e.Graphics, LabelFont, Brushes.Black, rectLabel);

                        NextLabel = NextLabel + 1;
                    }
                }
            }
            NextPage++;
            e.HasMorePages = (LastPage==0)?(NextLabel < Labels.Count):(NextPage <= LastPage);
        }
    }
}
