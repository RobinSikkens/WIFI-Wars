﻿using System;
using System.IO;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

class Server : SpriteGameObject
{
    Color serverColor;
    double packetTimer;
    bool makePacket;
    bool connected;

    public Server(int color, Vector2 pos, int layer, String id)
        : base("Sprites/Server", layer, id)
    {
        position = pos;
        
        switch(color)
        {
            case 1:
                serverColor = Color.Red;         
                break;
            case 2:
                serverColor = Color.Purple;
                break;
            case 3:
                serverColor = Color.Yellow;
                break;
            default: throw new IOException("Invalid colour code: " + color);
        }
        sprite.SpriteColor = serverColor;
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (makePacket)
        {
            GameObjectList level = this.parent as GameObjectList;
            Packet packet = new Packet(this.position + this.Center, serverColor);
            level.Add(packet);
            makePacket = false;
        }
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        packetTimer += gameTime.ElapsedGameTime.TotalSeconds;
        if (packetTimer > 3 && connected)
        {
            packetTimer = 0;
            makePacket = true;
        }
        if (!connected)
        { 
        GameObjectList towerList = GameWorld.Find("towerlist") as GameObjectList;
        List<GameObject> towers = towerList.Objects;
        foreach (Tower tower in towers)
            if (this.CollidesWith(tower) && tower.Connected)
                this.connected = true;
        }
    }
}