// -----------------------------------------------------------------------
// <copyright file="Translation.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Exiled.API.Interfaces;

namespace Mistaken.Suicide
{
    internal class Translation : ITranslation
    {
        public string SuicideEnter { get; set; } = "Shoot to kill yourself";

        public string SuicideExit { get; set; } = "You can now shoot without killing yourself";

        public string DeadMsg556x45 { get; set; } = "There is a hole in the head. It looks like 5.56x45 caliber";

        public string DeadMsg762x39 { get; set; } = "There is a hole in the head. It looks like 7.62x39 caliber";

        public string DeadMsg9x19 { get; set; } = "There is a hole in the head. It looks like 9x19 caliber";

        public string DeadMsg12gauge { get; set; } = "There is a hole in the head. It looks like 12 gauge";

        public string DeadMsg44cal { get; set; } = "There is a hole in the head. It looks like .44 caliber";

        public string DeadMsgUnknown { get; set; } = "There is a hole in the head but it's unknown what caused it";
    }
}
