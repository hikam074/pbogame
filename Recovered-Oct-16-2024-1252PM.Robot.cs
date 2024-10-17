using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TUGAS2.Classes
{
    abstract class Robot
    {
        // atribut
        public string nama;
        public int energi;
        public int armor;
        public int serangan;

        // constructor
        public Robot(string _nama, int _energi, int _armor, int _serangan)
        {
            this.nama = _nama;
            this.energi = _energi;
            this.armor = _armor;
            this.serangan = _serangan;
        }

        // method
        public abstract void serang(Robot target);
        public abstract void gunakanKemampuan(IKemampuan kemampuan);
        public abstract void cetakInformasi();


        public abstract void diserang(int serangan);
    }
    class NormalRobot : Robot
    {
        public bool isAlive = false;

        // constructor
        public NormalRobot(string _nama, int _energi, int _armor, int _serangan) : base(_nama, _energi, _armor, _serangan)
        {
            this.isAlive = true;
        }

        // method derived
        public override void serang(Robot target)
        {
            target.diserang(serangan, penyerang);
            Console.WriteLine($"SERANG : {this.nama} menyerang {target.nama} sebesar {this.serangan}!");
        }
        public override void gunakanKemampuan(IKemampuan kemampuan)
        {
            kemampuan.Use(this);
            Console.WriteLine($"GUNAKAN KEMAMPUAN : {this.nama} menggunakan kekuatan {kemampuan}!");
        }
        public override void cetakInformasi()
        {
            Console.WriteLine($"{this.nama} Energi: {this.energi}, Armor: {this.armor}, Serangan: {this.serangan}");
        }
    }
    class BosRobot : Robot
    {
        // atribut tambahan
        public int pertahanan;

        public bool isAlive = false;

        // constructor
        public BosRobot(string _nama, int _energi, int _armor, int _serangan, int _pertahanan) : base(_nama, _energi, _armor, _serangan)
        {
            this.pertahanan = _pertahanan;
            this.armor += this.pertahanan;
            this.isAlive = true;
        }

        // method derived
        public override void serang(Robot target)
        {
            target.energi -= serangan;
            Console.WriteLine($"SERANG : {this.nama} menyerang {target.nama} sebesar {this.serangan}!");
        }
        public override void gunakanKemampuan(IKemampuan kemampuan)
        {
            kemampuan.Use(this);
            Console.WriteLine($"GUNAKAN KEMAMPUAN : {this.nama} menggunakan kekuatan {kemampuan}!");
        }
        public override void cetakInformasi()
        {
            Console.WriteLine($"{this.nama} Energi: {this.energi}, Armor: {this.armor}, Serangan: {this.serangan}");
        }
        // method native
        public override void diserang(int jmlSerangan)
        {
            if (this.energi - jmlSerangan + this.pertahanan > 0)
            {
                this.energi -= jmlSerangan - this.pertahanan;
                Console.WriteLine($"DISERANG : boss {this.nama} diserang oleh {penyerang.nama}");
            }
            else
            {
                mati();
            }
        }
        public void mati()
        {
            Console.WriteLine($"DEFEATED : Boss {this.nama} telah dikalahkan!");
            this.isAlive = false;
        }
    }



    interface IKemampuan
    {
        public string namaKemampuan
        {
            get {return namaKemampuan;}
        }
        public void Use(Robot target);
    }
    class Repair : IKemampuan
    {
        public string namaKemampuan = "Repair";
        public int repairPoint;
        public Repair(int jmlRepair)
        {
            this.repairPoint = jmlRepair;
        }
        public void Use(Robot target)
        {
            target.energi += repairPoint;
            Console.WriteLine($"Kemampuan REPAIR : menambah energi {target.nama} sebesar {repairPoint}");
        }
    }
    class ElectricShock : IKemampuan
    {
        public string namaKemampuan = "ElectricShock";
        public int electricDamage;
        public ElectricShock(int jmlSerangan)
        {
            this.electricDamage = jmlSerangan;
        }
        public void Use(Robot target)
        {
            target.energi -= electricDamage;
            Console.WriteLine($"Kemampuan ELECTRIC SHOCK : menyerang {target.nama} sebesar {this.electricDamage}");
        } // stunnya mana
    }
    class PlasmaCannon : IKemampuan
    {
        public string namaKemampuan = "PlasmaCannon";
        public int plasmaDamage;
        public PlasmaCannon(int jmlSerangan)
        {
            this.plasmaDamage = jmlSerangan;
        }
        public void Use(Robot target)
        {
            target.energi -= plasmaDamage;
            Console.WriteLine($"Kemampuan PLASMA CANNON : menyerang {target.nama} sebesar {this.plasmaDamage}");
        }
    }
    class SuperShield : IKemampuan
    {
        public string namaKemampuan = "SuperShield";
        public int shieldPoint;
        public SuperShield(int jmlShieldPoint)
        {
            this.shieldPoint = jmlShieldPoint;
        }
        public void Use(Robot target)
        {
            target.armor += shieldPoint;
            Console.WriteLine($"Kemampuan SUPER SHIELD : meningkatkan armor {target.nama} sebesar {this.shieldPoint}");
        }
    }
}
