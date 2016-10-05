using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Revision_Helper
{
    class ColouredCheckedListBox : CheckedListBox
    {
        public List<Color> colours = new List<Color>();

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                DrawItemEventArgs e2 =
new DrawItemEventArgs
(
e.Graphics,
e.Font,
new Rectangle(e.Bounds.Location, e.Bounds.Size),
e.Index,
e.State,
e.ForeColor,
colours[e.Index]
);
                base.OnDrawItem(e2);
            }
            else
            {
                base.OnDrawItem(e);
            }
        }
    }
}
