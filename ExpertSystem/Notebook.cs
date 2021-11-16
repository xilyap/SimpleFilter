using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ExpertSystem
{
    public class Notebook
    {
        string name;
        string usage;
        string hddType;
        string hddSize;
        string ram;
        string videocardType;
        string batteryLife;
        string displayType;
        string displayResolution;
        string displayDiagonal;
        string displayFrequency;
        string hasOpticDrive;
        string canReplaceRAM;
        string canReplaceHDD;
        string hasGSM;
        string image;

        public Notebook(string name,string url, string image, string usage,string operativeSystem,string hddType, string hddSize,
        string ram,string videocardType, string batteryLife,string displayType, string displayResolution, string displayDiagonal,
        string displayFrequency,string hasOpticDrive, string canReplaceRAM, string canReplaceHDD, string hasGSM)
        {
            Name = name;
            Image = image;
            this.URL = url;
            this.Usage = usage;
            this.OS = operativeSystem;
            this.HddType = hddType;
            this.HddSize = hddSize;
            this.Ram = ram;
            this.VideocardType = videocardType;
            this.BatteryLife = batteryLife;
            this.DisplayType = displayType;
            this.DisplayResolution = displayResolution;
            this.DisplayDiagonal = displayDiagonal;
            this.DisplayFrequency = displayFrequency;
            this.CanReplaceRAM = canReplaceRAM;
            this.CanReplaceHDD = canReplaceHDD;
            this.HasGSM = hasGSM;
            this.hasOpticDrive = hasOpticDrive;

        }

        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public string Usage { get => usage; set => usage = value; }
        public string OS { get; set; }
        public string HddType { get => hddType; set => hddType = value; }
        public string HddSize { get => hddSize; set => hddSize = value; }
        public string Ram { get => ram; set => ram = value; }
        public string VideocardType { get => videocardType; set => videocardType = value; }
        public string BatteryLife { get => batteryLife; set => batteryLife = value; }
        public string DisplayType { get => displayType; set => displayType = value; }
        public string DisplayResolution { get => displayResolution; set => displayResolution = value; }
        public string DisplayDiagonal { get => displayDiagonal; set => displayDiagonal = value; }
        public string DisplayFrequency { get => displayFrequency; set => displayFrequency = value; }
        public string CanReplaceRAM { get => canReplaceRAM; set => canReplaceRAM = value; }
        public string CanReplaceHDD { get => canReplaceHDD; set => canReplaceHDD = value; }
        public string HasGSM { get => hasGSM; set => hasGSM = value; }
        public string URL { get; set; }
        public string HasOpticDrive { get => hasOpticDrive; set => hasOpticDrive = value; }
    }
}
