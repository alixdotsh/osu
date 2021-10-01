﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Game.Database;
using osu.Game.Models.Interfaces;

namespace osu.Game.Beatmaps
{
    public class BeatmapDifficulty : IHasPrimaryKey, IBeatmapDifficultyInfo
    {
        /// <summary>
        /// The default value used for all difficulty settings except <see cref="SliderMultiplier"/> and <see cref="SliderTickRate"/>.
        /// </summary>
        public const float DEFAULT_DIFFICULTY = 5;

        public int ID { get; set; }

        public float DrainRate { get; set; } = DEFAULT_DIFFICULTY;
        public float CircleSize { get; set; } = DEFAULT_DIFFICULTY;
        public float OverallDifficulty { get; set; } = DEFAULT_DIFFICULTY;

        private float? approachRate;

        public float ApproachRate
        {
            get => approachRate ?? OverallDifficulty;
            set => approachRate = value;
        }

        public double SliderMultiplier { get; set; } = 1;
        public double SliderTickRate { get; set; } = 1;

        /// <summary>
        /// Returns a shallow-clone of this <see cref="BeatmapDifficulty"/>.
        /// </summary>
        public BeatmapDifficulty Clone()
        {
            var diff = new BeatmapDifficulty();
            CopyTo(diff);
            return diff;
        }

        public void CopyTo(BeatmapDifficulty difficulty)
        {
            difficulty.ApproachRate = ApproachRate;
            difficulty.DrainRate = DrainRate;
            difficulty.CircleSize = CircleSize;
            difficulty.OverallDifficulty = OverallDifficulty;

            difficulty.SliderMultiplier = SliderMultiplier;
            difficulty.SliderTickRate = SliderTickRate;
        }
    }
}
