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
        public int CurIndex = 0;
        public NoteChannel(Generator target)
        {
            Target = target;
            Program.mainWindow.OnReset += () =>
            {
                CurIndex = 0;
                foreach (Note n in CurNotes)
                {
                    Target.ReleaseNote(n);
                }
                CurNotes = new List<Note>();
            };
        }
        public void Update()
        {
            while (CurIndex < NotesByStart.Count && NotesByStart.Count > 0 && NotesByStart[CurIndex].Start <= Program.CurSample)
            {
                if (NotesByStart[CurIndex].Length + NotesByStart[CurIndex].Start > Program.CurSample)
                {
                    Note new_note = NotesByStart[CurIndex].Duplicate();
                    Target.PlayNote(new_note);
                    CurNotes.Add(new_note);
                    CurNotes.Sort((a, b) => (a.Start + a.Length > b.Start + b.Length) ? 1 : -1);
                }
                CurIndex++;
            }

            while (CurNotes.Count > 0 && (CurNotes[0].Start + CurNotes[0].Length) < Program.CurSample)
            {
                Target.ReleaseNote(CurNotes[0]);
                CurNotes.RemoveAt(0);
            }
        }
    }
}
