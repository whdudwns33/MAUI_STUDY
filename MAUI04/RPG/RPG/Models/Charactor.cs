using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Models
{
    internal class Charactor
    {
        // 이름
        public string Name { get; set; }
        // 체력
        public int Health {  get; set; }
        // 공격력
        public int AttackPower {  get; set; }
        // 공격속도
        public int AttackSpeed { get; set; }
    }
}
