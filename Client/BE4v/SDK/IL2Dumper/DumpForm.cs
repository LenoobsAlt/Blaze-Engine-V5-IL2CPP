using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using System.Windows.Forms;
using VRC;

namespace BE4v.SDK.IL2Dumper
{
    public partial class DumpForm : Form
    {
        public DumpForm()
        {
            InitializeComponent();
        }

        private void AddClass(TreeNodeCollection node, IL2Class klass)
        {
            if (klass == null) return;
            //if (IL2Utils.CheckIsObfus(klass.Name))
            //{
                Type type = null;
                foreach (var t in types)
                {
                    var field = t.GetFields().FirstOrDefault(x => x.IsStatic && x.FieldType == typeof(IL2Class))?.GetValue(null);
                    if (field == null) continue;
                    if (((IL2Class)field).Token == klass.Token)
                    {
                        type = t;
                        break;
                    }
                }

                if (type != null)
                {
                    if (!string.IsNullOrWhiteSpace(type.Namespace))
                        klass.Namespace = type.Namespace;
                    klass.Name = type.Name;
                }
            //}


            string name_space = "-";
            string klass_name = klass.Name;
            if (!string.IsNullOrWhiteSpace(klass.Namespace))
                name_space = klass.Namespace;

            int index = node.AddIsNull(name_space);
            if (index == -1) return;
            node = node[index].Nodes;
            index = node.AddIsNull(klass_name, klass.Token.ToString());
            if (index == -1) return;
        }

        private void AddText(TreeNodeCollection node, string text)
        {
            node.AddIsNull(text);
        }

        private void AddProperty(TreeNodeCollection node, IL2Property property)
        {
            int index = node.AddIsNull(property.Name, property.Pointer.ToString());
            node = node[index].Nodes;
            IL2Method getMethod = property.GetGetMethod();
            if (getMethod != null)
                node.AddIsNull("get: " + getMethod.Name, getMethod.Pointer.ToString());
            IL2Method setMethod = property.GetSetMethod();
            if (setMethod != null)
                node.AddIsNull("set: " + setMethod.Name, setMethod.Pointer.ToString());
        }

        private void AddMethod(TreeNodeCollection node, IL2Method method)
        {
            node.AddIsNull(method.Name, method.Token.ToString());
        }

        private void TreeDumpLib_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = TreeDumpLib.SelectedNode;
            if (node.Nodes.Count > 0) return;
            IL2Class klass = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.Token.ToString() == node.Name);
            if (klass == null) return;
            foreach(var m in klass.GetMethods())
            {
                AddMethod(node.Nodes, m);
            }
            foreach(var p in klass.GetProperties())
            {
                AddProperty(node.Nodes, p);
            }
        }

        private void DumpForm_ResizeEnd(object sender, EventArgs e)
        {
            Resized();
        }
        private void DumpForm_ResizeBegin(object sender, EventArgs e)
        {
            Resized();
        }

        private void DumpForm_Resize(object sender, EventArgs e)
        {
            Resized();
        }

        public void Resized()
        {
            Point point = new Point(0, 15);
            TreeDumpLib.Location = point;
            TreeDumpLib.Size = new Size((int)Math.Round(((double)Size.Width) / 3), Size.Height - point.Y);

            point.X += TreeDumpLib.Size.Width;
            textBox1.Location = point;
            textBox1.Size = new Size(Size.Width - point.X, Size.Height - point.Y);
        }

        public static Type[] types = null;

        private void DumpForm_Load(object sender, EventArgs e)
        {
            if (types == null)
            {
                List<Type> tList = new List<Type>();
                IL2Assembly assembly = IL2CPP.AssemblyList["Assembly-CSharp"];
                foreach (var x in typeof(Player).Assembly.GetTypes())
                {
                    if (x.IsGenericType)
                        continue;

                    foreach(var y in x.GetFields())
                    {
                        if (!y.IsStatic)
                            continue;

                        if (y.FieldType == typeof(IL2Class))
                        {
                            if (((IL2Class)y.GetValue(null))?.Assembly == assembly)
                            {
                                tList.Add(x);
                                break;
                            }
                        }
                    }
                }
                types = tList.ToArray();
            }
            timer1.Interval = 5000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TreeNodeCollection node = TreeDumpLib.Nodes;
            var klasses = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses();
            if (klasses.Length < iSkip)
            {
                timer1.Enabled = false;
                return;
            }
            foreach (var klass in klasses.Skip(iSkip))
            {
                timer1.Interval = 100;
                iSkip++;
                AddClass(node, klass);
            }
        }

        public int iSkip = 0;
    }
}
