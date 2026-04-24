using NAudio.CoreAudioApi.Interfaces;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFStudio
{
    public interface Generator : ISampleProvider
    {
        List<Note> CurNotes { get; set; }
        MixerTrack Target { get; set; }
        void PlayNote(Note n);
        void ReleaseNote(Note n);
        void StopAll();
        event Action<Note> NotePlayed;
        event Action<Note> NoteReleased;
        int VoiceCount { get; set; }
        NoteChannel noteChannel { get; set; }
    }
}
