using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UnityEngine;

namespace BE4v.UnityEditor
{
    public partial class UnityEditor_Form : Form
    {
        public UnityEditor_Form()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string search = textBoxSearch.Text;
            treeView_ObjectsList.Nodes.Clear();
            GameObject gameObject = GameObject.Find(search);
            treeView_ObjectsList.Nodes.Add(gameObject.transform.name);
            AddNodeParent(treeView_ObjectsList.Nodes, gameObject.transform);
            // GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
            // treeView_ObjectsList.Nodes.Add
        }

        private static void AddNodeParent(TreeNodeCollection treeNode, Transform component)
        {
            foreach(Transform transform in component)
            {
                treeNode.Add(transform.name);
                AddNodeParent(treeNode, transform);
            }
        }
    }
}
