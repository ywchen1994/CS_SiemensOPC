#region Copyright
//------------------------------------------------------------------------
//   OPC UA - Example Client
//
//   Copyright (C) Siemens AG 2008  All Rights Reserved. Confidential
//------------------------------------------------------------------------
#endregion Copyright

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Siemens.OpcUA;
//using Opc.Ua;
//using Opc.Ua.Client;

namespace Siemens.OpcUA.Client
{
    public partial class AttributeListControl : UserControl
    {
        

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public System.Windows.Forms.DataGridView dataGridAttributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAttribute;
        private ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;

        public AttributeListControl()
        {
            InitializeComponent();
        }

        #region DataGrid definitions
        /// <summary>
        /// Policy how to adjust the columns in the list views
        /// </summary>
        enum enumColumnAttrGrid : int
        {
            Name = 0,
            Value,
            Status,
            DiagLocalizedText,
            DiagAdditionalInfo
        }

        // Index of Columns
        public struct ColumnAttrGrid
        {
            public const int Name = (int)enumColumnAttrGrid.Name;
            public const int Value = (int)enumColumnAttrGrid.Value;
            public const int Status = (int)enumColumnAttrGrid.Status;
            public const int DiagLocalizedText = (int)enumColumnAttrGrid.DiagLocalizedText;
            public const int DiagAdditionalInfo = (int)enumColumnAttrGrid.DiagAdditionalInfo;
        }
        #endregion

        void dataGridAttributes_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == ColumnAttrGrid.Value)
            {
                this.writeAttribute(e.Value);
            }
            e.ParsingApplied = true;
        }

        private void writeAttribute(object value)
        {
            //try
            //{
                //    ResponseHeader response;
                //    WriteValueCollection writeValues;
                //    StatusCodeCollection results;
                //    DiagnosticInfoCollection diagnosticInfos;

                //    // Try to convert the value to the same type like the read value
                //    //m_CurrentWriteValue.Value.Value = Convert.ChangeType(value, m_CurrentValue.GetType());
                //    m_CurrentWriteValue.Value.Value = value;

                //    writeValues = new WriteValueCollection();
                //    writeValues.Add(m_CurrentWriteValue);

                //    response = m_ClientAPI.Session.Write(
                //        null,
                //        writeValues,
                //        out results,
                //        out diagnosticInfos);
                //    if (StatusCode.IsBad(response.ServiceResult))
                //    {
                //        throw new ServiceResultException(new ServiceResult(response.ServiceResult, response.ServiceDiagnostics, response.StringTable));
                //    }
                //    if (StatusCode.IsBad(results[0]))
                //    {
                //        throw new ServiceResultException(new ServiceResult(results[0], 0, diagnosticInfos, response.StringTable));
                //    }
                //}
                //catch (ServiceResultException ex)
                //{
                //    statusLabel.Text = ex.Message + " " + ex.Result;
                //    statusLabel.Image = global::Siemens.OpcUA.ClientControl.Properties.Resources.error;
                //    return;
                //}
                //catch (Exception ex)
                //{
                //    statusLabel.Text = "An exception occured while writing: " + ex.Message;
                //    statusLabel.Image = global::Siemens.OpcUA.ClientControl.Properties.Resources.error;
                //    return;
                //}

                //statusLabel.Text = "Write succeeded for Node \"" + m_CurrentWriteNodeName + "\".";
                //statusLabel.Image = global::Siemens.OpcUA.ClientControl.Properties.Resources.success;
                //return;
            }
        

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridAttributes = new System.Windows.Forms.DataGridView();
            this.colAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAttributes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridAttributes
            // 
            this.dataGridAttributes.AllowUserToAddRows = false;
            this.dataGridAttributes.AllowUserToDeleteRows = false;
            this.dataGridAttributes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridAttributes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAttribute,
            this.colValue});
            this.dataGridAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAttributes.Location = new System.Drawing.Point(0, 0);
            this.dataGridAttributes.Name = "dataGridAttributes";
            this.dataGridAttributes.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.dataGridAttributes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridAttributes.Size = new System.Drawing.Size(150, 150);
            this.dataGridAttributes.TabIndex = 10;
            this.dataGridAttributes.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridAttributes_CellParsing);
            // 
            // colAttribute
            // 
            this.colAttribute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAttribute.Frozen = true;
            this.colAttribute.HeaderText = "Attribute";
            this.colAttribute.MinimumWidth = 80;
            this.colAttribute.Name = "colAttribute";
            this.colAttribute.ReadOnly = true;
            this.colAttribute.Width = 80;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Value";
            this.colValue.MinimumWidth = 200;
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            this.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colValue.Width = 200;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // AttributeListControl
            // 
            this.Controls.Add(this.dataGridAttributes);
            this.Name = "AttributeListControl";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAttributes)).EndInit();
            this.ResumeLayout(false);

        }
    }
        
}
