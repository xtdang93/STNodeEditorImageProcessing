using System.Drawing;
using ST.Library.UI.NodeEditor;

namespace STNodeEditorImageProcessing
{
    public class GrayscaleNode : STNode
    {
        private STNodeOption m_in = new STNodeOption("Input", typeof(Bitmap), true);
        private STNodeOption m_out = new STNodeOption("Gray", typeof(Bitmap), false);

        public GrayscaleNode()
        {
            this.Title = "Grayscale";
            this.InputOptions.Add(m_in);
            this.OutputOptions.Add(m_out);
        }

        protected override void OnOptionConnected(STNodeOption from, STNodeOption to)
        {
            if (from == m_in && this[m_in] is Bitmap bmp)
            {
                Bitmap gray = ConvertToGrayscale(bmp);
                this[m_out] = gray;
            }
        }

        private Bitmap ConvertToGrayscale(Bitmap original)
        {
            Bitmap gray = new Bitmap(original.Width, original.Height);
            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color c = original.GetPixel(x, y);
                    int l = (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    gray.SetPixel(x, y, Color.FromArgb(l, l, l));
                }
            }
            return gray;
        }
    }
}

