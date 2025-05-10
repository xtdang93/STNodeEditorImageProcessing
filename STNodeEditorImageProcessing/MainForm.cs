using System;
using System.Drawing;
using System.Windows.Forms;
using ST.Library.UI.NodeEditor;

namespace STNodeEditorImageProcessing
{
    public partial class MainForm : Form
    {
        private STNodeEditorControl editor;

        public MainForm()
        {
            InitializeComponent();
            this.Text = "Simple Image Processing Node Editor";

            editor = new STNodeEditorControl
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(editor);

            // Tạo các node
            var loadNode = new LoadImageNode { Location = new Point(20, 20) };
            var grayNode = new GrayscaleNode { Location = new Point(200, 20) };
            var dispNode = new DisplayNode { Location = new Point(400, 20) };

            // Thêm vào editor
            editor.Nodes.Add(loadNode);
            editor.Nodes.Add(grayNode);
            editor.Nodes.Add(dispNode);

            // Kết nối các node
            loadNode.GetOption("Image").Connect(grayNode.GetOption("Input"));
            grayNode.GetOption("Gray").Connect(dispNode.GetOption("Image"));
        }
    }
}
