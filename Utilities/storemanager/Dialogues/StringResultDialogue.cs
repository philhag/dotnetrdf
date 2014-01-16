﻿using System;
using System.Windows.Forms;

namespace VDS.RDF.Utilities.StoreManager.Dialogues
{
    public partial class StringResultDialogue : Form
    {
        private readonly Control _targetControl;

        public StringResultDialogue(String title, String result, Control control, String controlDescription)
        {
            InitializeComponent();
            this.Text = String.Format(this.Text, title);
            this.txtResult.Text = result;
            this._targetControl = control;
            this.btnCopyToControl.Text = String.Format(this.btnCopyToControl.Text, controlDescription);
            this.btnCopyToControl.Enabled = this._targetControl != null;
        }

        public StringResultDialogue(String title, String result)
            : this(title, result, null, "Editor") { }

        private void btnCopyToControl_Click(object sender, EventArgs e)
        {
            if (this._targetControl == null) return;
            this._targetControl.Text = this.txtResult.Text;
            this.Close();
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtResult.Text, TextDataFormat.Text);
            this.Close();
        }
    }
}