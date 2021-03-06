﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace MD2
{
    public class Dialog_ManufacturingPlant : Window
    {
        protected AssemblyLine parent;
        protected string title = "";
        protected string message = "";
        protected float currentY = 0f;
        protected readonly float width;
        protected readonly float height;

        public Dialog_ManufacturingPlant(AssemblyLine parent, string title = "", string helpMessage = "", float width = 600, float height = 700)
        {
            this.absorbInputAroundWindow = true;
            this.forcePause = false;
            this.closeOnEscapeKey = true;
            this.doCloseX = true;
            this.message = helpMessage;
            this.title = title;
            this.parent = parent;

            this.width = width;
            this.height = height;

            this.draggable = true;
            this.resizeable = true;
        }

        public override Vector2 InitialWindowSize
        {
            get
            {
                return base.InitialWindowSize;
            }
        }
        public override void DoWindowContents(Rect inRect)
        {
            if (!title.NullOrEmpty())
            {
                Text.Anchor = TextAnchor.MiddleCenter;
                Text.Font = GameFont.Medium;
                Rect labelRect = new Rect(0f, 0f, inRect.width, 40f);
                Widgets.Label(labelRect, title);
                currentY += 45f;
                Widgets.DrawLineHorizontal(0f, currentY, inRect.width);
                currentY += 10f;
                Text.Anchor = TextAnchor.UpperLeft;
                Text.Font = GameFont.Small;
            }
            if (!message.NullOrEmpty())
            {
                Rect helpRect = new Rect(0, 0, 20, 20);
                if (Widgets.TextButton(helpRect, "?"))
                {
                    Find.WindowStack.Add(new Dialog_Message(message, "Help".Translate()));
                }
                TooltipHandler.TipRegion(helpRect, "DialogHelp".Translate());
            }
        }
        protected virtual void ResetVariables()
        {
            currentY = 0f;
        }
    }
}
