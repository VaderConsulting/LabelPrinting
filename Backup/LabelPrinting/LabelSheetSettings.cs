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
using System.Text;
using System.Drawing.Printing;

namespace LabelPrinting
{
    class LabelSheetSettings:System.Drawing.Printing.PageSettings
    {
        public int LabelWidth; // Label width hundredths of an inch
        public int LabelHeight; // Label height hundredths of an inch
        public int LabelColumns; // Number of label columns
        public int LabelColumnSpacing; // Label column spacing hundredths of an inch
        public int LabelRows; // Number of label rows
        public int LabelRowSpacing; // Label row spacing hundredths of an inch
        public int LabelsPerSheet; // No. of labels on a sheet
        public Margins LabelMargins;  // Label margin hundredths of an inch

        public LabelSheetSettings(LabelKind lkLabelSheetProductCode):base()
        {
            ConfigureSettings(lkLabelSheetProductCode);
        }

        public LabelSheetSettings(PrinterSettings psPrinterSettings, LabelKind lkLabelSheetProductCode)
            : base(psPrinterSettings)
        {
            ConfigureSettings(lkLabelSheetProductCode);
        }

        private void ConfigureSettings(LabelKind lkLabelSheetProductCode)
        {
            this.PaperSize = new PaperSize("A4", 830, 1170);
            this.Landscape = false;

            switch (lkLabelSheetProductCode)
            {
                case LabelKind.L7159:
                case LabelKind.J8159:
                    this.LabelWidth = 250;
                    this.LabelHeight = 133;

                    this.LabelColumns = 3;
                    this.LabelColumnSpacing = 10;

                    this.LabelRows = 8;
                    this.LabelRowSpacing = 0;

                    this.Margins = new Margins(28, 28, 51, 24);

                    break;

                case LabelKind.L7160:
                case LabelKind.J8160:
                    this.LabelWidth = 250;
                    this.LabelHeight = 150;

                    this.LabelColumns = 3;
                    this.LabelColumnSpacing = 10;

                    this.LabelRows = 7;
                    this.LabelRowSpacing = 0;

                    this.Margins = new Margins(28, 28, 60, 24);

                    break;

                case LabelKind.L7161:
                case LabelKind.J8161:
                    this.LabelWidth = 250;
                    this.LabelHeight = 180;

                    this.LabelColumns = 3;
                    this.LabelColumnSpacing = 10;

                    this.LabelRows = 6;
                    this.LabelRowSpacing = 0;

                    this.Margins = new Margins(28, 28, 35, 24);

                    break;

                case LabelKind.L7162:
                case LabelKind.J8162:
                    this.LabelWidth = 390;
                    this.LabelHeight = 133;

                    this.LabelColumns = 2;
                    this.LabelColumnSpacing = 10;

                    this.LabelRows = 8;
                    this.LabelRowSpacing = 0;

                    this.Margins = new Margins(28, 28, 51, 24);

                    break;

                case LabelKind.L7163:
                case LabelKind.J8163:
                    this.LabelWidth = 390;
                    this.LabelHeight = 150;

                    this.LabelColumns = 2;
                    this.LabelColumnSpacing = 10;

                    this.LabelRows = 7;
                    this.LabelRowSpacing = 0;

                    this.Margins = new Margins(18, 18, 60, 24);

                    break;

                case LabelKind.L7164:
                case LabelKind.J8164:
                    this.LabelWidth = 250;
                    this.LabelHeight = 283;

                    this.LabelColumns = 3;
                    this.LabelColumnSpacing = 10;

                    this.LabelRows = 4;
                    this.LabelRowSpacing = 0;

                    this.Margins = new Margins(28, 28, 18, 0);

                    break;

                case LabelKind.L7165:
                case LabelKind.J8165:
                    this.LabelWidth = 390;
                    this.LabelHeight = 267;

                    this.LabelColumns = 2;
                    this.LabelColumnSpacing = 10;

                    this.LabelRows = 4;
                    this.LabelRowSpacing = 0;

                    this.Margins = new Margins(18, 18, 51, 24);

                    break;

                case LabelKind.L7166:
                case LabelKind.J8166:
                    this.LabelWidth = 390;
                    this.LabelHeight = 367;

                    this.LabelColumns = 2;
                    this.LabelColumnSpacing = 10;

                    this.LabelRows = 3;
                    this.LabelRowSpacing = 0;

                    this.Margins = new Margins(18, 18, 35, 24);

                    break;

                case LabelKind.L7167:
                case LabelKind.J8167:
                    this.LabelWidth = 786;
                    this.LabelHeight = 1138;

                    this.LabelColumns = 1;
                    this.LabelColumnSpacing = 0;

                    this.LabelRows = 1;
                    this.LabelRowSpacing = 0;

                    this.Margins = new Margins(20, 20, 16, 0);

                    break;

                case LabelKind.L7168:
                case LabelKind.J8168:
                    this.LabelWidth = 786;
                    this.LabelHeight = 565;

                    this.LabelColumns = 1;
                    this.LabelColumnSpacing = 0;

                    this.LabelRows = 2;
                    this.LabelRowSpacing = 0;

                    this.Margins = new Margins(20, 20, 20, 0);

                    break;

                case LabelKind.L7169:
                case LabelKind.J8169:
                    this.LabelWidth = 547;
                    this.LabelHeight = 390;

                    this.LabelColumns = 2;
                    this.LabelColumnSpacing = 0;

                    this.LabelRows = 2;
                    this.LabelRowSpacing = 10;

                    this.Margins = new Margins(37, 37, 18, 0);

                    this.Landscape = true;

                    break;

                case LabelKind.L7173:
                case LabelKind.J8173:
                    this.LabelWidth = 390;
                    this.LabelHeight = 224;

                    this.LabelColumns = 2;
                    this.LabelColumnSpacing = 10;

                    this.LabelRows = 5;
                    this.LabelRowSpacing = 0;

                    this.Margins = new Margins(18, 18, 24, 0);

                    break;
                //================================================

                default:
                    ConfigureSettings(LabelKind.L7163);
                    break;
            }

            this.LabelMargins = new Margins(10, 10, 10, 10);

            this.LabelsPerSheet = this.LabelColumns * this.LabelRows;

        }
    }
}
