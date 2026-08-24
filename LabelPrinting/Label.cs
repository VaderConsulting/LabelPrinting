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

namespace LabelPrinting
{
    public class Label
    {
        private Collection<String> TextStrings = new Collection<String>();

        public Label()
        {
        }

        public void DrawLabel(Graphics gGraphics, Font fntLabelFont, Brush brshLabelBrush, RectangleF rectLabel)
        {
            int CurrentLine;
            String strTextToPrint = "";

            for (CurrentLine = 0; CurrentLine < this.GetTextStrings().Count; CurrentLine++)
            {
                if (this.GetTextStrings()[CurrentLine].Length > 0)
                {
                    strTextToPrint = strTextToPrint + this.GetTextStrings()[CurrentLine] + "\n";
                }
            }
            gGraphics.DrawString(strTextToPrint, fntLabelFont, brshLabelBrush, rectLabel);
        }

        public void AddTextLine(String Line)
        {
            TextStrings.Add(Line);
        }

        public Collection<String> GetTextStrings()
        {
            return TextStrings;
        }

    }
}
