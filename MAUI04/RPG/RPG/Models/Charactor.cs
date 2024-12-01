using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace RPG.Models
{
    public class Charactor
    {
        // 속성
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Health")]
        public int Health {  get; set; }
        [JsonPropertyName("AttackPower")]
        public int AttackPower {  get; set; }
        [JsonPropertyName("AttcakSpeed")]
        public int AttackSpeed { get; set; }

        // 생성자
        public Charactor(string name, int health, int attackPower, int attackSpeed)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            AttackSpeed = attackSpeed;
        }
    }
}
