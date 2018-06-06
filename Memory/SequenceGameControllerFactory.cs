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
                gameController.NumberOfDockingStations = 2;
                gameController.MaxNumberOfDockingStations = 4;
                gameController.FirstLevelTimeReducerInSeconds = 0;
                gameController.SecondLevelTimeReducerInSeconds = 0;
                gameController.SequencerTimeInMilliseconds = 1500;

                return gameController;
            }
            else if (gameMode == GameModes.Normal)
            {
                gameController.NumberOfDockingStations = 3;
                gameController.MaxNumberOfDockingStations = 5;
                gameController.FirstLevelTimeReducerInSeconds = 0;
                gameController.SecondLevelTimeReducerInSeconds = 5;
                gameController.SequencerTimeInMilliseconds = 1000;

                return gameController;
            }
            else if (gameMode == GameModes.Hard)
            {
                gameController.NumberOfDockingStations = 4;
                gameController.MaxNumberOfDockingStations = 7;
                gameController.FirstLevelTimeReducerInSeconds = 5;
                gameController.SecondLevelTimeReducerInSeconds = 10;
                gameController.SequencerTimeInMilliseconds = 500;

                return gameController;
            }
            else
                throw new Exception("No such Game Mode");
        }
    }
}
