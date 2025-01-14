﻿using Common;
using GameServer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Managers
{
    class MapManager    :   Singleton<MapManager>
    {
        Dictionary<int, Map> Maps = new Dictionary<int, Map>();

        public void Init()
        {
            foreach(var mapdefine in DataManager.Instance.Maps.Values)
            {
                Map map = new Map(mapdefine);
                Log.InfoFormat("MapManager.Init > Map: {0} : {1}", map.Define.ID, map.Define.Name);
                this.Maps[mapdefine.ID] = map;
            }
        }

        public Map this[int key]
        {
            get
            {
                return this.Maps[key];
            }
        }
        public void Update()//存在自主服务，所以使用Update
        {
            foreach(var map in this.Maps.Values)
            {
                map.Update();
            }
        }
    }
}
