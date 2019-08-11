using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Client;
using Siemens.UAClientHelper;
using Siemens.OpcUA.Client;
namespace CS_Simens
{
    public partial class Form1 : Form
    {
        private UAClientHelperAPI m_Server = null;
        //private BrowseControl browseControl;
        //private AttributeListControl attributeListControl;
        //private MonitoredItemsControl monitoredItemsControl;
        public Form1()
        {
            InitializeComponent(); m_Server = new UAClientHelperAPI();
            m_Server.CertificateValidationNotification += new CertificateValidationEventHandler(m_Server_CertificateEvent);
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            EndpointWrapper wrapper;
            string endpointUrl;
            object item = UrlCB.SelectedItem;
            wrapper = (EndpointWrapper)item;
            endpointUrl = wrapper.Endpoint.EndpointUrl;
            m_Server.Connect(wrapper.Endpoint, true, "OpcUaClient", "SUNRISE");
        
            UrlCB.Enabled = false;

            


            List<string> readList=new List<string>();
            List<string> rest = new List<string>();
            readList.Add("ns=2;s=/Channel/State/actToolLength1");
            readList.Add("ns=2;s=/Channel/GeometricAxis/actToolBasePos[u1,2]");

            rest =m_Server.ReadValues(readList);
            while (true)
            {
                rest = m_Server.ReadValues(readList);
                label2.Text = rest[1].ToString();
                //label2.Update();
                label2.Refresh();
            }
       
        }
       
        private void UrlCB_DropDown(object sender, EventArgs e)
        {
            try
            {
                Uri discoveryUrl = null;


                // Create the uri from hostname.
                string sUrl = "opc.tcp://" + label1.Text + textBox1.Text + ":4840";

                // Has the port been entered by the user?



                // Create the uri itself.
                discoveryUrl = new Uri(sUrl);


               

                // Clear all items of the ComboBox.
                UrlCB.Items.Clear();
                UrlCB.Text = "";

                // Look for servers
                ApplicationDescriptionCollection servers = null;
                //Discovery discovery = new Discovery();

                servers = m_Server.FindServers(discoveryUrl.ToString());

                // Populate the drop down list with the endpoints for the available servers.
                for (int iServer = 0; iServer < servers.Count; iServer++)
                {
                    try
                    {
                        // Create discovery client and get the available endpoints.
                        EndpointDescriptionCollection endpoints = null;
                        sUrl = servers[iServer].DiscoveryUrls[0];
                        discoveryUrl = new Uri(sUrl);

                        endpoints = m_Server.GetEndpoints(discoveryUrl.ToString());

                        // Create wrapper and fill the combobox.
                        for (int i = 0; i < endpoints.Count; i++)
                        {
                            // Create endpoint wrapper.
                            EndpointWrapper wrapper = new EndpointWrapper(endpoints[i]);

                            // Add it to the combobox.
                            UrlCB.Items.Add(wrapper);
                        }

                        // Update status label.
                        toolStripStatusLabel.Text = "GetEndpoints succeeded for " + servers[iServer].ApplicationName;
                        btn_Connect.Enabled=true;

                    }
                    catch (Exception)
                    {
                        // Update status label.
                        toolStripStatusLabel.Text = "GetEndpoints failed for " + servers[iServer].ApplicationName;

                    }
                }

               
            }
            catch (Exception ex)
            {
                // Update status label.
                toolStripStatusLabel.Text = "FindServers failed:" + ex.ToString();

            }
        }
        void m_Server_CertificateEvent(CertificateValidator validator, CertificateValidationEventArgs e)
        {
            // Ask user if he wants to trust the certificate
            DialogResult result = MessageBox.Show(
                "Do you want to accept the untrusted server certificate: \n" +
                "\nSubject Name: " + e.Certificate.SubjectName.Name +
                "\nIssuer Name: " + e.Certificate.IssuerName.Name,
                "Untrusted Server Certificate",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // If the certificate is stored in the trust list, the user is not asked again
                e.Accept = true;
            }
            else
            {
                e.Accept = false;
            }
        }


    }
}
