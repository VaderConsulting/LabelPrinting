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

                LabelPrinting.LabelSet lsAddressLabels = new LabelPrinting.LabelSet(LabelKind.Savemor);

// Set the label font as required: 

                lsAddressLabels.LabelFont = new Font("Arial", 24,FontStyle.Bold);

// Create label objects... 

                LabelPrinting.Label lblAddressLabel1 = new LabelPrinting.Label();

                lblAddressLabel1.AddTextLine(" ");
                lblAddressLabel1.AddTextLine("Huggies-Nappies 40 pack");
                lblAddressLabel1.AddTextLine("");
                lblAddressLabel1.AddTextLine("1 Hello World 5");
                lblAddressLabel1.AddTextLine("1 Hello World 6");
                lblAddressLabel1.AddTextLine("1 Hello World 7");
                lblAddressLabel1.AddTextLine("12345678901234");


                LabelPrinting.Label lblAddressLabel2 = new LabelPrinting.Label();

                lblAddressLabel2.AddTextLine("12345678901234");
                lblAddressLabel2.AddTextLine("1 Hello World 2");
                lblAddressLabel2.AddTextLine("1 Hello World 3");
                lblAddressLabel2.AddTextLine("1 Hello World 4");
                lblAddressLabel2.AddTextLine("1 Hello World 5");
                lblAddressLabel2.AddTextLine("1 Hello World 6");
                lblAddressLabel2.AddTextLine("1 Hello World 7");
                lblAddressLabel2.AddTextLine("12345678901234");

                LabelPrinting.Label lblAddressLabel3 = new LabelPrinting.Label();

                lblAddressLabel3.AddTextLine("12345678901234");
                lblAddressLabel3.AddTextLine("1 Hello World 2");
                lblAddressLabel3.AddTextLine("1 Hello World 3");
                lblAddressLabel3.AddTextLine("1 Hello World 4");
                lblAddressLabel3.AddTextLine("1 Hello World 5");
                lblAddressLabel3.AddTextLine("1 Hello World 6");
                lblAddressLabel3.AddTextLine("1 Hello World 7");
                lblAddressLabel3.AddTextLine("12345678901234");

                LabelPrinting.Label lblAddressLabel4 = new LabelPrinting.Label();

                lblAddressLabel4.AddTextLine("4 Hello World 1");
                lblAddressLabel4.AddTextLine("4 Hello World 2");
                lblAddressLabel4.AddTextLine("4 Hello World 3");
                lblAddressLabel4.AddTextLine("4 Hello World 4");

                LabelPrinting.Label lblAddressLabel5 = new LabelPrinting.Label();

                lblAddressLabel5.AddTextLine("5 Hello World 1");
                lblAddressLabel5.AddTextLine("5 Hello World 2");
                lblAddressLabel5.AddTextLine("5 Hello World 3");
                lblAddressLabel5.AddTextLine("5 Hello World 4");

                LabelPrinting.Label lblAddressLabel6 = new LabelPrinting.Label();

                lblAddressLabel6.AddTextLine("12345678901234");
                lblAddressLabel6.AddTextLine("1 Hello World 2");
                lblAddressLabel6.AddTextLine("1 Hello World 3");
                lblAddressLabel6.AddTextLine("1 Hello World 4");
                lblAddressLabel6.AddTextLine("1 Hello World 5");
                lblAddressLabel6.AddTextLine("1 Hello World 6");
                lblAddressLabel6.AddTextLine("1 Hello World 7");
                lblAddressLabel6.AddTextLine("12345678901234");

// And add the labels to your label set:

                lsAddressLabels.AddLabel(lblAddressLabel1);		
                lsAddressLabels.AddLabel(lblAddressLabel2);		
                lsAddressLabels.AddLabel(lblAddressLabel3);
                lsAddressLabels.AddLabel(lblAddressLabel4);
                lsAddressLabels.AddLabel(lblAddressLabel5);
                lsAddressLabels.AddLabel(lblAddressLabel6);

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