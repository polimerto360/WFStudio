using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFStudio
{
    public class NoteChannel
    {
        public Generator Target;
        public List<Note> NotesByStart = new List<Note>();
        public List<Note> CurNotes = new List<Note>();
        public NoteChannel(Generator target)
        {
            Target = target;
        }
        public void Update()
        {
            while (NotesByStart.Count > 0 && NotesByStart[0].Start <= Program.CurSample)
            {
                if (NotesByStart[0].Length + NotesByStart[0].Start > Program.CurSample)
                {
                    Note new_note = NotesByStart[0].Duplicate();
                    Target.PlayNote(new_note);
                    CurNotes.Add(new_note);
                    CurNotes.Sort((a, b) => (a.Start + a.Length > b.Start + b.Length) ? 1 : -1);
                }
                NotesByStart.RemoveAt(0);
            }

            while (CurNotes.Count > 0 && (CurNotes[0].Start + CurNotes[0].Length) < Program.CurSample)
            {
                Target.ReleaseNote(CurNotes[0]);
                CurNotes.RemoveAt(0);
            }
        }
    }
}
