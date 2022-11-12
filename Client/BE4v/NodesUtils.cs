using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public static class NodesUtils
{
    public static TreeNodeCollection ToNextNode(this TreeNodeCollection treeNode, string nameKey)
    {
        TreeNodeCollection result = null;
        int index = -1;
        if ((index = treeNode.IndexOfKey(nameKey)) != -1)
        {
            result = treeNode[index].Nodes;
        }
        return result;
    }

    public static int AddIsNull(this TreeNodeCollection treeNode, string nameKey, string offset = null)
    {
        int result = -1;
        if ((result = treeNode.IndexOfKey(nameKey)) == -1)
        {
            TreeNode treeItem = new TreeNode(nameKey);
            treeItem.Name = offset ?? nameKey;
            result = treeNode.Add(treeItem);
        }
        else
        {
            treeNode[result].Text = nameKey;
        }
        return result;
    }
}