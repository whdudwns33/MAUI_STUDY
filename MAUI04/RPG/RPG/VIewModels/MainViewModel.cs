using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
#region
//ObservableObject는 CommunityToolkit.Mvvm 라이브러리에서 제공하는 클래스입니다.
//MVVM 패턴에서 데이터 바인딩과 UI 업데이트를 간소화하기 위해 사용됩니다.
//이 클래스는 INotifyPropertyChanged 인터페이스를 구현하고 있어, 속성 값이 변경될 때 UI에 자동으로 알림을 보낼 수 있습니다.
#endregion
using RPG.Models;
using System.Text.Json;


namespace RPG.VIewModels
{
    internal class MainViewModel
    {
        public string battleLog;

        public ObservableCollection<Charactor> Party { get; } = new();
        public ObservableCollection<Charactor> Enemies { get; } = new();

        public void BattleViewModel()
        {
            LoadCharactersFromJson();
        }

        private void LoadCharactersFromJson()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "characters.json");
            if (File.Exists(filePath))
            {
                var jsonContent = File.ReadAllText(filePath);
                var data = JsonSerializer.Deserialize<CharactorsData>(jsonContent);

                foreach (var character in data.Party)
                    Party.Add(character);

                foreach (var enemy in data.Enemies)
                    Enemies.Add(enemy);

                battleLog = "캐릭터 데이터가 로드되었습니다.";
            }
            else
            {
                battleLog = "characters.json 파일을 찾을 수 없습니다.";
            }
        }

        public void StartBattle()
        {
            battleLog = "Battle started!";
            foreach (var charactor in Party)
            {
                StartCharacterAttack(charactor, Enemies[0]);
            }

            StartCharacterAttack(Enemies[0], Party[0]);
        }

        private void StartCharacterAttack(Character attacker, Character target)
        {
            new Thread(() =>
            {
                while (attacker.IsAlive && target.IsAlive)
                {
                    Thread.Sleep(1000);
                    attacker.Attack(target);

                    App.Current.Dispatcher.Dispatch(() =>
                    {
                        BattleLog += $"\n{attacker.Name} attacks {target.Name}, {target.Name}'s health: {target.Health}";

                        if (!target.IsAlive)
                        {
                            BattleLog += $"\n{target.Name} has been defeated!";
                        }
                    });

                    if (!target.IsAlive)
                        break;
                }
            }).Start();
        }
    }
    public class CharactorsData
    {
        public List<Charactor> Party { get; set; }
        public List<Charactor> Enemies { get; set; }
    }
}
