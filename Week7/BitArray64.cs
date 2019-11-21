using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong state;
        public BitArray64(ulong value)
        {
            state = value;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public int this[int i]
        {
            get
            {
                ulong newState = state >> i;
                if (newState % 2 == 0)
                {
                    return 0;
                }
                return 1;
            }

            set
            {   ////Clear the position
                state &= ~((ulong)(1 << i));
                // Set the bit at position index to value
                state |= (ulong)(value << i);
            }
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
            {
                yield return this[i];
            }
        }
        public override bool Equals(object obj)
        {
            BitArray64 x = obj as BitArray64;
            
            return this.state.Equals(x.state);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();        }
       
    }
}
