using System;

namespace Pocos
{
    namespace MonsterData
    {
        public partial class MonsterBase
        {
            public Byte[] ArrayOfBytes { get; set; } = new Byte[4];
            public MonsterData.DriveBase[] ArrayOfDrives { get; set; } = new MonsterData.DriveBase[4];
            public ixcomponent[] ArrayOfIxComponent { get; set; } = new ixcomponent[4];
        }

        public partial class Monster : MonsterBase
        {
            public MonsterData.DriveBase DriveA { get; set; } = new MonsterData.DriveBase();
        }

        public partial class DriveBase
        {
            public Double Position { get; set; }

            public Double Velo { get; set; }

            public Double Acc { get; set; }

            public Double Dcc { get; set; }
        }
    }
}