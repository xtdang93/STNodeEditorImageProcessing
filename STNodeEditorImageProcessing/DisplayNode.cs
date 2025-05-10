using System.Drawing;
using ST.Library.UI.NodeEditor;

namespace STNodeEditorImageProcessing
{
    public class DisplayNode : STNode
    {
        private STNodeOption m_in = new STNodeOption("Image", typeof(Bitmap), true);
        private Bitmap m_image;

        public DisplayNode()
        {
            this.Title = "Display";
            this.InputOptions.Add(m_in);
        }

        protected override void OnOptionConnected(STNodeOption from, STNodeOption to)
        {
            if (from == m_in && this[m_in] is Bitmap bmp)
            {
                m_image = bmp;
                this.Invalidate();
            }
        }

        protected override void OnDrawBody(DrawingTools dt)
        {
            base.OnDrawBody(dt);
            if (m_image != null)
            {
                dt.Graphics.DrawImage(m_image, 10, 30, this.Width - 20, this.Height - 40);
            }
        }
    }
}
