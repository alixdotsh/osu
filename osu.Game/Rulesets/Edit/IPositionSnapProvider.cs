// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osuTK;

namespace osu.Game.Rulesets.Edit
{
    [Cached]
    public interface IPositionSnapProvider
    {
        /// <summary>
        /// Given a position, find a valid time and position snap.
        /// </summary>
        /// <remarks>
        /// This call should be equivalent to running <see cref="SnapScreenSpacePositionToValidPosition"/> with any additional logic that can be performed without the time immutability restriction.
        /// </remarks>
        /// <param name="screenSpacePosition">The screen-space position to be snapped.</param>
        /// <returns>The time and position post-snapping.</returns>
        SnapResult SnapScreenSpacePositionToValidTime(Vector2 screenSpacePosition);

        /// <summary>
        /// Given a position, find a value position snap, restricting time to its input value.
        /// </summary>
        /// <param name="screenSpacePosition">The screen-space position to be snapped.</param>
        /// <returns>The position post-snapping. Time will always be null.</returns>
        SnapResult SnapScreenSpacePositionToValidPosition(Vector2 screenSpacePosition);
    }
}
