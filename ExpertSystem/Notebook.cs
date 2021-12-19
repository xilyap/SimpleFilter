
namespace SimpleFilter
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

        public Notebook(string name, string url, string image, string usage, string operativeSystem, string hddType, string hddSize,
        string ram, string videocardType, string batteryLife, string displayType, string displayResolution, string displayDiagonal,
        string displayFrequency, string hasOpticDrive, string canReplaceRAM, string canReplaceHDD, string hasGSM, string CPU, string videocard)
        {
            Name = name;
            Image = image;
            URL = url;
            Usage = usage;
            OS = operativeSystem;
            HddType = hddType;
            HddSize = hddSize;
            Ram = ram;
            VideocardType = videocardType;
            BatteryLife = batteryLife;
            DisplayType = displayType;
            DisplayResolution = displayResolution;
            DisplayDiagonal = displayDiagonal;
            DisplayFrequency = displayFrequency;
            CanReplaceRAM = canReplaceRAM;
            CanReplaceHDD = canReplaceHDD;
            HasGSM = hasGSM;
            this.hasOpticDrive = hasOpticDrive;
            this.CPU = CPU;
            Videocard = videocard;
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
        public string CPU { get; set; }
        public string Videocard { get; set; }
    }
}
