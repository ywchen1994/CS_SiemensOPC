using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Opc.Ua;
using Opc.Ua.Client;
using Siemens.UAClientHelper;

namespace Siemens.OpcUA.Client
{
    public partial class WriteValuesDialog : Form
    {
        #region Construction
        public WriteValuesDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Fields
        /// <summary>
        /// Provides access to OPC UA server.
        /// </summary>
        private UAClientHelperAPI m_Server;
        #endregion

        #region Public Interfaces
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        /// <param name="server">The server instance.</param>
        /// <param name="itemCollection">The <see cref="System.EventArgs"/> Collection of items to display.</param>
        public void Show(UAClientHelperAPI server, ListViewItem[] itemCollection)
        {
            if (server == null) throw new ArgumentNullException("server");

            // Set server,
            m_Server = server;

            // Add the items to the listview.
            foreach (ListViewItem item in itemCollection)
            {
                this.listView.Items.Add(item);
            }

            // Fit the width of the columns to header size.
            this.listView.Columns[0].Width = -2;
            this.listView.Columns[1].Width = -2;
            this.listView.Columns[2].Width = -2;

            // Write the values.
            UpdateCurrentValues();

            // Display the control,
            Show();
            // and bring it to front.
            BringToFront();
        }
        #endregion

        /// <summary>
        /// Handles the Ok click event.
        /// Writes the values and then closes the dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // Write the values.
            WriteValues();

            // Close dialog.
            Close();
        }

        /// <summary>
        /// Write values without closing the dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Write the values.
            WriteValues();

            // Display the values.
            UpdateCurrentValues();
        }

        /// <summary>
        /// Writes the values.
        /// </summary>
        private void WriteValues()
        {
            try
            {
                // Prepare call to ClientAPI.
                List<string> nodesToWrite = new List<string>(this.listView.Items.Count);
                List<string> writeValues = new List<string>(this.listView.Items.Count);

                int i = 0;
                foreach (ListViewItem item in this.listView.Items)
                {
                    // Values to write.
                    String sValue = (String)item.SubItems[0].Text;
                    
                    // Leave current value if write value is empty.
                    if (sValue.Length == 0)
                    {
                        i++;
                        continue;
                    }
                    writeValues.Add(sValue);

                    // NodeIds.
                    nodesToWrite.Add(item.SubItems[1].Text);
                    i++;
                }

                // Call to ClientAPI.
                m_Server.WriteValues(writeValues, nodesToWrite);

                // Update status label.
                
                toolStripLabel1.Text = "Writing values succeeded.";
            }
            catch (Exception e)
            {
                // Update status label.
                toolStripLabel1.Text = "An exception occured while writing values: "
                    + e.Message;
            }
        }

        /// <summary>
        /// Writes and displays the new values.
        /// </summary>
        private void UpdateCurrentValues()
        {
            try
            {
                // Prepare call to ClientAPI.
                List<string> nodesToRead = new List<string>(this.listView.Items.Count);
                List<string> readResults = new List<string>();

                foreach (ListViewItem item in this.listView.Items)
                {
                    // NodeIds.
                    nodesToRead.Add(item.SubItems[1].Text);
                }

                // Call to ClientAPI.
                readResults = m_Server.ReadValues(nodesToRead);

                int i = 0;
                foreach (ListViewItem item in this.listView.Items)
                {
                    // Update current value.
                    item.SubItems[2].Text = readResults[i];
                    i++;
                }
            }
            catch (Exception e)
            {
                // Update status label.
                toolStripLabel1.Text = "An error occured.";
            }
        }

        /// <summary>
        /// Cancel writing values.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Close dialog.
            Close();
        }
    }
}
