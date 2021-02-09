using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace CheddarMod
{
    public class NetHelper
    {
        public static void HandlePacket(BinaryReader reader, int sender)
        {
            MessageType type = (MessageType)reader.ReadByte();
            switch (type)
            {
                case MessageType.WheelUpdate:
                    ReceiveWheelUpdate(reader);
                    break;
                default:
                    break;
            }
        }

        public static void SendWheelUpdate(bool enabled)
        {
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ModPacket packet = CheddarMod.Instance.GetPacket();
                packet.Write((byte)MessageType.WheelUpdate);
                packet.Write(enabled);
                packet.Send();
            }
        }

        public static void ReceiveWheelUpdate(BinaryReader reader)
        {
			bool flag = reader.ReadBoolean();
			if (flag)
			{
				// Console.WriteLine("Enabled via packet");
				Main.dayRate = 60;
				Main.fastForwardTime = true;
			}
			else
			{
				// Console.WriteLine("Disabled via packet");
				Main.fastForwardTime = false;
			}
			CheddarWorld.timeWheel = flag;
            // CheddarWorld.timeWheel = reader.ReadBoolean();
			if (Main.netMode == NetmodeID.Server)
			{
				NetMessage.SendData(MessageID.WorldData); // Just in case
			}
        }
    }

    enum MessageType : byte
    {
        WheelUpdate,
    }
}