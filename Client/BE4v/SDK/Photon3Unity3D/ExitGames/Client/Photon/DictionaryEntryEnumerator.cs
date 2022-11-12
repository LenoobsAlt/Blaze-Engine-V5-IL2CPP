using System;
using System.Collections;
using System.Collections.Generic;

namespace IL2ExitGames.Client.Photon
{
    public class DictionaryEntryEnumerator : IEnumerator<DictionaryEntry>, IEnumerator, IDisposable
    {
        public DictionaryEntryEnumerator(IDictionaryEnumerator original)
        {
            enumerator = original;
        }

        public bool MoveNext()
        {
            return enumerator.MoveNext();
        }

        public void Reset()
        {
            enumerator.Reset();
        }

        object IEnumerator.Current
        {
            get
            {
                return (DictionaryEntry)enumerator.Current;
            }
        }

        public DictionaryEntry Current
        {
            get
            {
                return (DictionaryEntry)enumerator.Current;
            }
        }

        public object Key
        {
            get
            {
                return enumerator.Key;
            }
        }

        public object Value
        {
            get
            {
                return enumerator.Value;
            }
        }

        public DictionaryEntry Entry
        {
            get
            {
                return enumerator.Entry;
            }
        }

        public void Dispose()
        {
            enumerator = null;
        }

        private IDictionaryEnumerator enumerator;
    }
}