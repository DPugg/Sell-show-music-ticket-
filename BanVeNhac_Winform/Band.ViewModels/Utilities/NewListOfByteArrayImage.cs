using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Band.ViewModels.Utilities
{
    public class NewListOfByteArrayImage : List<ByteArrayImageObject>
    {
        public NewListOfByteArrayImage() { }
        public new void Add(ByteArrayImageObject img)
        {
            base.Add(img);
            this.OnChange();
        }

        /*public void UpdateLast(Image img)
        {
            base[base.Count - 1] = obj;
            this.OnChange();
        }*/
        public new void Remove(ByteArrayImageObject img)
        {
            base.Remove(img);
            this.OnChange();
        }

        public new void Clear()
        {
            base.Clear();
            this.OnChange();
        }
        /*public int Count()
        {
            int result = 0;
            foreach (var x in this)
            {
                result++;
            }
            return result;
        }*/

        public event EventHandler Change;

        protected void OnChange()
        {
            if (this.Change != null)
            {
                this.Change(this, new EventArgs() { });
            }
        }
        
    }
}
