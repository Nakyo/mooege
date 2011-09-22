/*
 * Copyright (C) 2011 D3Sharp Project
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using System;
using System.Data.SQLite;
using System.Reflection;
using D3Sharp.Utils;

namespace D3Sharp.Core.Storage
{
    // just a quick hack - not to be meant a final layer.
    public static class GameDataDBManager
    {
        public static SQLiteConnection Connection { get; private set; }
        public static readonly Logger Logger = LogManager.CreateLogger();

        static GameDataDBManager()
        {
            Connect();
        }

        private static void Connect()
        {
            try
            {
                Connection = new SQLiteConnection(string.Format("Data Source={0}/Assets/gamedata.db", System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
                Connection.Open();
            }
            catch (Exception e)
            {
                Logger.FatalException(e, "Connect()");
            }
        }
    }
}

