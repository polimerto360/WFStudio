using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace WFStudio
{
    public class ProjectInfo
    {
        public string filepath { get; set; } = "project.wfp";
        public MasterTrack Master = new MasterTrack();
        public List<Generator> Generators = new List<Generator>();
        public List<MixerTrack> Tracks = new List<MixerTrack>();
        public double bpm = 120;
        public int BeatsPerBar = 4;
        public void Save()
        {
            List<object> mastereffects = new List<object>();
            foreach(Effect e in Master.Effects)
            {
                mastereffects.Add(new
                {
                    type = e.GetType(),
                    obj = e.ToJsonObj()
                });
            }

            List<List<object>> channeleffects = new List<List<object>>();
            List<float> channelvolumes = new List<float>();
            foreach (MixerTrack t in Tracks)
            {
                List<object> trackeffects = new List<object>();
                foreach (Effect e in t.Effects)
                {
                    trackeffects.Add(new
                    {
                        type = e.GetType(),
                        obj = e.ToJsonObj()
                    });
                }
                channelvolumes.Add(t.Volume);
                channeleffects.Add(trackeffects);
            }

            List<object> generators = new List<object>();
            foreach(Generator g in Generators)
            {
                generators.Add(new
                {
                    type = g.GetType(),
                    obj = g.ToJsonObj()
                });
            } 

            System.IO.File.WriteAllText(filepath, JsonConvert.SerializeObject(new
            {
                bpm = bpm,
                bpb = BeatsPerBar,
                mastervolume = Master.Volume,
                mastereffects = mastereffects,
                channelvolumes = channelvolumes,
                channeleffects = channeleffects,
                generators = generators

            }));
        }
        public static void Load(string path)
        {
            dynamic obj = JsonConvert.DeserializeObject(System.IO.File.ReadAllText(path));
            ProjectInfo p = new ProjectInfo();
            Program.CurProject = p;

            p.bpm = obj.bpm;
            p.BeatsPerBar = obj.bpb;
            p.Master = new MasterTrack();
            p.Master.Volume = obj.mastervolume;

            p.Master.Effects = new List<Effect>();
            foreach(var e in obj.mastereffects)
            {
                Type t = e.type;
                Effect effect = (Effect)((Jsonconvertible)Activator.CreateInstance(t)).FromJson(e.obj);
                p.Master.Effects.Add(effect);
            }

            foreach(var ch in obj.channelvolumes)
            {
                MixerTrack t = new MixerTrack();
                t.Volume = ch;
                p.Tracks.Add(t);
            }

            int i = 0;
            foreach(var e in obj.channeleffects)
            {
                List<Effect> effects = new List<Effect>();
                foreach(var effect in e)
                {
                    Type t = effect.type;
                    Effect eff = (Effect)((Jsonconvertible)Activator.CreateInstance(t)).FromJson(effect.obj);
                    effects.Add(eff);
                }
                p.Tracks[i++].Effects = effects;
            }

            p.Generators = new List<Generator>();
            foreach(var g in obj.generators)
            {
                Type t = g.type;
                Generator gen = (Generator)((Jsonconvertible)Activator.CreateInstance(t)).FromJson(g.obj);
                //p.Generators.Add(gen);
            }
        }

    }
}
