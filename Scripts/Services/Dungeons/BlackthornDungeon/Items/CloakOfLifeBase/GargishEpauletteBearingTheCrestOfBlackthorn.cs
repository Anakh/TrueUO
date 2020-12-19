namespace Server.Items
{
    public class GargishEpauletteBearingTheCrestOfBlackthorn5 : Cloak
    {
        public override bool IsArtifact => true;

        public override int LabelNumber => 1123326;  // Gargish Epaulette

        [Constructable]
        public GargishEpauletteBearingTheCrestOfBlackthorn5()
        {
            ReforgedSuffix = ReforgedSuffix.Blackthorn;
            ItemID = 0x9986;
            Attributes.BonusHits = 3;
            Attributes.RegenHits = 1;
            Hue = 132;

            Layer = Layer.OuterTorso;
        }

        public GargishEpauletteBearingTheCrestOfBlackthorn5(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
