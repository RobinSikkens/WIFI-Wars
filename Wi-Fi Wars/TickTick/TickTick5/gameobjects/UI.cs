﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

class UI : GameObjectList
{
    int money;
    TextGameObject moneyText;
    public UI(int m, int layer = 0, string id = "ui")
        : base(layer, id)
    {
        money = m;
        moneyText = new TextGameObject("Fonts/Hud");
        moneyText.Position = new Vector2(50, 50);
        this.Add(moneyText);
        PoliceBar policeBar = new PoliceBar();
        this.Add(policeBar);
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        moneyText.Text = "Money:" + money + "$";
    }
    public int Money
    {
        get { return money; }
        set { money = value; }
    }
}