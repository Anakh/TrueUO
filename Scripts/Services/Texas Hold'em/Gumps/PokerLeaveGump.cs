using Server.Gumps;
using Server.Network;

namespace Server.Poker
{
	public class PokerLeaveGump : Gump
	{
		private PokerGame m_Game;

		public PokerLeaveGump(Mobile from, PokerGame game)
			: base(50, 50)
		{
			m_Game = game;

			Closable = true;
			Disposable = true;
			Dragable = true;
			Resizable = false;

			AddPage(0);

			AddImageTiled(18, 15, 350, 180, 9274);
			AddAlphaRegion(23, 20, 340, 170);
			AddLabel(133, 25, 1149, "Leave Poker Table");
			AddImageTiled(42, 47, 301, 3, 96);
			AddLabel(60, 62, 154, "You are about to leave a game of Poker.");
			AddImage(33, 38, 95);
			AddImage(342, 38, 97);
			AddLabel(48, 80, 154, "Are you sure you want to cash-out and leave the");
			AddLabel(48, 98, 154, "table? You will auto fold, and any current bets");
			AddLabel(48, 116, 154, "will be lost. Winnings will be deposited in your bank.");
			AddButton(163, 155, 247, 248, (int)Handlers.btnOkay, GumpButtonType.Reply, 0);
		}

		public enum Handlers
		{
			None,
			btnOkay
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			Mobile from = state.Mobile;

			if (from == null)
            {
                return;
            }

            PokerPlayer player = m_Game.GetPlayer(from);

			if (player != null && info.ButtonID == 1)
			{
                if (m_Game.State == PokerGameState.Inactive)
                {
                    if (m_Game.Players.Contains(player))
                    {
                        m_Game.RemovePlayer(player);
                    }

                    return;
                }


                if (player.RequestLeave)
                {
                    from.SendMessage(0x22, "You have already submitted a request to leave.");
                }
                else
                {
                    from.SendMessage(0x22, "You have submitted a request to leave the table.");
                    player.RequestLeave = true;
                }
            }
		}
	}
}
