using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Band.ViewModels.Utilities
{
    public class NewListOfImageObject : List<ImageObject>
    {
        public new void Add(ImageObject img)
        {
            base.Add(img);
            this.OnChange();
        }

        /*public void UpdateLast(Image img)
        {
            base[base.Count - 1] = obj;
            this.OnChange();
        }*/
        public new void Remove(ImageObject img)
        {
            base.Remove(img);
            this.OnChange();
        }
        public new void RemoveAt(int i)
        {
            base.RemoveAt(i);
            this.OnChange();
        }

        public new void RemoveRange(int index, int count)
        {
            base.RemoveRange(index, count);
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
        private void ConvertFrom(NewListOfByteArrayImage list)
        {
            foreach(var x in list)
            {
                
            }
        }
    }
}
