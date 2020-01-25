﻿using CSharpWars.Enums;
using CSharpWars.Processor.Middleware;
using CSharpWars.Scripting;

namespace CSharpWars.Processor.Moves
{
    /// <summary>
    /// Class containing logic for turning around.
    /// </summary>
    /// <remarks>
    /// Performing this move makes the robot turn 180°.
    /// This move does not consume stamina because the robot will not move away from its current location in the arena grid.
    /// </remarks>
    public class TurnAround : Move
    {
        public TurnAround(BotProperties botProperties) : base(botProperties) { }

        public override BotResult Go()
        {
            // Build result based on current properties.
            var botResult = new BotResult(BotProperties)
            {
                Move = PossibleMoves.TurningAround
            };

            botResult.Orientation = BotProperties.Orientation switch
            {
                PossibleOrientations.North => PossibleOrientations.South,
                PossibleOrientations.East => PossibleOrientations.West,
                PossibleOrientations.South => PossibleOrientations.North,
                PossibleOrientations.West => PossibleOrientations.East,
                _ => botResult.Orientation
            };

            return botResult;
        }
    }
}