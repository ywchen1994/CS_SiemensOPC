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
using Opc.Ua;
using Opc.Ua.Client;

namespace Siemens.OpcUA.Client
{
    public partial class BrowseControl : UserControl
    {
        public TreeView tvBrowseTree;
        private System.Windows.Forms.ContextMenuStrip BrowseTreeContextMenu;
        private System.Windows.Forms.ContextMenuStrip BrowseTreeObjectContextMenu;
        private System.Windows.Forms.ContextMenuStrip BrowseTreeVariableContextMenu;
        private System.Windows.Forms.ToolStripMenuItem MIRebrowse1;
        private System.Windows.Forms.ToolStripMenuItem MIRebrowse2;
        private System.Windows.Forms.ContextMenuStrip BrowseTreeContextRebrowse;
        private System.Windows.Forms.ToolStripMenuItem MIRebrowse3;
        private System.Windows.Forms.ToolStripMenuItem MIBrowseOnline;
        private System.Windows.Forms.ToolStripMenuItem MIMonitor;
        //private System.Windows.Forms.ImageList imageListTreeView;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
    
        public BrowseControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowseControl));

            //this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);

            this.tvBrowseTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.tvBrowseTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvBrowseTree.Location = new System.Drawing.Point(0, 0);
            this.tvBrowseTree.Name = "tvBrowseTree";
            this.tvBrowseTree.Size = new System.Drawing.Size(183, 150);
            this.tvBrowseTree.TabIndex = 0;
            // 
            // BrowseControl
            // 
            this.Controls.Add(this.tvBrowseTree);
            this.Name = "BrowseControl";
            this.Size = new System.Drawing.Size(183, 150);
            this.ResumeLayout(false);
            this.tvBrowseTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvBrowseTree_BeforeExpand);
            this.tvBrowseTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvBrowseTree_AfterSelect);
            this.tvBrowseTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvBrowseTree_MouseDown);
            //// 
            //// imageListTreeView
            //// 
            //this.imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeView.ImageStream")));
            //this.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            //this.imageListTreeView.Images.SetKeyName(0, "error");
            //this.imageListTreeView.Images.SetKeyName(1, "treefolder");
            //this.imageListTreeView.Images.SetKeyName(2, "property");
            //this.imageListTreeView.Images.SetKeyName(3, "object");
            //this.imageListTreeView.Images.SetKeyName(4, "variable");
            //this.imageListTreeView.Images.SetKeyName(5, "method");
            //this.imageListTreeView.Images.SetKeyName(6, "objecttype");
            //this.imageListTreeView.Images.SetKeyName(7, "variabletype");
            //this.imageListTreeView.Images.SetKeyName(8, "reftype");
            //this.imageListTreeView.Images.SetKeyName(9, "datatype");
            //this.imageListTreeView.Images.SetKeyName(10, "type");
            //this.imageListTreeView.Images.SetKeyName(11, "view");
            // 
            // BrowseTreeContextMenu
            // 
            this.BrowseTreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIRebrowse2});
            this.BrowseTreeContextMenu.Name = "BrowseTreeContextMenu";
            this.BrowseTreeContextMenu.Size = new System.Drawing.Size(149, 48);
            // 
            // MIRebrowse2
            // 
            ///this.MIRebrowse2.Image = global::Siemens.OpcUA.Client.Properties.Resources.browse;
            this.MIRebrowse2.Name = "MIRebrowse2";
            this.MIRebrowse2.Size = new System.Drawing.Size(148, 22);
            this.MIRebrowse2.Text = "Rebrowse ...";
            this.MIRebrowse2.Click += new System.EventHandler(this.MIRebrowse2_Click);
            // 
            // BrowseTreeObjectContextMenu
            // 
            this.BrowseTreeObjectContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIRebrowse1,
            this.MIBrowseOnline,
            this.MIMonitor});
            this.BrowseTreeObjectContextMenu.Name = "BrowseTreeObjectContextMenu";
            this.BrowseTreeObjectContextMenu.Size = new System.Drawing.Size(189, 70);
            // 
            // MIRebrowse1
            // 
           /// this.MIRebrowse1.Image = global::Siemens.OpcUA.Client.Properties.Resources.browse;
            this.MIRebrowse1.Name = "MIRebrowse1";
            this.MIRebrowse1.Size = new System.Drawing.Size(188, 22);
            this.MIRebrowse1.Text = "Rebrowse ...";
            this.MIRebrowse1.Click += new System.EventHandler(this.MIRebrowse1_Click);
            // 
            // BrowseTreeVariableContextMenu
            // 
            this.BrowseTreeVariableContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIMonitor});
            this.BrowseTreeVariableContextMenu.Name = "BrowseTreeVariableContextMenu";
            this.BrowseTreeVariableContextMenu.Size = new System.Drawing.Size(189, 70);
            this.BrowseTreeContextMenu.ResumeLayout(false);
            this.BrowseTreeObjectContextMenu.ResumeLayout(false);
            this.BrowseTreeContextRebrowse.ResumeLayout(false);

        }

        public void customizeTreeNode(ref TreeNode node)
        {
            ReferenceDescription refDescr = (ReferenceDescription)node.Tag;
            //BrowseElement brElement = (BrowseElement)node.Tag;

            if (refDescr == null)
            {
                // error
                return;
            }

            // check for folder
            if (ExpandedNodeId.ToNodeId(refDescr.TypeDefinition, null) == ObjectTypes.FolderType)
            {
                node.ImageKey = "treefolder";
            }
            // check for property
            else if (ExpandedNodeId.ToNodeId(refDescr.ReferenceTypeId, null) == ReferenceTypes.HasProperty)
            {
                node.ImageKey = "property";
            }
            // check nodeClass
            else
            {
                switch (refDescr.NodeClass)
                {
                    case NodeClass.Object:
                        node.ImageKey = "object";
                        break;
                    case NodeClass.Variable:
                        node.ImageKey = "variable";
                        break;
                    case NodeClass.Method:
                        node.ImageKey = "method";
                        break;
                    case NodeClass.ObjectType:
                        node.ImageKey = "objecttype";
                        break;
                    case NodeClass.VariableType:
                        node.ImageKey = "variabletype";
                        break;
                    case NodeClass.ReferenceType:
                        node.ImageKey = "reftype";
                        break;
                    case NodeClass.DataType:
                        node.ImageKey = "datatype";
                        break;
                    case NodeClass.View:
                        node.ImageKey = "view";
                        break;
                    default:
                        node.ImageKey = "error";
                        break;
                }
            }
            node.SelectedImageKey = node.ImageKey;
            node.StateImageKey = node.ImageKey;
        }

        /// <summary>
        /// Sorts all TreeNodes in TreeNodeCollection
        /// </summary>
        /// <param name="nodes">Collection of TreeNodes to be sorted</param>
        public void sortTreeNode(TreeNodeCollection nodes)
        {
            if (nodes.Count > 1)
            {
                TreeNode[] arrNodes = new TreeNode[nodes.Count];

                nodes.CopyTo(arrNodes, 0);
                Array.Sort<TreeNode>(arrNodes, this.compareTreeNodes);
                nodes.Clear();
                nodes.AddRange(arrNodes);
            }
        }

        /// <summary>
        /// Compare method for TreeNode sorting. 
        /// 1st. characteristic: object class (defined by index of image in ImageList)
        /// 2nd. characteristic: Text property of the TreeNode
        /// </summary>
        /// <param name="nodeA">TreeNode to be compared</param>
        /// <param name="nodeB">TreeNode to be compared</param>
        /// <returns></returns>
        public int compareTreeNodes(TreeNode nodeA, TreeNode nodeB)
        {
            int imageIndexA = tvBrowseTree.ImageList.Images.IndexOfKey(nodeA.ImageKey);
            int imageIndexB = tvBrowseTree.ImageList.Images.IndexOfKey(nodeB.ImageKey);
            int compClass = Decimal.Compare(imageIndexA, imageIndexB);

            return (compClass == 0) ? String.Compare(nodeA.Text, nodeB.Text, true) : compClass;
        }

        private void tvBrowseTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // get current node
            TreeNode node = e.Node;

            //if (node != null)
            //{
            //    // browse next level
            //    browse(node, false);
            //}
        }

        private void tvBrowseTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // get current node
            TreeNode node = e.Node;

            //if (node != null)
            //{
            //    // read attributes
            //    readAttributes(node);
            //}
        }

        private void tvBrowseTree_MouseDown(object sender, MouseEventArgs e)
        {
            // ignore left button actions.
            if (e.Button != MouseButtons.Right) return;

            //// get item at events position
            //TreeNode node = tvBrowseTree.GetNodeAt(e.X, e.Y);

            //// select this node in the tree view
            //tvBrowseTree.SelectedNode = node;

            ////reset current item
            //m_CurrentMethod = null;

            //// check if node is valid
            //if (node != null)
            //{
            //    // Check if node is a method
            //    ReferenceDescription refDescr = node.Tag as ReferenceDescription;

            //    if (refDescr != null)
            //    {
            //        if (refDescr.NodeClass == NodeClass.Method)
            //        {
            //            m_CurrentMethod = node;
            //            m_CurrentNode = node;
            //            BrowseTreeContextMenu.Show(tvBrowseTree, e.Location);
            //        }
            //        else if (refDescr.NodeClass == NodeClass.Variable)
            //        {
            //            m_CurrentNode = node;
            //            BrowseTreeVariableContextMenu.Show(tvBrowseTree, e.Location);
            //        }
            //        else if (refDescr.NodeClass == NodeClass.Object)
            //        {
            //            m_CurrentSubdeviceFolder = null;
            //            m_CurrentSubdeviceTypesFolderNodeId = null;
            //            if (node.Checked == false)
            //            {
            //                browse(node, false);
            //            }
            //            if (node.Nodes.Count > 1)
            //            {
            //                foreach (TreeNode tempNode in node.Nodes)
            //                {
            //                    refDescr = tempNode.Tag as ReferenceDescription;
            //                    if (refDescr != null)
            //                    {
            //                        if (refDescr.BrowseName.Name == "SubDevices" && refDescr.NodeClass == NodeClass.Object)
            //                        {
            //                            m_CurrentSubdeviceFolder = tempNode;

            //                            ResponseHeader response;
            //                            BrowsePathCollection browsePaths = new BrowsePathCollection();
            //                            BrowsePathResultCollection results;
            //                            DiagnosticInfoCollection diagnosticInfos;

            //                            BrowsePath brPath = null;

            //                            brPath = new BrowsePath();
            //                            brPath.StartingNode = (NodeId)refDescr.NodeId;
            //                            brPath.RelativePath = new RelativePath(new QualifiedName("SupportedTypes", m_nsIndexOpcDi));
            //                            browsePaths.Add(brPath);

            //                            //try
            //                            //{
            //                            //    //response = m_ClientAPI.TranslateBrowsePathToNodeIds(
            //                            //    //    browsePaths,
            //                            //    //    out results,
            //                            //    //    out diagnosticInfos);

            //                            //    results = 

            //                            //    // input arguments
            //                            //    if (StatusCode.IsGood(results[0].StatusCode))
            //                            //    {
            //                            //        m_CurrentSubdeviceTypesFolderNodeId = ExpandedNodeId.ToNodeId(results[0].Targets[0].TargetId, null);
            //                            //    }
            //                            //}
            //                            //catch (Exception exception)
            //                            //{
            //                            //    statusLabel.Text = "Error calling TranslateBrowsePathsToNodeIds: " + exception.Message;
            //                            //    statusLabel.Image = global::Siemens.OpcUA.ClientControl.Properties.Resources.error;
            //                            //}
            //                        }
            //                    }
            //                }
            //            }

            //            if (m_CurrentSubdeviceTypesFolderNodeId != null && m_CurrentSubdeviceFolder != null)
            //            {
            //                m_CurrentNode = node;
            //                BrowseTreeObjectContextMenu.Show(tvBrowseTree, e.Location);
            //            }
            //            else
            //            {
            //                m_CurrentNode = node;
            //                BrowseTreeContextRebrowse.Show(tvBrowseTree, e.Location);
            //            }
            //        }
            //        else
            //        {
            //            m_CurrentNode = node;
            //            BrowseTreeContextRebrowse.Show(tvBrowseTree, e.Location);
            //        }
            //    }
            //}
        }

        private void MIRebrowse1_Click(object sender, EventArgs e)
        {
            //if (m_CurrentNode.Checked == true)
            //{
            //    bool wasExpanded = m_CurrentNode.IsExpanded;
            //    if (wasExpanded)
            //    {
            //        m_CurrentNode.Collapse();
            //    }
            //    m_CurrentNode.Nodes.Clear();
            //    m_CurrentNode.Checked = false;
            //    browse(m_CurrentNode, false);
            //    if (wasExpanded)
            //    {
            //        m_CurrentNode.Expand();
            //    }
            //}
        }

        private void MIRebrowse2_Click(object sender, EventArgs e)
        {
            MIRebrowse1_Click(sender, e);
        }

        private void MIRebrowse3_Click(object sender, EventArgs e)
        {
            MIRebrowse1_Click(sender, e);
        }
    }
}
