﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diep.GameEngine.Scenario.Cannons;
using Diep.GameEngine.Shared;

namespace Diep.GameEngine.Scenario.Tanks
{
    public class Overseer : Tank
    {
        private DroneCannon leftCannon;
        private DroneCannon rightCannon;

        public Overseer(GameScreen Screen, TeamColor TeamColor, float Weight) : base(Screen, TeamColor, Weight)
        {
            // Simplest Constructor
        }

        public override void SetCannons()
        {
            // Creating Cannons
            leftCannon = new DroneCannon();
            rightCannon = new DroneCannon();
            // Setting Cannons
            Cannons = new Cannon[]
            {
                leftCannon,
                rightCannon
            };
            RepositionCannons(Bounds);
        }

        public override void RepositionCannons(RectangleF value)
        {
            // Make sure the SetCannons method has been already called
            if (Cannons != null)
            {
                var tankPosition = new SizeF(.5f, .5f);
                var cannonAngle = (Single)Math.PI / 2;
                var angleInterval = 2 * (Single)Math.PI / Cannons.Length;
                var cannonHeight = bounds.Height * .8f;
                var cannonBounds = new RectangleF(bounds.X, bounds.Y, bounds.Width * .7f, cannonHeight);
                //
                foreach (var cannon in Cannons)
                {
                    cannon.Angle = cannonAngle;
                    cannon.Support = this;
                    cannon.Bounds = cannonBounds;
                    cannon.TankPosition = tankPosition;
                    //
                    cannonAngle += angleInterval;
                }
            }
        }

        protected override void ExecuteShoot()
        {
            // This Tank must not execute any shoot when user clicks or press 'E'
        }
    }
}
