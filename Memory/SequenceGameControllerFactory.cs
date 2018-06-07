using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public enum GameModes
    {
        Easy,
        Normal,
        Hard
    }

    public class SequenceGameControllerFactory
    {
        private SequenceGameController gameController;

        public SequenceGameControllerFactory(Player player, SequenceGameForm form)
        {
            gameController = new SequenceGameController(player, form);
        }

        public SequenceGameController createSequenceGameController(GameModes gameMode)
        {
            if (gameMode == GameModes.Easy)
            {
                gameController.StartNumberOfDockingStations = 2;
                gameController.EndNumberOfDockingStations = 4;
                gameController.FirstLevelTimeReducerInSeconds = 0;
                gameController.SecondLevelTimeReducerInSeconds = 0;
                gameController.FirstLevelDivisor = 1;
                gameController.SecondLevelDivisor = 2;
                gameController.SequencerTimeInMilliseconds = 1500;

                return gameController;
            }
            else if (gameMode == GameModes.Normal)
            {
                gameController.StartNumberOfDockingStations = 3;
                gameController.EndNumberOfDockingStations = 5;
                gameController.FirstLevelTimeReducerInSeconds = 0;
                gameController.SecondLevelTimeReducerInSeconds = 5;
                gameController.FirstLevelDivisor = 2;
                gameController.SecondLevelDivisor = 2;
                gameController.SequencerTimeInMilliseconds = 1000;

                return gameController;
            }
            else if (gameMode == GameModes.Hard)
            {
                gameController.StartNumberOfDockingStations = 4;
                gameController.EndNumberOfDockingStations = 7;
                gameController.FirstLevelTimeReducerInSeconds = 5;
                gameController.SecondLevelTimeReducerInSeconds = 10;
                gameController.FirstLevelDivisor = 2;
                gameController.SecondLevelDivisor = 2;
                gameController.SequencerTimeInMilliseconds = 500;

                return gameController;
            }
            else
                throw new Exception("No such Game Mode");
        }
    }
}
