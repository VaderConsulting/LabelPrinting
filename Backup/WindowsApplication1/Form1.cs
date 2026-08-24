using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//To start printing address labels, first include the LabelPrinting name space in your code 
using LabelPrinting;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

// In your code, create a LabelSet object, specifying the label type (Avery product code) you require.:

                LabelPrinting.LabelSet lsAddressLabels = new LabelPrinting.LabelSet(LabelKind.L7163);

// Set the label font as required: 

                lsAddressLabels.LabelFont = new Font("Arial", 20);

// Create label objects... 

                LabelPrinting.Label lblAddressLabel = new LabelPrinting.Label();

                lblAddressLabel.AddTextLine("Hello World 1");
                lblAddressLabel.AddTextLine("Hello World 2");
                lblAddressLabel.AddTextLine("Hello World 3");
                lblAddressLabel.AddTextLine("Hello World 4");

// And add the labels to your label set:

                lsAddressLabels.AddLabel(lblAddressLabel);		
                lsAddressLabels.AddLabel(lblAddressLabel);		
                lsAddressLabels.AddLabel(lblAddressLabel);

// Create a PrintDialog to allow the user to choose a printer:

                dlgPrintDialog.Document = lsAddressLabels;
                dlgPrintDialog.AllowSomePages = true;

// Offer the user a preview, or print directly to paper:

                if (dlgPrintDialog.ShowDialog() == DialogResult.OK)
                {
                    // Show a print preview... 
                    PrintPreviewDialog dlgPrintPreview = new PrintPreviewDialog();
                    dlgPrintPreview.Document = lsAddressLabels;

                    // show the dialog... 
                    dlgPrintPreview.ShowDialog(); 
                }
        }
    }
}