using System.Drawing;
using System.Windows.Forms;
using ST.Library.UI.NodeEditor;

namespace STNodeEditorImageProcessing
{
    public class LoadImageNode : STNode
    {
        private STNodeOption m_out = new STNodeOption("Image", typeof(Bitmap), false);

        public LoadImageNode()
        {
            this.Title = "Load Image";
            this.OutputOptions.Add(m_out);
            this.Size = new Size(120, 60);
            this.Click += (s, e) =>
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Image Files|*.jpg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bmp = new Bitmap(dlg.FileName);
                    this[m_out] = bmp;
                    this.Invalidate(); // Vẽ lại node
                }
            };
        }
    }
}

