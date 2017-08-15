using BasketballRoster.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballRoster.ViewModel
{
    class LeagueViewModel
    {
        public RosterViewModel BriansTeam { get; private set; }
        public RosterViewModel JimmysTeam { get; private set; }

        public LeagueViewModel()
        {
            Roster briansRoster = new Roster("The Bombers", GetBombersPlayers());
            BriansTeam = new RosterViewModel(briansRoster);

            Roster jimmysRoster = new Roster("The Amazins", GetAmazinPlayers());
            JimmysTeam = new RosterViewModel(jimmysRoster);
        }

        private IEnumerable<Player> GetAmazinPlayers()
        {
            return new List<Player>
            {
                new Player("Brian", 31, true),
                new Player("Lloyd", 23, true),
                new Player("Kathleen", 6, false),
                new Player("Mike", 0, true),
                new Player("Joe", 42, true),
                new Player("Herb", 32, false),
                new Player("Fingers", 8, true)
            };
        }

        private IEnumerable<Player> GetBombersPlayers()
        {
            return new List<Player>
            {
                new Player("Jimmy", 42, true),
                new Player("Henry", 11, true),
                new Player("Bob", 4, true),
                new Player("Lucinda", 18, true),
                new Player("Kim Chen In", 8, true),
                new Player("Bertha", 23, false),
                new Player("Ed", 21, false)
            };
        }
    }
}
